using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public class TimeoutSettingForm : Form
    {
        private readonly SystemData _systemData;
        private readonly Action     _onSettingChanged;
        private Button _btnToggle;
        private Label  _lblMinutes;

        public TimeoutSettingForm(SystemData systemData, Action onSettingChanged)
        {
            _systemData       = systemData;
            _onSettingChanged = onSettingChanged;
            BuildUI();
        }

        private void BuildUI()
        {
            this.Text            = "타임아웃 설정";
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor       = Color.FromArgb(51, 51, 56);
            this.Size            = new Size(560, 430);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.TopMost         = true;

            // 타이틀
            var lblTitle = new Label
            {
                Text      = "타임아웃 설정",
                Font      = new Font("굴림", 20F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(51, 51, 56),
                Size      = new Size(520, 54),
                Location  = new Point(20, 14),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // 구분선 느낌의 레이블
            var lblStatusHeader = new Label
            {
                Text      = "현재 상태",
                Font      = new Font("굴림", 13F),
                ForeColor = Color.FromArgb(180, 180, 180),
                BackColor = Color.FromArgb(51, 51, 56),
                Size      = new Size(520, 28),
                Location  = new Point(20, 80),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // ON/OFF 토글 버튼
            _btnToggle = new Button
            {
                Font      = new Font("굴림", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                Size      = new Size(520, 80),
                Location  = new Point(20, 108),
                FlatStyle = FlatStyle.Flat
            };
            _btnToggle.FlatAppearance.BorderSize = 0;
            UpdateToggleButton();
            _btnToggle.Click += OnToggleClick;

            // 설정 시간 헤더
            var lblTimeHeader = new Label
            {
                Text      = "설정 시간",
                Font      = new Font("굴림", 13F),
                ForeColor = Color.FromArgb(180, 180, 180),
                BackColor = Color.FromArgb(51, 51, 56),
                Size      = new Size(520, 28),
                Location  = new Point(20, 208),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // 현재 설정 시간 표시
            _lblMinutes = new Label
            {
                Font        = new Font("굴림", 22F, FontStyle.Bold),
                ForeColor   = Color.White,
                BackColor   = Color.FromArgb(40, 40, 45),
                Size        = new Size(310, 80),
                Location    = new Point(20, 238),
                TextAlign   = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle
            };
            UpdateMinutesLabel();

            // 시간 변경 버튼
            var btnChangeTime = new Button
            {
                Text      = "시간 변경",
                Font      = new Font("굴림", 15F, FontStyle.Bold),
                BackColor = Color.FromArgb(41, 128, 185),
                ForeColor = Color.White,
                Size      = new Size(190, 80),
                Location  = new Point(350, 238),
                FlatStyle = FlatStyle.Flat
            };
            btnChangeTime.FlatAppearance.BorderSize = 0;
            btnChangeTime.Click += OnChangeTimeClick;

            // 우상단 X
            var btnX = new Button
            {
                Text      = "✕",
                Font      = new Font("굴림", 12F, FontStyle.Bold),
                BackColor = Color.FromArgb(51, 51, 56),
                ForeColor = Color.White,
                Size      = new Size(40, 30),
                Location  = new Point(510, 5),
                FlatStyle = FlatStyle.Flat
            };
            btnX.FlatAppearance.BorderSize = 0;
            btnX.Click += (s, e) => this.Close();

            // 닫기
            var btnClose = new Button
            {
                Text      = "닫  기",
                Font      = new Font("굴림", 15F, FontStyle.Bold),
                BackColor = Color.FromArgb(100, 100, 110),
                ForeColor = Color.White,
                Size      = new Size(160, 54),
                Location  = new Point(380, 360),
                FlatStyle = FlatStyle.Flat
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblStatusHeader);
            this.Controls.Add(_btnToggle);
            this.Controls.Add(lblTimeHeader);
            this.Controls.Add(_lblMinutes);
            this.Controls.Add(btnChangeTime);
            this.Controls.Add(btnX);
            this.Controls.Add(btnClose);
        }

        private bool Authenticate()
        {
            using (var pw = new PasswordForm(_systemData.LoginPassword))
            {
                pw.ShowDialog(this);
                return pw.IsAuthenticated;
            }
        }

        private void OnToggleClick(object sender, EventArgs e)
        {
            if (!Authenticate()) return;

            _systemData.TimeoutUse = _systemData.TimeoutUse == "true" ? "false" : "true";
            _systemData.Save();
            UpdateToggleButton();
            _onSettingChanged?.Invoke();
        }

        private void OnChangeTimeClick(object sender, EventArgs e)
        {
            if (!Authenticate()) return;

            using (var keypad = new InputKeypadForm("타임아웃 시간 (분)"))
            {
                if (keypad.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;

                string input = keypad.InputText.Trim();
                int minutes;
                if (!int.TryParse(input, out minutes) || minutes < 1 || minutes > 99)
                {
                    MessageBox.Show("1~99 사이의 숫자를 입력하세요.", "입력 오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _systemData.TimeoutMinutes = minutes.ToString();
                _systemData.Save();
                UpdateMinutesLabel();
                _onSettingChanged?.Invoke();
            }
        }

        private void UpdateToggleButton()
        {
            if (_systemData.TimeoutUse == "true")
            {
                _btnToggle.Text      = "타임아웃 ON  (클릭하여 OFF)";
                _btnToggle.BackColor = Color.FromArgb(39, 174, 96);
            }
            else
            {
                _btnToggle.Text      = "타임아웃 OFF  (클릭하여 ON)";
                _btnToggle.BackColor = Color.FromArgb(127, 140, 141);
            }
        }

        private void UpdateMinutesLabel()
        {
            int min = 1;
            int.TryParse(_systemData.TimeoutMinutes, out min);
            _lblMinutes.Text = string.Format("{0} 분", min);
        }
    }
}
