using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    /// <summary>
    /// 비밀번호 변경 폼 (3단계: 현재 비밀번호 확인 → 새 비밀번호 입력 → 새 비밀번호 확인)
    /// </summary>
    public class ChangePasswordForm : Form
    {
        private SystemData _systemData;
        private int    _step = 1;          // 1=현재PW 확인, 2=새PW 입력, 3=새PW 확인
        private string _inputPassword = "";
        private string _newPassword   = "";

        public bool PasswordChanged { get; private set; } = false;

        // 동적으로 내용이 바뀌는 컨트롤만 필드 선언
        private Label lblTitle;
        private Label lblStep;
        private Label lblDisplay;

        public ChangePasswordForm(SystemData systemData)
        {
            _systemData = systemData;
            BuildUI();
            UpdateStep();
        }

        // ────────────────────────────────────────────────────────────────────
        // UI 구성 — PasswordForm.Designer.cs 와 완전히 동일한 초기화 순서
        //  SuspendLayout → 컨트롤 생성 → 폼 속성(AutoScale/ClientSize) →
        //  Controls.Add → ResumeLayout(false)
        // ────────────────────────────────────────────────────────────────────
        private void BuildUI()
        {
            // ── 컨트롤 인스턴스 먼저 생성 (Designer 순서 동일) ──
            lblTitle   = new Label();
            lblStep    = new Label();
            lblDisplay = new Label();

            var btn7      = new Button();
            var btn8      = new Button();
            var btn9      = new Button();
            var btn4      = new Button();
            var btn5      = new Button();
            var btn6      = new Button();
            var btn1      = new Button();
            var btn2      = new Button();
            var btn3      = new Button();
            var btn0      = new Button();
            var btnClr    = new Button();
            var btnEnt    = new Button();
            var btnCancel = new Button();

            this.SuspendLayout();   // ← Designer 패턴과 동일

            // ── lblTitle ──
            lblTitle.BackColor = Color.Red;
            lblTitle.Font      = new Font("굴림", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Yellow;
            lblTitle.Location  = new Point(114, 15);
            lblTitle.Margin    = new Padding(4, 0, 4, 0);
            lblTitle.Size      = new Size(286, 75);
            lblTitle.Text      = "비밀번호 변경";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // ── lblStep (Password 레이블과 같은 위치) ──
            lblStep.BackColor = Color.FromArgb(51, 51, 56);
            lblStep.Font      = new Font("굴림", 12F, FontStyle.Bold);
            lblStep.ForeColor = Color.White;
            lblStep.Location  = new Point(29, 105);
            lblStep.Margin    = new Padding(4, 0, 4, 0);
            lblStep.Size      = new Size(143, 52);
            lblStep.Text      = "1 / 3 단계";
            lblStep.TextAlign = ContentAlignment.MiddleCenter;

            // ── lblDisplay ──
            lblDisplay.BackColor   = Color.Black;
            lblDisplay.BorderStyle = BorderStyle.FixedSingle;
            lblDisplay.Font        = new Font("굴림", 18F, FontStyle.Bold);
            lblDisplay.ForeColor   = Color.White;
            lblDisplay.Location    = new Point(179, 105);
            lblDisplay.Margin      = new Padding(4, 0, 4, 0);
            lblDisplay.Size        = new Size(328, 52);
            lblDisplay.TextAlign   = ContentAlignment.MiddleCenter;

            // ── 숫자 버튼 공통 설정 헬퍼 ──
            void SetNumBtn(Button b, string text, Point loc, int tabIdx)
            {
                b.BackColor            = Color.White;
                b.FlatStyle            = FlatStyle.Flat;
                b.Font                 = new Font("굴림", 18F, FontStyle.Bold);
                b.ForeColor            = Color.Black;
                b.Location             = loc;
                b.Margin               = new Padding(4);
                b.Size                 = new Size(114, 105);
                b.TabIndex             = tabIdx;
                b.Text                 = text;
                b.UseVisualStyleBackColor = false;
                b.Click += (s, e) => { _inputPassword += text; UpdateDisplay(); };
            }

            SetNumBtn(btn7, "7", new Point( 29, 172),  3);
            SetNumBtn(btn8, "8", new Point(150, 172),  4);
            SetNumBtn(btn9, "9", new Point(271, 172),  5);
            SetNumBtn(btn4, "4", new Point( 29, 285),  7);
            SetNumBtn(btn5, "5", new Point(150, 285),  8);
            SetNumBtn(btn6, "6", new Point(271, 285),  9);
            SetNumBtn(btn1, "1", new Point( 29, 398), 11);
            SetNumBtn(btn2, "2", new Point(150, 398), 12);
            SetNumBtn(btn3, "3", new Point(271, 398), 13);
            SetNumBtn(btn0, "0", new Point( 29, 510), 15);

            // ── CLR ──
            btnClr.BackColor            = Color.White;
            btnClr.FlatStyle            = FlatStyle.Flat;
            btnClr.Font                 = new Font("굴림", 18F, FontStyle.Bold);
            btnClr.ForeColor            = Color.Black;
            btnClr.Location             = new Point(150, 510);
            btnClr.Margin               = new Padding(4);
            btnClr.Size                 = new Size(236, 105);
            btnClr.TabIndex             = 16;
            btnClr.Text                 = "CLR";
            btnClr.UseVisualStyleBackColor = false;
            btnClr.Click += (s, e) => { _inputPassword = ""; UpdateDisplay(); };

            // ── ENT ──
            btnEnt.BackColor            = Color.White;
            btnEnt.FlatStyle            = FlatStyle.Flat;
            btnEnt.Font                 = new Font("굴림", 18F, FontStyle.Bold);
            btnEnt.ForeColor            = Color.Black;
            btnEnt.Location             = new Point(393, 172);
            btnEnt.Margin               = new Padding(4);
            btnEnt.Size                 = new Size(114, 443);
            btnEnt.TabIndex             = 6;
            btnEnt.Text                 = "ENT";
            btnEnt.UseVisualStyleBackColor = false;
            btnEnt.Click += btn_Ent_Click;

            // ── 취소 (PasswordForm.btn_Cancel 과 동일 위치·크기) ──
            btnCancel.BackColor            = Color.Gray;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle            = FlatStyle.Flat;
            btnCancel.Font                 = new Font("굴림", 14F, FontStyle.Bold);
            btnCancel.ForeColor            = Color.White;
            btnCancel.Location             = new Point(279, 638);
            btnCancel.Margin               = new Padding(4);
            btnCancel.Size                 = new Size(229, 82);
            btnCancel.TabIndex             = 18;
            btnCancel.Text                 = "취소";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += (s, e) => { PasswordChanged = false; this.Close(); };

            // ── 폼 속성 — Designer 와 동일하게 AutoScale → ClientSize 순서 ──
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = Color.FromArgb(51, 51, 56);
            this.ClientSize          = new Size(536, 742);
            this.FormBorderStyle     = FormBorderStyle.None;
            this.Margin              = new Padding(4);
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.StartPosition       = FormStartPosition.CenterScreen;
            this.TopMost             = true;

            // ── Controls.Add — Designer 와 동일하게 폼 속성 이후에 추가 ──
            this.Controls.Add(btnCancel);
            this.Controls.Add(btnClr);
            this.Controls.Add(btn0);
            this.Controls.Add(btnEnt);
            this.Controls.Add(btn3);
            this.Controls.Add(btn2);
            this.Controls.Add(btn1);
            this.Controls.Add(btn6);
            this.Controls.Add(btn5);
            this.Controls.Add(btn4);
            this.Controls.Add(btn9);
            this.Controls.Add(btn8);
            this.Controls.Add(btn7);
            this.Controls.Add(lblDisplay);
            this.Controls.Add(lblStep);
            this.Controls.Add(lblTitle);

            this.ResumeLayout(false);   // ← Designer 패턴과 동일 (PerformLayout 없음)
        }

        // ────────────────────────────────────────────
        // 단계별 타이틀 / 단계 표시 업데이트
        // ────────────────────────────────────────────
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

        // ────────────────────────────────────────────
        // ENT 클릭 — 3단계 처리
        // ────────────────────────────────────────────
        private void btn_Ent_Click(object sender, EventArgs e)
        {
            switch (_step)
            {
                // ─── 1단계: 현재 비밀번호 확인 ───
                case 1:
                    if (_inputPassword == _systemData.LoginPassword)
                    {
                        _step = 2;
                        UpdateStep();
                    }
                    else
                    {
                        lblDisplay.Text      = "비밀번호 오류!";
                        lblDisplay.ForeColor = Color.Red;
                        _inputPassword       = "";
                    }
                    break;

                // ─── 2단계: 새 비밀번호 저장 ───
                case 2:
                    if (string.IsNullOrEmpty(_inputPassword))
                    {
                        lblDisplay.Text      = "입력하세요";
                        lblDisplay.ForeColor = Color.Red;
                        return;
                    }
                    _newPassword = _inputPassword;
                    _step = 3;
                    UpdateStep();
                    break;

                // ─── 3단계: 새 비밀번호 일치 확인 ───
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

        // ────────────────────────────────────────────
        // 입력 표시 (*) 업데이트
        // ────────────────────────────────────────────
        private void UpdateDisplay()
        {
            lblDisplay.ForeColor = Color.White;
            lblDisplay.Text      = new string('*', _inputPassword.Length);
        }
    }
}
