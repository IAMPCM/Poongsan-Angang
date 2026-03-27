using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public partial class Form1 : Form
    {
        public VasimPlatform m_VasimPlatform;
        private struct AmmoRow
        {
            public string Bore { get; set; }
            public string Bullet { get; set; }
            public string Local { get; set; }
            public string CartonBCD { get; set; }
            public string BoxBCD { get; set; }
        }

        private bool _isInternalChange = false;

        // 전체 데이터 리스트
        private List<AmmoRow> _rows = new List<AmmoRow>();

        public bool bAlarmPopupFocousStop = false;

        // 추가 - 타임아웃 60초 기능 추가
        private System.Timers.Timer _timeoutTimer;  // 타이머 객체
        private const int TIMEOUT_SECONDS = 60;     // 60초 = 1분

        // 로그인 관련 변수
        private bool _isLoggedIn = false;                    // 로그인 상태
        private System.Timers.Timer _loginTimer;             // 로그인 유지 타이머
        private const int LOGIN_TIMEOUT_SECONDS = 60;        // 로그인 유지 시간 60초


        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // Form 레벨에서 키 입력 가로채기
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            m_VasimPlatform = new VasimPlatform(this);
            AlarmForm.Initialize(this);
            m_VasimPlatform.m_SystemData.Load();

            if (m_VasimPlatform.m_SystemData.AutoMachineUse == "true")
            {
                lb_MachineName.Text = "자동 검사 장비";
            }
            else
            {
                lb_MachineName.Text = "자동 검사 장비";
            }

            Initialize();

            // 타임아웃 토글 버튼 초기 상태 설정
            if (m_VasimPlatform.m_SystemData.TimeoutUse == "true")
            {
                btn_TimeoutToggle.Text = "타임아웃 ON";
                btn_TimeoutToggle.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                btn_TimeoutToggle.Text = "타임아웃 OFF";
                btn_TimeoutToggle.BackColor = System.Drawing.Color.Gray;
            }

            // 금일 검사 수량 복원
            string savedDate = m_VasimPlatform.m_SystemData.CountDate;
            if (savedDate == DateTime.Today.ToString("yyyy-MM-dd"))
            {
                // 오늘 날짜 데이터면 복원
                LoadCountFromIni();
            }
            else
            {
                // 날짜가 다르면 초기화
                ResetDailyCount();
            }
        }
        public void Initialize()
        {
            if (m_VasimPlatform.m_SystemData.AutoMachineUse == "true")
            {
                m_VasimPlatform.m_mxPlc.Initialize();
                label_PLC_Status.Visible = true;
            }
            else
            {
                label_PLC_Status.Visible = false;
            }
        }

        // 로그인 팝업 표시 함수
        private bool ShowPasswordForm()
        {
            if (_isLoggedIn) return true; // 이미 로그인 상태면 바로 통과

            using (PasswordForm pwForm = new PasswordForm(m_VasimPlatform.m_SystemData.LoginPassword))
            {
                pwForm.ShowDialog(this);
                if (pwForm.IsAuthenticated)
                {
                    _isLoggedIn = true;

                    // 로그인 유지 타이머 시작
                    if (_loginTimer == null)
                    {
                        _loginTimer = new System.Timers.Timer();
                        _loginTimer.Interval = LOGIN_TIMEOUT_SECONDS * 1000;
                        _loginTimer.AutoReset = false;
                        _loginTimer.Elapsed += new ElapsedEventHandler(LoginTimer_Elapsed);
                    }
                    _loginTimer.Stop();
                    _loginTimer.Start();
                    return true;
                }
                return false;
            }
        }

        // 로그인 유지 시간 만료 시 자동 로그아웃
        private void LoginTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Invoke(new Action(delegate
            {
                _isLoggedIn = false;
            }));
        }

        // CSV 저장 함수
        private void SaveToCsv(string boxType, string standardBcd, string scannedBcd, string result)
        {
            try
            {
                // 오전 7시 기준 날짜 계산
                DateTime now = DateTime.Now;
                DateTime csvDate = now.Hour < 7 ? now.Date.AddDays(-1) : now.Date;
                string dateStr = csvDate.ToString("yyyyMMdd");

                // 파일명 결정
                string fileName = boxType == "Carton"
                    ? string.Format("CartonBCD_{0}.csv", dateStr)
                    : string.Format("BoxBCD_{0}.csv", dateStr);

                string csvPath = System.IO.Path.Combine(Define.HistoryPath, fileName);

                // 폴더 없으면 생성
                if (!System.IO.Directory.Exists(Define.HistoryPath))
                    System.IO.Directory.CreateDirectory(Define.HistoryPath);

                // 헤더 추가 (파일이 없을 때만)
                bool fileExists = System.IO.File.Exists(csvPath);
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(csvPath, true, new System.Text.UTF8Encoding(true)))
                {
                    if (!fileExists)
                        sw.WriteLine("날짜\t시간\t구경\t탄종\t기준바코드\t리딩바코드\t검사결과");

                    sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",
                        now.ToString("yyyy-MM-dd"),
                        now.ToString("HH:mm:ss"),
                        cboBore.Text,
                        cboBullet.Text,
                        standardBcd,
                        scannedBcd,
                        result));
                }
            }
            catch { }
        }

        // ini에서 검사 수량 불러오기
        private void LoadCountFromIni()
        {
            _cartonOkSet = StringToHashSet(m_VasimPlatform.m_SystemData.CartonOkList);
            _cartonNgSet = StringToHashSet(m_VasimPlatform.m_SystemData.CartonNgList);
            _boxOkSet = StringToHashSet(m_VasimPlatform.m_SystemData.BoxOkList);
            _boxNgSet = StringToHashSet(m_VasimPlatform.m_SystemData.BoxNgList);
            _lastResetDate = DateTime.Today;
            UpdateCountDisplay();
        }

        // HashSet을 쉼표 구분 문자열로 변환
        private string HashSetToString(System.Collections.Generic.HashSet<string> set)
        {
            return string.Join(",", set);
        }

        // 쉼표 구분 문자열을 HashSet으로 변환
        private System.Collections.Generic.HashSet<string> StringToHashSet(string str)
        {
            var set = new System.Collections.Generic.HashSet<string>();
            if (!string.IsNullOrEmpty(str))
                foreach (var item in str.Split(','))
                    if (!string.IsNullOrEmpty(item))
                        set.Add(item);
            return set;
        }

        // ini에 검사 수량 저장
        private void SaveCountToIni()
        {
            m_VasimPlatform.m_SystemData.CountDate = DateTime.Today.ToString("yyyy-MM-dd");
            m_VasimPlatform.m_SystemData.CartonOkList = HashSetToString(_cartonOkSet);
            m_VasimPlatform.m_SystemData.CartonNgList = HashSetToString(_cartonNgSet);
            m_VasimPlatform.m_SystemData.BoxOkList = HashSetToString(_boxOkSet);
            m_VasimPlatform.m_SystemData.BoxNgList = HashSetToString(_boxNgSet);
            m_VasimPlatform.m_SystemData.Save();
        }

        // 금일 검사 수량 표시 업데이트
        private void UpdateCountDisplay()
        {
            label6.Text = string.Format(
                "카톤 박스 OK:{0}  NG:{1}    골판지 박스 OK:{2}  NG:{3}",
                _cartonOkSet.Count, _cartonNgSet.Count,
                _boxOkSet.Count, _boxNgSet.Count);
        }

        // 수량 초기화
        private void ResetDailyCount()
        {
            _cartonOkSet.Clear();
            _cartonNgSet.Clear();
            _boxOkSet.Clear();
            _boxNgSet.Clear();
            _lastResetDate = DateTime.Today;
            UpdateCountDisplay();
            SaveCountToIni(); // ini에 초기화 상태 저장
        }

        // 추가 -> 타임아웃 발생시 실행
        private void TimeoutTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Invoke(new Action(delegate
            {
                if (bEQStart)
                {
                    // 변경 전
                    // AlarmForm.ShowAlarm("바코드 스캔 타임아웃 (1분 초과)", this);

                    // 변경 후
                    AlarmForm.ShowAlarm("타임아웃 초과", this);

                    lb_Result.Text = "NG";
                    lb_Result.BackColor = System.Drawing.Color.Red;
                }
            }));
        }

        // 추가 -> 타이머 리셋 함수 (바코드 스캔할 때마다 호출)
        private void ResetTimeoutTimer()
        {
            if (_timeoutTimer != null && bEQStart)
            {
                _timeoutTimer.Stop();
                _timeoutTimer.Start();
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("프로그램을 종료 하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            blockClose = false;

            if (m_VasimPlatform.m_SystemData.AutoMachineUse == "true")
                m_VasimPlatform.m_mxPlc.Dispose();

            // 추가: 전부 끄기
            m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_RED, 0);
            m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_YELLOW, 0);
            m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_GREEN, 0);
            m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_BUZZER, 0);

            Delay(1000);

            this.Close();
        }
        private bool blockClose = true;
        protected override void WndProc(ref Message m)
        {
            const int WM_CLOSE = 0x0010;

            if (m.Msg == WM_CLOSE && blockClose)
            {
                // Alt+F4 또는 창 닫기 시도 => 무시
                return;
            }

            base.WndProc(ref m);
        }
        private void Delay(int ms)
        {
            var tick = Environment.TickCount;

            while (Environment.TickCount - tick < ms)
            {
                Application.DoEvents();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(0, 0);

            // 추가
            this.WindowState = FormWindowState.Maximized;

            // this.TopMost = true;  // 항상 최상단에 표시

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();

            LoadCsvData();

            InitBoreCombo();
            btn_Stop.BackColor = System.Drawing.Color.Red;

            // 두 입력창 항상 활성화 상태 유지
            txtInputBoxBCD.Enabled = true;
            txtInputCartonBCD.Enabled = true;
            txtHiddenInput.Focus();

            // 추가: 프로그램 시작 시 노란불
            m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_RED, 0);
            m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_YELLOW, 1);
            m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_GREEN, 0);
        }
        public void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Invoke(new Action(delegate
            {
                if (bEQStart == true && !bAlarmPopupFocousStop)
                {
                    if (!txtHiddenInput.Focused && !txtInputBoxBCD.Focused)
                    {
                        _bCartonFirstInput = false;
                        _bBoxFirstInput = false;
                        if (!string.IsNullOrEmpty(txtInputBoxBCD.Text))
                            txtInputBoxBCD.Focus();
                        else
                            txtHiddenInput.Focus();
                    }
                }

                // 오전 7시 자동 초기화 체크
                if (DateTime.Now.Hour == 7 && DateTime.Today != _lastResetDate)
                {
                    ResetDailyCount();
                }

                if (m_VasimPlatform.m_SystemData.AutoMachineUse == "true")
                {
                    if (m_VasimPlatform.m_mxPlc.m_bConnected)
                        label_PLC_Status.BackColor = Color.Green;
                    else
                        label_PLC_Status.BackColor = Color.Red;
                }
            }));
        }
        private void LoadCsvData()
        {
            //string filePath = Path.Combine(Application.StartupPath, "data.csv");

            // 변경 전
            string filePath = "D:\\PoongSanBCD.csv";
            // 변경 후
            // string filePath = "C:\\PoongSanBCD.csv";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("data.csv 파일을 찾을 수 없습니다.\n" + filePath);
                return;
            }

            var lines = File.ReadAllLines(filePath)
                            .Where(l => !string.IsNullOrWhiteSpace(l))
                            .ToList();

            if (lines.Count <= 1)
            {
                MessageBox.Show("CSV 파일에 데이터가 없습니다.");
                return;
            }

            for (int i = 1; i < lines.Count; i++)
            {
                string[] cells = lines[i].Split(',');

                if (cells.Length < 5) continue;

                _rows.Add(new AmmoRow
                {
                    Bore = cells[0].Trim(),
                    Bullet = cells[1].Trim(),
                    Local = cells[2].Trim(),
                    CartonBCD = cells[3].Trim(),
                    BoxBCD = cells[4].Trim()
                });
            }
        }

        private void InitBoreCombo()
        {
            _isInternalChange = true;

            cboBore.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBullet.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocal.DropDownStyle = ComboBoxStyle.DropDownList;

            cboBore.Items.Clear();
            cboBullet.Items.Clear();
            cboLocal.Items.Clear();
            txtCartonBCD.Text = string.Empty;
            txtBoxBCD.Text = string.Empty;
            //txtCartonBCD.Clear();
            //txtBoxBCD.Clear();

            var boreList = _rows.Select(r => r.Bore).Distinct().OrderBy(x => x).ToList();
            cboBore.Items.AddRange(boreList.Cast<object>().ToArray());

            _isInternalChange = false;
        }

        private void cboBore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInternalChange || cboBore.SelectedItem == null) return;

            _isInternalChange = true;

            string bore = cboBore.SelectedItem.ToString();

            var bulletList = _rows
                .Where(r => r.Bore == bore)
                .Select(r => r.Bullet)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            cboBullet.Items.Clear();
            cboLocal.Items.Clear();
            txtCartonBCD.Text = string.Empty;
            txtBoxBCD.Text = string.Empty;
            //txtCartonBCD.Clear();
            //txtBoxBCD.Clear();

            cboBullet.Items.AddRange(bulletList.Cast<object>().ToArray());

            _isInternalChange = false;
        }

        private void cboBullet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInternalChange || cboBore.SelectedItem == null || cboBullet.SelectedItem == null) return;

            _isInternalChange = true;

            string bore = cboBore.SelectedItem.ToString();
            string bullet = cboBullet.SelectedItem.ToString();

            var localList = _rows
                .Where(r => r.Bore == bore && r.Bullet == bullet)
                .Select(r => r.Local)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            cboLocal.Items.Clear();
            txtCartonBCD.Text = string.Empty;
            txtBoxBCD.Text = string.Empty;
            //txtCartonBCD.Clear();
            //txtBoxBCD.Clear();

            cboLocal.Items.AddRange(localList.Cast<object>().ToArray());

            _isInternalChange = false;
        }

        private void cboLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBore.SelectedItem == null || cboBullet.SelectedItem == null || cboLocal.SelectedItem == null) return;

            string bore = cboBore.SelectedItem.ToString();
            string bullet = cboBullet.SelectedItem.ToString();
            string local = cboLocal.SelectedItem.ToString();

            var row = _rows.FirstOrDefault(r => r.Bore == bore && r.Bullet == bullet && r.Local == local);

            txtCartonBCD.Text = row.CartonBCD;
            txtBoxBCD.Text = row.BoxBCD;
        }
        bool bEQStart = false;
        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (cboBore.SelectedItem == null || cboBullet.SelectedItem == null || cboLocal.SelectedItem == null)
            {
                MessageBox.Show("생산 모델 설정 바랍니다");
                return;
            }

            btn_Start.BackColor = System.Drawing.Color.Green;
            btn_Stop.BackColor = System.Drawing.Color.Gray;

            cboBore.Enabled = false;
            cboBullet.Enabled = false;
            cboLocal.Enabled = false;
            bEQStart = true;

            // 두 입력창 항상 활성화 상태이므로 별도 처리 불필요
            txtHiddenInput.Focus();

            // 추가 -> 타임아웃 타이머 시작 (타임아웃 ON일 때만)
            if (m_VasimPlatform.m_SystemData.TimeoutUse == "true")
            {
                if (_timeoutTimer == null)
                {
                    _timeoutTimer = new System.Timers.Timer();
                    _timeoutTimer.Interval = TIMEOUT_SECONDS * 1000;
                    _timeoutTimer.AutoReset = false;
                    _timeoutTimer.Elapsed += new ElapsedEventHandler(TimeoutTimer_Elapsed);
                }
                _timeoutTimer.Stop();
                _timeoutTimer.Start();
            }

            // 추가: 초록불
            m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_RED, 0);
            m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_YELLOW, 0);
            m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_GREEN, 1);
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            btn_Stop.BackColor = System.Drawing.Color.Red;
            btn_Start.BackColor = System.Drawing.Color.Gray;
            cboBore.Enabled = true;
            cboBullet.Enabled = true;
            cboLocal.Enabled = true;
            bEQStart = false;
            txtInputCartonBCD.Text = string.Empty;
            txtInputBoxBCD.Text = string.Empty;

            // 추가 -> 타임아웃 타이머 중지
            if (_timeoutTimer != null)
                _timeoutTimer.Stop();

            // 추가: 노란불
            m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_RED, 0);
            m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_YELLOW, 1);
            m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_GREEN, 0);
        }

        // 새로 추가 - 바코드 자릿수 상수
        private const int CARTON_BCD_LENGTH = 12; // 카톤박스 바코드 자릿수
        private const int BOX_BCD_LENGTH = 14;    // 골판지 바코드 자릿수
        private string _barcodeBuffer = string.Empty; // 바코드 리더기 입력 임시 저장

        // 금일 검사 수량 관련 변수
        private System.Collections.Generic.HashSet<string> _cartonOkSet = new System.Collections.Generic.HashSet<string>();
        private System.Collections.Generic.HashSet<string> _cartonNgSet = new System.Collections.Generic.HashSet<string>();
        private System.Collections.Generic.HashSet<string> _boxOkSet = new System.Collections.Generic.HashSet<string>();
        private System.Collections.Generic.HashSet<string> _boxNgSet = new System.Collections.Generic.HashSet<string>();
        private DateTime _lastResetDate = DateTime.MinValue;


        // Form 레벨 바코드 버퍼
        private string _barcodeInputBuffer = "";
        private bool _cartonTextChanging = false;
        private bool _bCartonFirstInput = true;
        private bool _bBoxFirstInput = true;
        private bool _boxTextChanging = false;

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!bEQStart) return;
            if (bAlarmPopupFocousStop) return;

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                string scanned = _barcodeInputBuffer.Trim();
                _barcodeInputBuffer = "";

                if (scanned.Length == CARTON_BCD_LENGTH)
                    ProcessCartonBCD(scanned);
                else if (scanned.Length == BOX_BCD_LENGTH)
                    ProcessBoxBCD(scanned);
                else if (scanned.Length > 0)
                {
                    AlarmForm.ShowAlarm("NG", this);
                    lb_Result.Text = "NG";
                    lb_Result.BackColor = System.Drawing.Color.Red;
                    SaveToCsv("Carton", txtCartonBCD.Text, scanned, "NG");
                    UpdateCountDisplay();
                    SaveCountToIni();
                    ResetTimeoutTimer();
                }
            }
            else if (!char.IsControl(e.KeyChar))
            {
                _barcodeInputBuffer += e.KeyChar;
                e.Handled = true;
            }
        }

        private void ProcessCartonBCD(string scanned)
        {
            _cartonTextChanging = true;
            txtInputCartonBCD.Text = scanned;
            _cartonTextChanging = false;

            if (m_VasimPlatform.m_SystemData.AutoMachineUse == "true")
            {
                string sPLCData;
                try
                {
                    m_VasimPlatform.m_mxPlc.Read2WordForwardString(PLCDefine.PLC_Data, PLCDefine.PLC_Data_Length, out sPLCData);
                }
                catch
                {
                    AlarmForm.ShowAlarm("PLC 이상 발생.", this);
                    lb_Result.Text = "NG";
                    lb_Result.BackColor = System.Drawing.Color.Red;
                    return;
                }
                if (cboBore.Text != sPLCData)
                {
                    AlarmForm.ShowAlarm("PLC Data가 불일치 합니다.", this);
                    lb_Result.Text = "NG";
                    lb_Result.BackColor = System.Drawing.Color.Red;
                }
            }

            if (txtCartonBCD.Text == scanned)
            {
                lb_Result.Text = "OK";
                lb_Result.BackColor = System.Drawing.Color.Green;
                _cartonOkSet.Add(scanned);
                _cartonNgSet.Remove(scanned);
                SaveToCsv("Carton", txtCartonBCD.Text, scanned, "OK");
            }
            else
            {
                AlarmForm.ShowAlarm("NG", this);
                lb_Result.Text = "NG";
                lb_Result.BackColor = System.Drawing.Color.Red;
                if (!_cartonOkSet.Contains(scanned))
                    _cartonNgSet.Add(scanned);
                SaveToCsv("Carton", txtCartonBCD.Text, scanned, "NG");
            }
            UpdateCountDisplay();
            SaveCountToIni();
            ResetTimeoutTimer();
        }

        private void ProcessBoxBCD(string scanned)
        {
            txtInputBoxBCD.Text = scanned;

            if (txtBoxBCD.Text == scanned)
            {
                lb_Result.Text = "OK";
                lb_Result.BackColor = System.Drawing.Color.Green;
                _boxOkSet.Add(scanned);
                _boxNgSet.Remove(scanned);
                SaveToCsv("Box", txtBoxBCD.Text, scanned, "OK");
            }
            else
            {
                AlarmForm.ShowAlarm("NG", this);
                lb_Result.Text = "NG";
                lb_Result.BackColor = System.Drawing.Color.Red;
                if (!_boxOkSet.Contains(scanned))
                    _boxNgSet.Add(scanned);
                SaveToCsv("Box", txtBoxBCD.Text, scanned, "NG");
            }
            UpdateCountDisplay();
            SaveCountToIni();
            ResetTimeoutTimer();
        }

        private void txtInputCartonBCD_KeyPress(object sender, KeyPressEventArgs e) { }

        private void txtInputBoxBCD_TextChanged(object sender, EventArgs e) { }

        private void txtInputCartonBCD_TextChanged(object sender, EventArgs e) { }

        private void txtInputBoxBCD_KeyPress(object sender, KeyPressEventArgs e) { }

        private void label6_Click(object sender, EventArgs e) { }

        private void btn_ModelSetting_Click(object sender, EventArgs e)
        {
            if (bEQStart == true)
            {
                MessageBox.Show("설비 정지 후 바코드 설정을 실행하세요.");
                return;
            }

            if (!ShowPasswordForm()) return;

            using (ModelForm modelForm = new ModelForm())
            {
                modelForm.ShowDialog(this);
            }

            // 바코드 설정 후 CSV 데이터 다시 로드
            _rows.Clear();
            LoadCsvData();
            InitBoreCombo();
        }
    }
}
