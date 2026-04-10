using System;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public partial class TimeoutSettingForm : Form
    {
        private readonly SystemData _systemData;
        private readonly Action     _onSettingChanged;

        // VS Designer용 기본 생성자
        public TimeoutSettingForm()
        {
            InitializeComponent();
        }

        public TimeoutSettingForm(SystemData systemData, Action onSettingChanged)
        {
            _systemData       = systemData;
            _onSettingChanged = onSettingChanged;
            InitializeComponent();
            WireEvents();
            UpdateToggleButton();
            UpdateMinutesLabel();
        }

        private void WireEvents()
        {
            btnToggle.Click     += OnToggleClick;
            btnChangeTime.Click += OnChangeTimeClick;
            btnX.Click          += (s, e) => this.Close();
            btnClose.Click      += (s, e) => this.Close();
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

            using (var keypad = new NumericInputForm("타임아웃 시간 (분)"))
            {
                if (keypad.ShowDialog(this) != DialogResult.OK) return;

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
                btnToggle.Text      = "타임아웃 ON  (클릭하여 OFF)";
                btnToggle.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            }
            else
            {
                btnToggle.Text      = "타임아웃 OFF  (클릭하여 ON)";
                btnToggle.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            }
        }

        private void UpdateMinutesLabel()
        {
            int min = 1;
            int.TryParse(_systemData.TimeoutMinutes, out min);
            lblMinutes.Text = string.Format("{0} 분", min);
        }
    }
}
