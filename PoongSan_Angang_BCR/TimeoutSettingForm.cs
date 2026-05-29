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
            UpdateTimeDisplay();
        }

        private void WireEvents()
        {
            btnToggle.Click   += OnToggleClick;
            btnHourDown.Click += (s, e) => AdjustTime(-60);
            btnHourUp.Click   += (s, e) => AdjustTime(+60);
            btnMinDown.Click  += (s, e) => AdjustTime(-1);
            btnMinUp.Click    += (s, e) => AdjustTime(+1);
            lblHour.Click     += OnHourLabelClick;
            lblMin.Click      += OnMinLabelClick;
            btnClose.Click    += (s, e) => this.Close();
        }

        private void OnToggleClick(object sender, EventArgs e)
        {
            _systemData.TimeoutUse = _systemData.TimeoutUse == "true" ? "false" : "true";
            _systemData.Save();
            UpdateToggleButton();
            _onSettingChanged?.Invoke();
        }

        private void OnHourLabelClick(object sender, EventArgs e)
        {
            int current;
            if (!int.TryParse(_systemData.TimeoutMinutes, out current)) current = 1;
            int currentHour = current / 60;
            int currentMin  = current % 60;

            using (var keypad = new NumericInputForm("시간 입력"))
            {
                if (keypad.ShowDialog(this) != DialogResult.OK) return;
                int h;
                if (!int.TryParse(keypad.InputText.Trim(), out h) || h < 0)
                {
                    MessageBox.Show("0 이상의 숫자를 입력하세요.", "입력 오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int next = h * 60 + currentMin;
                if (next < 1) next = 1;   // 0시간 0분 방지
                _systemData.TimeoutMinutes = next.ToString();
                _systemData.Save();
                UpdateTimeDisplay();
                _onSettingChanged?.Invoke();
            }
        }

        private void OnMinLabelClick(object sender, EventArgs e)
        {
            int current;
            if (!int.TryParse(_systemData.TimeoutMinutes, out current)) current = 1;
            int currentHour = current / 60;

            using (var keypad = new NumericInputForm("분 입력 (0~59)"))
            {
                if (keypad.ShowDialog(this) != DialogResult.OK) return;
                int m;
                if (!int.TryParse(keypad.InputText.Trim(), out m) || m < 0 || m > 59)
                {
                    MessageBox.Show("0~59 사이의 숫자를 입력하세요.", "입력 오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int next = currentHour * 60 + m;
                if (next < 1) next = 1;   // 0시간 0분 방지
                _systemData.TimeoutMinutes = next.ToString();
                _systemData.Save();
                UpdateTimeDisplay();
                _onSettingChanged?.Invoke();
            }
        }

        private void AdjustTime(int deltaMinutes)
        {
            int current;
            if (!int.TryParse(_systemData.TimeoutMinutes, out current)) current = 1;

            int next = current + deltaMinutes;
            if (next < 1)   next = 1;
            if (next > 99999) next = 99999;

            if (next == current) return;

            _systemData.TimeoutMinutes = next.ToString();
            _systemData.Save();
            UpdateTimeDisplay();
            _onSettingChanged?.Invoke();
        }

        private void UpdateToggleButton()
        {
            if (_systemData.TimeoutUse == "true")
            {
                btnToggle.Text      = "타임아웃 ON  (터치하여 OFF)";
                btnToggle.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            }
            else
            {
                btnToggle.Text      = "타임아웃 OFF  (터치하여 ON)";
                btnToggle.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            }
        }

        private void UpdateTimeDisplay()
        {
            if (_systemData == null) return;
            int total;
            if (!int.TryParse(_systemData.TimeoutMinutes, out total)) total = 1;
            lblHour.Text = (total / 60).ToString();
            lblMin.Text  = (total % 60).ToString();
        }
    }
}
