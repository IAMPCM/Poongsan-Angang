using System;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public partial class SettingsForm : Form
    {
        private readonly Action _onChangePassword;
        private readonly Action _onToggleTimeout;
        private readonly Action _onModelSetting;
        private readonly Action _onPlcSetting;

        // VS Designer용 기본 생성자
        public SettingsForm()
        {
            InitializeComponent();
        }

        public SettingsForm(Action onChangePassword, Action onToggleTimeout,
                            Action onModelSetting, Action onPlcSetting, SystemData systemData)
        {
            _onChangePassword = onChangePassword;
            _onToggleTimeout  = onToggleTimeout;
            _onModelSetting   = onModelSetting;
            _onPlcSetting     = onPlcSetting;
            InitializeComponent();
            WireEvents();
        }

        private void WireEvents()
        {
            btnChangePassword.Click += (s, e) => _onChangePassword?.Invoke();
            btnTimeout.Click        += (s, e) => _onToggleTimeout?.Invoke();
            btnModelSetting.Click   += (s, e) => _onModelSetting?.Invoke();
            btnPlcSetting.Click     += (s, e) => _onPlcSetting?.Invoke();
            btnClose.Click          += (s, e) => this.Close();
        }
    }
}
