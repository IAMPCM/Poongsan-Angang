using System;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public partial class PlcSettingForm : Form
    {
        private readonly SystemData _systemData;
        private readonly Action     _onPollingToggle;

        public PlcSettingForm()
        {
            InitializeComponent();
        }

        public PlcSettingForm(SystemData systemData, Action onPollingToggle = null)
        {
            _systemData      = systemData;
            _onPollingToggle = onPollingToggle;
            InitializeComponent();
            WireEvents();
            LoadValues();
        }

        private void WireEvents()
        {
            lblPollVal.Click       += (s, e) => EditPoll();
            lblAddrVal1.Click      += (s, e) => EditAddress(1);
            lblAddrVal2.Click      += (s, e) => EditAddress(2);
            lblAddrVal3.Click      += (s, e) => EditAddress(3);
            lblAddrVal4.Click      += (s, e) => EditAddress(4);
            btnPollingToggle.Click += OnPollingToggleClick;
            btnClose.Click         += (s, e) => this.Close();
        }

        private void LoadValues()
        {
            lblPollVal.Text  = _systemData.WeightPollSeconds ?? "30";
            lblAddrVal1.Text = string.IsNullOrEmpty(_systemData.WeightPlcAddress1) ? "-" : _systemData.WeightPlcAddress1;
            lblAddrVal2.Text = string.IsNullOrEmpty(_systemData.WeightPlcAddress2) ? "-" : _systemData.WeightPlcAddress2;
            lblAddrVal3.Text = string.IsNullOrEmpty(_systemData.WeightPlcAddress3) ? "-" : _systemData.WeightPlcAddress3;
            lblAddrVal4.Text = string.IsNullOrEmpty(_systemData.WeightPlcAddress4) ? "-" : _systemData.WeightPlcAddress4;
            UpdatePollingToggleButton();
        }

        private void UpdatePollingToggleButton()
        {
            bool enabled = (_systemData?.WeightPollingEnabled ?? "true") == "true";
            btnPollingToggle.Text      = enabled ? "PLC 중량 체크 ON" : "PLC 중량 체크 OFF";
            btnPollingToggle.BackColor = enabled
                ? System.Drawing.Color.FromArgb(39, 174, 96)
                : System.Drawing.Color.FromArgb(127, 140, 141);
        }

        private void OnPollingToggleClick(object sender, EventArgs e)
        {
            _onPollingToggle?.Invoke();
            UpdatePollingToggleButton();
        }

        private void EditPoll()
        {
            using (var kpd = new NumericInputForm("폴링 주기(초, 1~999)", lblPollVal.Text))
            {
                if (kpd.ShowDialog(this) != DialogResult.OK) return;
                int v;
                if (!int.TryParse(kpd.InputText.Trim(), out v) || v < 1 || v > 999)
                {
                    MessageBox.Show("1 ~ 999 사이의 숫자를 입력하세요.", "입력 오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                lblPollVal.Text               = v.ToString();
                _systemData.WeightPollSeconds = lblPollVal.Text;
                _systemData.Save();
            }
        }

        private void EditAddress(int idx)
        {
            string current;
            switch (idx)
            {
                case 1: current = _systemData.WeightPlcAddress1; break;
                case 2: current = _systemData.WeightPlcAddress2; break;
                case 3: current = _systemData.WeightPlcAddress3; break;
                default: current = _systemData.WeightPlcAddress4; break;
            }

            using (var kpd = new InputKeypadForm($"{idx}번 탄 PLC 주소", current ?? ""))
            {
                if (kpd.ShowDialog(this) != DialogResult.OK) return;

                string val = kpd.InputText.Trim().ToUpper(); // 예: "D1000"

                System.Windows.Forms.Label lbl;
                switch (idx)
                {
                    case 1: _systemData.WeightPlcAddress1 = val; lbl = lblAddrVal1; break;
                    case 2: _systemData.WeightPlcAddress2 = val; lbl = lblAddrVal2; break;
                    case 3: _systemData.WeightPlcAddress3 = val; lbl = lblAddrVal3; break;
                    default: _systemData.WeightPlcAddress4 = val; lbl = lblAddrVal4; break;
                }
                lbl.Text = string.IsNullOrEmpty(val) ? "-" : val;
                _systemData.Save();
            }
        }
    }
}
