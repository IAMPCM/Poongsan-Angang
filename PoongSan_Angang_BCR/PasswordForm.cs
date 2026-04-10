using System;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public partial class PasswordForm : Form
    {
        public bool IsAuthenticated { get; private set; } = false;
        private string _correctPassword;
        private string _inputPassword = "";

        public PasswordForm(string correctPassword)
        {
            InitializeComponent();
            _correctPassword = correctPassword;
            UpdateDisplay();

            // 확인 버튼만 비활성화 (ENT 누른 후 활성화)
            // CLOSE 버튼은 항상 활성화 — 비밀번호 미입력 시에도 닫기 가능
            btn_Confirm.Enabled = false;
            btn_Confirm.BackColor = System.Drawing.Color.Gray;
            btn_Cancel.Enabled = true;
            btn_Cancel.BackColor = System.Drawing.Color.FromArgb(70, 70, 75);
        }

        // 숫자 버튼 클릭 시 호출
        private void NumButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _inputPassword += btn.Text;
            UpdateDisplay();
        }

        // 지우기 버튼 (한 글자 삭제)
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (_inputPassword.Length > 0)
            {
                _inputPassword = _inputPassword.Substring(0, _inputPassword.Length - 1);
                UpdateDisplay();
            }
        }

        // CLR 버튼 (전체 지우기)
        private void btn_Clr_Click(object sender, EventArgs e)
        {
            _inputPassword = "";
            UpdateDisplay();
        }

        // ENT 버튼 (E, N, T 모두 확인 동작)
        private void btn_Ent_Click(object sender, EventArgs e)
        {
            // ENT 누르면 확인/CLOSE 버튼 활성화
            btn_Confirm.Enabled = true;
            btn_Cancel.Enabled = true;
            btn_Confirm.BackColor = System.Drawing.Color.FromArgb(70, 70, 75);
            btn_Cancel.BackColor = System.Drawing.Color.FromArgb(70, 70, 75);
        }

        // 확인 버튼
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (_inputPassword == _correctPassword)
            {
                IsAuthenticated = true;
                this.Close();
            }
            else
            {
                lblDisplay.Text = "비밀번호 오류!";
                lblDisplay.ForeColor = System.Drawing.Color.Red;
                _inputPassword = "";
            }
        }

        // 취소 버튼
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            IsAuthenticated = false;
            this.Close();
        }

        // 입력 표시 업데이트 (* 로 표시)
        private void UpdateDisplay()
        {
            lblDisplay.ForeColor = System.Drawing.Color.White;
            lblDisplay.Text = new string('*', _inputPassword.Length);
        }

        private void PasswordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
