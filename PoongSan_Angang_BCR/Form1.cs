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

        private bool _isInternalChange = false; // 클래스 전체에서 쓰는 변수이기 때문에 앞에 _를 붙인다.(관례)
        private bool _isRestoring      = false; // 선택값 복원 중 플래그 (SystemData 덮어쓰기 방지)

        // 전체 데이터 리스트
        private List<AmmoRow> _rows = new List<AmmoRow>();

        public bool bAlarmPopupFocousStop = false;

        // 추가 - 타임아웃 기능
        private System.Timers.Timer _timeoutTimer;  // 타이머 객체

        // 로그인 관련 변수
        private bool _isLoggedIn = false;                    // 로그인 상태
        private System.Timers.Timer _loginTimer;             // 로그인 유지 타이머
        private const int LOGIN_TIMEOUT_SECONDS = 60;        // 로그인 유지 시간 60초


        public Form1()
        {
            InitializeComponent();
            m_VasimPlatform = new VasimPlatform(this); // 객체 생성
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
            ApplyResetButtonIcons();

            // 작업자 사번 표시 초기화
            UpdateEmployeeLabel();

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
        public void Initialize() // PLC 연결 초기화
        {
            if (m_VasimPlatform.m_SystemData.AutoMachineUse == "true")
            {
                if (m_VasimPlatform.m_SystemData.melsecplcUse == "true")
                    m_VasimPlatform.m_mxPlc.Initialize();
                else
                    ConnectOmron();

                label_PLC_Status.Visible = true;
            }
            else
            {
                label_PLC_Status.Visible = false;
            }
        }
        public void ConnectOmron()
        {
            //AddLog("Try to Connect the OmronPLC");

            //this.plc_omron = new mcOMRON.OmronPLC(mcOMRON.TransportType.Tcp);

            try
            {
                mcOMRON.tcpFINSCommand tcpCommand = ((mcOMRON.tcpFINSCommand)m_VasimPlatform.plc_omron.FinsCommand);
                tcpCommand.SetTCPParams(System.Net.IPAddress.Parse(m_VasimPlatform.m_SystemData.PLC_Address), Convert.ToInt32(m_VasimPlatform.m_SystemData.PLC_Port));

                if (!m_VasimPlatform.plc_omron.Connect())
                {
                    //AddLog("!plc_omron.Connect()");
                }

            }
            catch (Exception ex)
            {
                //AddLog("if (CModel.Instance.PLCsetting.Port == 9600)");
                //AddLog(ex.ToString());
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

        // 로그인 유지 시간 만료 시 자동 로그아웃 => 로그인 타이머 60초 만료시 자동 로그아웃
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
            int.TryParse(m_VasimPlatform.m_SystemData.CartonOkList, out _cartonOkCount);
            int.TryParse(m_VasimPlatform.m_SystemData.CartonNgList, out _cartonNgCount);
            int.TryParse(m_VasimPlatform.m_SystemData.BoxOkList,    out _boxOkCount);
            int.TryParse(m_VasimPlatform.m_SystemData.BoxNgList,    out _boxNgCount);
            _lastResetDate = DateTime.Today;
            UpdateCountDisplay();
        }

        // ini에 검사 수량 저장
        private void SaveCountToIni()
        {
            m_VasimPlatform.m_SystemData.CountDate    = DateTime.Today.ToString("yyyy-MM-dd");
            m_VasimPlatform.m_SystemData.CartonOkList = _cartonOkCount.ToString();
            m_VasimPlatform.m_SystemData.CartonNgList = _cartonNgCount.ToString();
            m_VasimPlatform.m_SystemData.BoxOkList    = _boxOkCount.ToString();
            m_VasimPlatform.m_SystemData.BoxNgList    = _boxNgCount.ToString();
            m_VasimPlatform.m_SystemData.Save();
        }

        // 금일 검사 수량 표시 업데이트
        private void UpdateCountDisplay()
        {
            label6.Text = string.Format(
                "카톤 박스 OK:{0}  NG:{1}    골판지 박스 OK:{2}  NG:{3}",
                _cartonOkCount, _cartonNgCount,
                _boxOkCount, _boxNgCount);
        }

        // 카톤 박스 수량 리셋 버튼
        private void btnResetCarton_Click(object sender, EventArgs e)
        {
            using (var pwForm = new PasswordForm(m_VasimPlatform.m_SystemData.LoginPassword))
            {
                pwForm.ShowDialog(this);
                if (pwForm.IsAuthenticated)
                    ResetCartonCount();
            }
        }

        // 골판지 박스 수량 리셋 버튼
        private void btnResetBox_Click(object sender, EventArgs e)
        {
            using (var pwForm = new PasswordForm(m_VasimPlatform.m_SystemData.LoginPassword))
            {
                pwForm.ShowDialog(this);
                if (pwForm.IsAuthenticated)
                    ResetBoxCount();
            }
        }

        // 카톤 박스 수량 초기화
        private void ResetCartonCount()
        {
            _cartonOkCount = 0;
            _cartonNgCount = 0;
            UpdateCountDisplay();
            SaveCountToIni();
        }

        // 골판지 박스 수량 초기화
        private void ResetBoxCount()
        {
            _boxOkCount = 0;
            _boxNgCount = 0;
            UpdateCountDisplay();
            SaveCountToIni();
        }

        // 전체 수량 초기화 (날짜 변경 시 자동 호출)
        private void ResetDailyCount()
        {
            _cartonOkCount = 0;
            _cartonNgCount = 0;
            _boxOkCount    = 0;
            _boxNgCount    = 0;
            _lastResetDate = DateTime.Today;
            UpdateCountDisplay();
            SaveCountToIni();
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
        // ── 리셋 버튼 아이콘 ───────────────────────────────────────────
        private void ApplyResetButtonIcons()
        {
            var icon = CreateResetIcon(22);
            foreach (var btn in new Button[] { btnResetCarton, btnResetBox })
            {
                btn.Image             = icon;
                btn.TextImageRelation = TextImageRelation.ImageAboveText;
                btn.ImageAlign        = ContentAlignment.TopCenter;
                btn.TextAlign         = ContentAlignment.BottomCenter;
            }
            btnResetCarton.Text = "카톤\r\n리셋";
            btnResetBox.Text    = "박스\r\n리셋";
        }

        private static Bitmap CreateResetIcon(int size)
        {
            var bmp = new Bitmap(size, size, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                float pad = size * 0.1f;
                float d   = size - 2 * pad;
                float cx  = size / 2f;
                float cy  = size / 2f;
                float r   = d / 2f;
                float pw  = Math.Max(2f, size * 0.14f);

                using (var pen = new Pen(Color.FromArgb(44, 62, 80), pw))
                {
                    pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                    // 60° 에서 시작, 270° 호 → 330° 에서 끝
                    g.DrawArc(pen, pad, pad, d, d, 60f, 270f);
                }

                // 화살촉: 호의 끝점(330°)에서 접선 방향으로 삼각형
                double endRad     = 330.0 * Math.PI / 180.0;
                float  ex         = cx + r * (float)Math.Cos(endRad);
                float  ey         = cy + r * (float)Math.Sin(endRad);
                double tangentRad = endRad + Math.PI / 2.0;   // 시계 방향 접선
                float  ah         = pw * 2.0f;
                float  aw         = pw * 1.2f;

                float tipX = ex + ah * (float)Math.Cos(tangentRad);
                float tipY = ey + ah * (float)Math.Sin(tangentRad);
                float lx   = ex + aw * (float)Math.Cos(tangentRad + Math.PI * 2.0 / 3.0);
                float ly   = ey + aw * (float)Math.Sin(tangentRad + Math.PI * 2.0 / 3.0);
                float rx2  = ex + aw * (float)Math.Cos(tangentRad - Math.PI * 2.0 / 3.0);
                float ry2  = ey + aw * (float)Math.Sin(tangentRad - Math.PI * 2.0 / 3.0);

                using (var brush = new SolidBrush(Color.FromArgb(44, 62, 80)))
                    g.FillPolygon(brush, new PointF[]
                    {
                        new PointF(tipX, tipY),
                        new PointF(lx,   ly),
                        new PointF(rx2,  ry2)
                    });
            }
            return bmp;
        }
        // ─────────────────────────────────────────────────────────────

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
            RestoreSelections();   // 프로그램 재시작 시 마지막 선택값 복원
            btn_Stop.BackColor = System.Drawing.Color.Red;

            txtInputBCR.Focus();

            // 추가: 프로그램 시작 시 노란불
            m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_RED, 0);
            m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_YELLOW, 1);
            m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_GREEN, 0);
        }
        public void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Invoke(new Action(delegate
            {
                // 콤보박스 선택 중이 아니고, 알람 팝업도 없을 때 항상 txtInputBCR에 포커스 유지
                // (시작/정지 상태 모두 적용 → 정지 중 바코드가 설정란에 입력되는 문제 방지)
                bool comboHasFocus = cboBore.Focused   || cboBullet.Focused   || cboLocal.Focused
                                  || cboBore.DroppedDown || cboBullet.DroppedDown || cboLocal.DroppedDown;
                if (!bAlarmPopupFocousStop && !comboHasFocus)
                {
                    if (!txtInputBCR.Focused)
                        txtInputBCR.Focus();
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
            string filePath = Define.BcdCsvPath;

            if (!File.Exists(filePath))
            {
                MessageBox.Show(
                    "바코드 모델 CSV 파일을 찾을 수 없습니다.\n\n" +
                    "찾는 위치:\n" + filePath + "\n\n" +
                    "PoongSanBCD.csv 파일을 실행 파일(exe)과 같은 폴더에 복사해 주세요.",
                    "파일 없음", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            cboBore.DropDownStyle  = ComboBoxStyle.DropDownList;
            cboBullet.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocal.DropDownStyle  = ComboBoxStyle.DropDownList;

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

            cboBullet.Items.AddRange(bulletList.Cast<object>().ToArray());

            // 복원 중이 아닐 때만 SystemData에 저장
            if (!_isRestoring)
            {
                m_VasimPlatform.m_SystemData.SavedBore   = bore;
                m_VasimPlatform.m_SystemData.SavedBullet = "";
                m_VasimPlatform.m_SystemData.SavedLocal  = "";
                m_VasimPlatform.m_SystemData.Save();
            }

            _isInternalChange = false;
        }

        private void cboBullet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInternalChange || cboBore.SelectedItem == null || cboBullet.SelectedItem == null) return;

            _isInternalChange = true;

            string bore   = cboBore.SelectedItem.ToString();
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

            cboLocal.Items.AddRange(localList.Cast<object>().ToArray());

            // 복원 중이 아닐 때만 SystemData에 저장
            if (!_isRestoring)
            {
                m_VasimPlatform.m_SystemData.SavedBullet = bullet;
                m_VasimPlatform.m_SystemData.SavedLocal  = "";
                m_VasimPlatform.m_SystemData.Save();
            }

            _isInternalChange = false;
        }

        private void cboLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBore.SelectedItem == null || cboBullet.SelectedItem == null || cboLocal.SelectedItem == null) return;

            string bore   = cboBore.SelectedItem.ToString();
            string bullet = cboBullet.SelectedItem.ToString();
            string local  = cboLocal.SelectedItem.ToString();

            var row = _rows.LastOrDefault(r => r.Bore == bore && r.Bullet == bullet && r.Local == local);

            txtCartonBCD.Text = row.CartonBCD;
            txtBoxBCD.Text    = row.BoxBCD;

            // 복원 중이 아닐 때만 SystemData에 저장 (구경/탄종/로컬 모두 완전히 선택된 시점)
            if (!_isRestoring)
            {
                m_VasimPlatform.m_SystemData.SavedBore   = bore;
                m_VasimPlatform.m_SystemData.SavedBullet = bullet;
                m_VasimPlatform.m_SystemData.SavedLocal  = local;
                m_VasimPlatform.m_SystemData.Save();
            }
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

            txtInputBCR.Focus();

            // 추가 -> 타임아웃 타이머 시작 (타임아웃 ON일 때만)
            if (m_VasimPlatform.m_SystemData.TimeoutUse == "true")
            {
                int _tm = 1;
                int.TryParse(m_VasimPlatform.m_SystemData.TimeoutMinutes, out _tm);
                if (_timeoutTimer == null)
                {
                    _timeoutTimer = new System.Timers.Timer();
                    _timeoutTimer.AutoReset = false;
                    _timeoutTimer.Elapsed += new ElapsedEventHandler(TimeoutTimer_Elapsed);
                }
                _timeoutTimer.Stop();
                _timeoutTimer.Interval = _tm * 60.0 * 1000.0;
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
            txtInputBCR.Clear();
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

        // 바코드 자릿수 상수
        private const int CARTON_BCD_LENGTH = 12; // 카톤박스 바코드 자릿수
        private const int BOX_BCD_LENGTH    = 14; // 골판지 바코드 자릿수

        /// <summary>
        /// 기본 바코드 형식 검사 (자릿수 + 숫자 여부)
        ///   12자리 또는 14자리이고, 모두 숫자인 경우만 처리
        ///   → "1", "5555566666" 같은 명백한 잘못된 입력은 무시
        ///   → 12/14자리 숫자는 바코드 형식으로 간주, OK/NG 정상 판정
        /// </summary>
        private bool IsBasicBarcodeFormat(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            if (s.Length != CARTON_BCD_LENGTH && s.Length != BOX_BCD_LENGTH) return false;

            foreach (char c in s)
                if (!char.IsDigit(c)) return false;

            return true;
        }
        private string _barcodeBuffer = string.Empty; // 바코드 리더기 입력 임시 저장

        // 금일 검사 수량 관련 변수 (중복 포함 누적 카운트)
        private int _cartonOkCount = 0;
        private int _cartonNgCount = 0;
        private int _boxOkCount    = 0;
        private int _boxNgCount    = 0;
        private DateTime _lastResetDate = DateTime.MinValue;

        public string ConvertToString(ushort[] data)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            foreach (ushort word in data)
            {
                byte high = (byte)(word >> 8);     // 앞 문자
                byte low = (byte)(word & 0xFF);    // 뒤 문자

                if (high != 0) sb.Append((char)high);
                if (low != 0) sb.Append((char)low);
            }

            return sb.ToString();
        }
        private void txtInputBCR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!bEQStart) { txtInputBCR.Clear(); return; }

                string scanned = txtInputBCR.Text.Trim();
                txtInputBCR.Clear();

                // 12자리 또는 14자리 숫자가 아니면 무시 (잘못된 키보드 입력 차단)
                if (!IsBasicBarcodeFormat(scanned)) return;

                if (scanned.Length == CARTON_BCD_LENGTH)
                {
                    txtInputCartonBCD.Text = scanned;
                    string sPLCData1;

                    if (m_VasimPlatform.m_SystemData.AutoMachineUse == "true")
                    {             
                        try
                        {
                            if (m_VasimPlatform.m_SystemData.melsecplcUse == "true")
                            {
                                m_VasimPlatform.m_mxPlc.Read2WordForwardString(PLCDefine.PLC_Data, PLCDefine.PLC_Data_Length, out sPLCData1);
                            }
                            else
                            {
                                ushort[] data = new ushort[10];
                                m_VasimPlatform.plc_omron.ReadDMs(200, ref data, 10);
                                sPLCData1 = ConvertToString(data);
                            }
                        }
                        catch
                        {
                            AlarmForm.ShowAlarm("PLC 이상 발생.", this);
                            lb_Result.Text = "NG";
                            lb_Result.BackColor = System.Drawing.Color.Red;
                            UpdateCountDisplay();
                            SaveCountToIni();
                            ResetTimeoutTimer();
                            return;
                        }
                        if (cboBore.Text != sPLCData1)
                        //if (cboBore.Text != sPLCData1 || cboBullet.Text != sPLCData2 || cboLocal.Text != sPLCData3)
                        {
                            AlarmForm.ShowAlarm("PLC Data가 불일치 합니다.", this);
                            lb_Result.Text = "NG";
                            lb_Result.BackColor = System.Drawing.Color.Red;
                            UpdateCountDisplay();
                            SaveCountToIni();
                            ResetTimeoutTimer();
                            return;
                        }
                    }

                    string bore   = cboBore.SelectedItem?.ToString()   ?? "";
                    string bullet = cboBullet.SelectedItem?.ToString() ?? "";
                    string local  = cboLocal.SelectedItem?.ToString()  ?? "";

                    bool cartonOk = _rows.Any(r =>
                        r.Bore == bore && r.Bullet == bullet && r.Local == local && r.CartonBCD == scanned);

                    if (cartonOk)
                    {
                        lb_Result.Text = "OK";
                        lb_Result.BackColor = System.Drawing.Color.Green;
                        _cartonOkCount++;
                        SaveToCsv("Carton", txtCartonBCD.Text, scanned, "OK");
                    }
                    else
                    {
                        AlarmForm.ShowAlarm("NG", this);
                        lb_Result.Text = "NG";
                        lb_Result.BackColor = System.Drawing.Color.Red;
                        _cartonNgCount++;
                        SaveToCsv("Carton", txtCartonBCD.Text, scanned, "NG");
                    }
                }
                else if (scanned.Length == BOX_BCD_LENGTH)
                {
                    txtInputBoxBCD.Text = scanned;

                    string bore2   = cboBore.SelectedItem?.ToString()   ?? "";
                    string bullet2 = cboBullet.SelectedItem?.ToString() ?? "";
                    string local2  = cboLocal.SelectedItem?.ToString()  ?? "";

                    bool boxOk = _rows.Any(r =>
                        r.Bore == bore2 && r.Bullet == bullet2 && r.Local == local2 && r.BoxBCD == scanned);

                    if (boxOk)
                    {
                        lb_Result.Text = "OK";
                        lb_Result.BackColor = System.Drawing.Color.Green;
                        _boxOkCount++;
                        SaveToCsv("Box", txtBoxBCD.Text, scanned, "OK");
                    }
                    else
                    {
                        AlarmForm.ShowAlarm("NG", this);
                        lb_Result.Text = "NG";
                        lb_Result.BackColor = System.Drawing.Color.Red;
                        _boxNgCount++;
                        SaveToCsv("Box", txtBoxBCD.Text, scanned, "NG");
                    }
                }
                UpdateCountDisplay();
                SaveCountToIni();
                ResetTimeoutTimer();
            }
        }

        // 타임아웃 설정 변경 시 타이머 인터벌 갱신
        private void ApplyTimeoutSettings()
        {
            int minutes = 1;
            int.TryParse(m_VasimPlatform.m_SystemData.TimeoutMinutes, out minutes);
            double intervalMs = minutes * 60.0 * 1000.0;

            if (m_VasimPlatform.m_SystemData.TimeoutUse == "true")
            {
                if (_timeoutTimer == null)
                {
                    _timeoutTimer = new System.Timers.Timer();
                    _timeoutTimer.AutoReset = false;
                    _timeoutTimer.Elapsed += new ElapsedEventHandler(TimeoutTimer_Elapsed);
                }
                _timeoutTimer.Stop();
                _timeoutTimer.Interval = intervalMs;
                if (bEQStart)
                    _timeoutTimer.Start();
            }
            else
            {
                if (_timeoutTimer != null)
                    _timeoutTimer.Stop();
            }
        }

        // 기존 핸들러 — TimeoutSettingForm 내부에서 직접 처리하므로 빈 상태 유지
        private void btn_TimeoutToggle_Click(object sender, EventArgs e) { }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            using (var form = new SettingsForm(
                onChangePassword: () => btn_ChangePassword_Click(null, null),
                onToggleTimeout:  () => OpenTimeoutSettingForm(),
                onModelSetting:   () => btn_ModelSetting_Click(null, null),
                systemData:       m_VasimPlatform.m_SystemData))
            {
                form.ShowDialog(this);
            }
        }

        private void OpenTimeoutSettingForm()
        {
            using (var form = new TimeoutSettingForm(
                m_VasimPlatform.m_SystemData,
                onSettingChanged: () => ApplyTimeoutSettings()))
            {
                form.ShowDialog(this);
            }
        }

        private void btn_Employee_Click(object sender, EventArgs e)
        {
            OpenEmployeeForm();
        }

        private void OpenEmployeeForm()
        {
            using (var form = new EmployeeForm(m_VasimPlatform.m_SystemData))
            {
                form.ShowDialog(this);
            }
            UpdateEmployeeLabel();
        }

        private void UpdateEmployeeLabel()
        {
            string id = m_VasimPlatform.m_SystemData.CurrentEmployeeId;
            lblCurrentEmployee.Text = string.IsNullOrEmpty(id)
                ? "작업자: 미선택"
                : string.Format("작업자: {0}", id);
        }

        private void cboBore_Click(object sender, EventArgs e) { }

        private void cboBore_MouseDown(object sender, MouseEventArgs e)
        {
            if (bEQStart == true)
            {
                MessageBox.Show("설비 정지바랍니다.");
                return;
            }
            if (ShowPasswordForm())
            {
                cboBore.DroppedDown = true; // 로그인 성공 시 드롭다운 자동으로 열기
            }
        }

        private void cboBullet_Click(object sender, EventArgs e) { }

        private void cboBullet_MouseDown(object sender, MouseEventArgs e)
        {
            if (bEQStart == true)
            {
                MessageBox.Show("설비 정지바랍니다.");
                return;
            }
            if (ShowPasswordForm())
            {
                cboBullet.DroppedDown = true;
            }
        }

        private void cboLocal_Click(object sender, EventArgs e) { }

        private void cboLocal_MouseDown(object sender, MouseEventArgs e)
        {
            if (bEQStart == true)
            {
                MessageBox.Show("설비 정지바랍니다.");
                return;
            }
            if (ShowPasswordForm())
            {
                cboLocal.DroppedDown = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_BUZZER, 0);
        }

        private void lb_MachineName_Click(object sender, EventArgs e)
        {
            // "자동 검사 장비" 영역 클릭으로는 모델 관리에 진입할 수 없습니다.
            // 모델 관리는 "바코드 설정" 버튼을 통해서만 진입 가능합니다.
        }

        private void btn_ModelSetting_Click(object sender, EventArgs e)
        {
            // 설비 동작 중에는 모델 관리 불가
            if (bEQStart == true)
            {
                MessageBox.Show("설비 정지 후 모델 관리를 실행하세요.");
                return;
            }

            // 비밀번호 확인
            if (!ShowPasswordForm()) return;

            // 바코드 설정 화면 열기
            bool dataModified = false;
            using (ModelForm modelForm = new ModelForm(m_VasimPlatform.m_SystemData))
            {
                modelForm.ShowDialog(this);
                dataModified = modelForm.DataModified;
            }

            // 추가/변경/삭제/저장 버튼을 클릭한 경우에만 CSV 재로드 및 콤보박스 초기화
            // (아무것도 하지 않고 닫기만 한 경우 구경/탄종 선택이 유지됨)
            if (dataModified)
            {
                _rows.Clear();
                LoadCsvData();
                InitBoreCombo();
                RestoreSelections();  // 모델 변경 후에도 이전 선택값 복원 시도
            }
        }

        // ── 비밀번호 변경 버튼 (Form1 상단) ──
        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            using (var dlg = new ChangePasswordForm(m_VasimPlatform.m_SystemData))
            {
                dlg.ShowDialog(this);
            }
        }

        // ── 마지막 선택한 구경/탄종/로컬 복원 ──
        private void RestoreSelections()
        {
            string savedBore   = m_VasimPlatform.m_SystemData.SavedBore   ?? "";
            string savedBullet = m_VasimPlatform.m_SystemData.SavedBullet ?? "";
            string savedLocal  = m_VasimPlatform.m_SystemData.SavedLocal  ?? "";

            if (string.IsNullOrEmpty(savedBore)) return;

            _isRestoring = true;
            try
            {
                // 구경 복원 → cboBore_SelectedIndexChanged 발동 → cboBullet 항목 채워짐
                int boreIdx = cboBore.Items.IndexOf(savedBore);
                if (boreIdx < 0) return;
                cboBore.SelectedIndex = boreIdx;

                if (string.IsNullOrEmpty(savedBullet)) return;

                // 탄종 복원 → cboBullet_SelectedIndexChanged 발동 → cboLocal 항목 채워짐
                int bulletIdx = cboBullet.Items.IndexOf(savedBullet);
                if (bulletIdx < 0) return;
                cboBullet.SelectedIndex = bulletIdx;

                if (string.IsNullOrEmpty(savedLocal)) return;

                // 로컬 복원 → cboLocal_SelectedIndexChanged 발동 → BCD 텍스트 자동 세팅
                int localIdx = cboLocal.Items.IndexOf(savedLocal);
                if (localIdx < 0) return;
                cboLocal.SelectedIndex = localIdx;
            }
            finally
            {
                _isRestoring = false;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtInputBCR_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
