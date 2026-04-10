using System;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public partial class ChangePasswordForm : Form
    {
        private SystemData _systemData;
        private int    _step = 1;
        private string _inputPassword = "";
        private string _newPassword   = "";

        public bool PasswordChanged { get; private set; } = false;

        // VS Designer용 기본 생성자
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        public ChangePasswordForm(SystemData systemData)
        {
            _systemData = systemData;
            InitializeComponent();
            WireEvents();
            UpdateStep();
        }

        private void WireEvents()
        {
            btn7.Click      += (s, e) => { _inputPassword += "7"; UpdateDisplay(); };
            btn8.Click      += (s, e) => { _inputPassword += "8"; UpdateDisplay(); };
            btn9.Click      += (s, e) => { _inputPassword += "9"; UpdateDisplay(); };
            btn4.Click      += (s, e) => { _inputPassword += "4"; UpdateDisplay(); };
            btn5.Click      += (s, e) => { _inputPassword += "5"; UpdateDisplay(); };
            btn6.Click      += (s, e) => { _inputPassword += "6"; UpdateDisplay(); };
            btn1.Click      += (s, e) => { _inputPassword += "1"; UpdateDisplay(); };
            btn2.Click      += (s, e) => { _inputPassword += "2"; UpdateDisplay(); };
            btn3.Click      += (s, e) => { _inputPassword += "3"; UpdateDisplay(); };
            btn0.Click      += (s, e) => { _inputPassword += "0"; UpdateDisplay(); };
            btnClr.Click    += (s, e) => { _inputPassword = ""; UpdateDisplay(); };
            btnEnt.Click    += btn_Ent_Click;
            btnCancel.Click += (s, e) => { PasswordChanged = false; this.Close(); };
        }

        private void UpdateStep()
        {
            _inputPassword = "";
            switch (_step)
            {
                case 1:
                    lblTitle.Text = "현재 비밀번호 입력";
                    lblStep.Text  = "1 / 3 단계";
                    break;
                case 2:
                    lblTitle.Text = "새 비밀번호 입력";
                    lblStep.Text  = "2 / 3 단계";
                    break;
                case 3:
                    lblTitle.Text = "새 비밀번호 확인";
                    lblStep.Text  = "3 / 3 단계";
                    break;
            }
            UpdateDisplay();
        }

        private void btn_Ent_Click(object sender, EventArgs e)
        {
            switch (_step)
            {
                case 1:
                    if (_inputPassword == _systemData.LoginPassword)
                    {
                        _step = 2;
                        UpdateStep();
                    }
                    else
                    {
                        lblDisplay.Text      = "비밀번호 오류!";
                        lblDisplay.ForeColor = System.Drawing.Color.Red;
                        _inputPassword       = "";
                    }
                    break;

                case 2:
                    if (string.IsNullOrEmpty(_inputPassword))
                    {
                        lblDisplay.Text      = "입력하세요";
                        lblDisplay.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    _newPassword = _inputPassword;
                    _step = 3;
                    UpdateStep();
                    break;

                case 3:
                    if (_inputPassword == _newPassword)
                    {
                        _systemData.LoginPassword = _newPassword;
                        _systemData.Save();
                        PasswordChanged = true;
                        MessageBox.Show("비밀번호가 변경되었습니다.", "완료",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(
                            "비밀번호가 일치하지 않습니다.\n새 비밀번호를 다시 입력해 주세요.",
                            "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _newPassword = "";
                        _step = 2;
                        UpdateStep();
                    }
                    break;
            }
        }

        private void UpdateDisplay()
        {
            lblDisplay.ForeColor = System.Drawing.Color.White;
            lblDisplay.Text      = new string('*', _inputPassword.Length);
        }
    }
}
