using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public class SettingsForm : Form
    {
        private readonly Action _onChangePassword;
        private readonly Action _onToggleTimeout;
        private readonly Action _onModelSetting;
        private readonly SystemData _systemData;
        private Button _btnTimeout;

        public SettingsForm(Action onChangePassword, Action onToggleTimeout, Action onModelSetting, SystemData systemData)
        {
            _onChangePassword = onChangePassword;
            _onToggleTimeout  = onToggleTimeout;
            _onModelSetting   = onModelSetting;
            _systemData       = systemData;
            BuildUI();
        }

        private void BuildUI()
        {
            this.Text            = "설정";
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor       = Color.FromArgb(51, 51, 56);
            this.Size            = new Size(400, 330);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.TopMost         = true;

            // 타이틀
            var lblTitle = new Label
            {
                Text      = "설  정",
                Font      = new Font("굴림", 18F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(51, 51, 56),
                Size      = new Size(360, 50),
                Location  = new Point(20, 15),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // 비밀번호 변경
            var btnChangePassword = new Button
            {
                Text      = "비밀번호 변경",
                Font      = new Font("굴림", 14F, FontStyle.Bold),
                BackColor = Color.White,
                ForeColor = Color.Black,
                Size      = new Size(360, 60),
                Location  = new Point(20, 75),
                FlatStyle = FlatStyle.Flat
            };
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.Click += (s, e) => { _onChangePassword(); };

            // 타임아웃 토글
            _btnTimeout = new Button
            {
                Font      = new Font("굴림", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                Size      = new Size(360, 60),
                Location  = new Point(20, 145),
                FlatStyle = FlatStyle.Flat
            };
            _btnTimeout.FlatAppearance.BorderSize = 0;
            UpdateTimeoutButton();
            _btnTimeout.Click += (s, e) => { _onToggleTimeout(); UpdateTimeoutButton(); };

            // 바코드 설정
            var btnModelSetting = new Button
            {
                Text      = "바코드 설정",
                Font      = new Font("굴림", 14F, FontStyle.Bold),
                BackColor = Color.White,
                ForeColor = Color.Black,
                Size      = new Size(360, 60),
                Location  = new Point(20, 215),
                FlatStyle = FlatStyle.Flat
            };
            btnModelSetting.FlatAppearance.BorderSize = 0;
            btnModelSetting.Click += (s, e) => { _onModelSetting(); this.Close(); };

            // 닫기
            var btnClose = new Button
            {
                Text      = "✕",
                Font      = new Font("굴림", 12F, FontStyle.Bold),
                BackColor = Color.FromArgb(51, 51, 56),
                ForeColor = Color.White,
                Size      = new Size(40, 30),
                Location  = new Point(350, 5),
                FlatStyle = FlatStyle.Flat
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(lblTitle);
            this.Controls.Add(btnChangePassword);
            this.Controls.Add(_btnTimeout);
            this.Controls.Add(btnModelSetting);
            this.Controls.Add(btnClose);
        }

        private void UpdateTimeoutButton()
        {
            if (_systemData.TimeoutUse == "true")
            {
                _btnTimeout.Text      = "타임아웃 ON";
                _btnTimeout.BackColor = Color.Green;
            }
            else
            {
                _btnTimeout.Text      = "타임아웃 OFF";
                _btnTimeout.BackColor = Color.Gray;
            }
        }
    }
}
