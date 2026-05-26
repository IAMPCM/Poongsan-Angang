namespace PoongSan_Angang_BCR
{
    partial class PlcSettingForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle         = new System.Windows.Forms.Label();
            this.lblPollHdr       = new System.Windows.Forms.Label();
            this.lblPollVal       = new System.Windows.Forms.Label();
            this.lblAddrHdr1      = new System.Windows.Forms.Label();
            this.lblAddrVal1      = new System.Windows.Forms.Label();
            this.lblAddrHdr2      = new System.Windows.Forms.Label();
            this.lblAddrVal2      = new System.Windows.Forms.Label();
            this.lblAddrHdr3      = new System.Windows.Forms.Label();
            this.lblAddrVal3      = new System.Windows.Forms.Label();
            this.lblAddrHdr4      = new System.Windows.Forms.Label();
            this.lblAddrVal4      = new System.Windows.Forms.Label();
            this.btnPollingToggle = new System.Windows.Forms.Button();
            this.btnClose         = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // ── 타이틀 ────────────────────────────────────────────────────
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTitle.Font      = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(20, 14);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Size      = new System.Drawing.Size(400, 54);
            this.lblTitle.TabIndex  = 20;
            this.lblTitle.Text      = "PLC 설정";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── 행 1: 폴링 주기 (y=84) ───────────────────────────────────
            this.lblPollHdr.BackColor  = System.Drawing.Color.FromArgb(240, 244, 248);
            this.lblPollHdr.Font       = new System.Drawing.Font("굴림", 12F);
            this.lblPollHdr.ForeColor  = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblPollHdr.Location   = new System.Drawing.Point(20, 90);
            this.lblPollHdr.Name       = "lblPollHdr";
            this.lblPollHdr.Size       = new System.Drawing.Size(210, 54);
            this.lblPollHdr.TabIndex   = 15;
            this.lblPollHdr.Text       = "PLC 중량 체크 주기\n(초, 1~999)";
            this.lblPollHdr.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblPollVal.BackColor   = System.Drawing.Color.White;
            this.lblPollVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPollVal.Cursor      = System.Windows.Forms.Cursors.Hand;
            this.lblPollVal.Font        = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.lblPollVal.ForeColor   = System.Drawing.Color.FromArgb(31, 97, 141);
            this.lblPollVal.Location    = new System.Drawing.Point(248, 84);
            this.lblPollVal.Name        = "lblPollVal";
            this.lblPollVal.Size        = new System.Drawing.Size(172, 52);
            this.lblPollVal.TabIndex    = 14;
            this.lblPollVal.Text        = "30";
            this.lblPollVal.TextAlign   = System.Drawing.ContentAlignment.MiddleCenter;

            // ── 행 2: 1번 탄 중량 주소 (y=154) ───────────────────────────
            this.lblAddrHdr1.BackColor  = System.Drawing.Color.FromArgb(240, 244, 248);
            this.lblAddrHdr1.Font       = new System.Drawing.Font("굴림", 12F);
            this.lblAddrHdr1.ForeColor  = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblAddrHdr1.Location   = new System.Drawing.Point(20, 154);
            this.lblAddrHdr1.Name       = "lblAddrHdr1";
            this.lblAddrHdr1.Size       = new System.Drawing.Size(210, 54);
            this.lblAddrHdr1.TabIndex   = 13;
            this.lblAddrHdr1.Text       = "1번 탄 중량 주소";
            this.lblAddrHdr1.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblAddrVal1.BackColor   = System.Drawing.Color.White;
            this.lblAddrVal1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAddrVal1.Cursor      = System.Windows.Forms.Cursors.Hand;
            this.lblAddrVal1.Font        = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.lblAddrVal1.ForeColor   = System.Drawing.Color.FromArgb(31, 97, 141);
            this.lblAddrVal1.Location    = new System.Drawing.Point(248, 154);
            this.lblAddrVal1.Name        = "lblAddrVal1";
            this.lblAddrVal1.Size        = new System.Drawing.Size(172, 52);
            this.lblAddrVal1.TabIndex    = 12;
            this.lblAddrVal1.Text        = "-";
            this.lblAddrVal1.TextAlign   = System.Drawing.ContentAlignment.MiddleCenter;

            // ── 행 3: 2번 탄 중량 주소 (y=218) ───────────────────────────
            this.lblAddrHdr2.BackColor  = System.Drawing.Color.FromArgb(240, 244, 248);
            this.lblAddrHdr2.Font       = new System.Drawing.Font("굴림", 12F);
            this.lblAddrHdr2.ForeColor  = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblAddrHdr2.Location   = new System.Drawing.Point(20, 218);
            this.lblAddrHdr2.Name       = "lblAddrHdr2";
            this.lblAddrHdr2.Size       = new System.Drawing.Size(210, 54);
            this.lblAddrHdr2.TabIndex   = 11;
            this.lblAddrHdr2.Text       = "2번 탄 중량 주소";
            this.lblAddrHdr2.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblAddrVal2.BackColor   = System.Drawing.Color.White;
            this.lblAddrVal2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAddrVal2.Cursor      = System.Windows.Forms.Cursors.Hand;
            this.lblAddrVal2.Font        = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.lblAddrVal2.ForeColor   = System.Drawing.Color.FromArgb(31, 97, 141);
            this.lblAddrVal2.Location    = new System.Drawing.Point(248, 218);
            this.lblAddrVal2.Name        = "lblAddrVal2";
            this.lblAddrVal2.Size        = new System.Drawing.Size(172, 52);
            this.lblAddrVal2.TabIndex    = 10;
            this.lblAddrVal2.Text        = "-";
            this.lblAddrVal2.TextAlign   = System.Drawing.ContentAlignment.MiddleCenter;

            // ── 행 4: 3번 탄 중량 주소 (y=282) ───────────────────────────
            this.lblAddrHdr3.BackColor  = System.Drawing.Color.FromArgb(240, 244, 248);
            this.lblAddrHdr3.Font       = new System.Drawing.Font("굴림", 12F);
            this.lblAddrHdr3.ForeColor  = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblAddrHdr3.Location   = new System.Drawing.Point(20, 282);
            this.lblAddrHdr3.Name       = "lblAddrHdr3";
            this.lblAddrHdr3.Size       = new System.Drawing.Size(210, 54);
            this.lblAddrHdr3.TabIndex   = 9;
            this.lblAddrHdr3.Text       = "3번 탄 중량 주소";
            this.lblAddrHdr3.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblAddrVal3.BackColor   = System.Drawing.Color.White;
            this.lblAddrVal3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAddrVal3.Cursor      = System.Windows.Forms.Cursors.Hand;
            this.lblAddrVal3.Font        = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.lblAddrVal3.ForeColor   = System.Drawing.Color.FromArgb(31, 97, 141);
            this.lblAddrVal3.Location    = new System.Drawing.Point(248, 282);
            this.lblAddrVal3.Name        = "lblAddrVal3";
            this.lblAddrVal3.Size        = new System.Drawing.Size(172, 52);
            this.lblAddrVal3.TabIndex    = 8;
            this.lblAddrVal3.Text        = "-";
            this.lblAddrVal3.TextAlign   = System.Drawing.ContentAlignment.MiddleCenter;

            // ── 행 5: 4번 탄 중량 주소 (y=346) ───────────────────────────
            this.lblAddrHdr4.BackColor  = System.Drawing.Color.FromArgb(240, 244, 248);
            this.lblAddrHdr4.Font       = new System.Drawing.Font("굴림", 12F);
            this.lblAddrHdr4.ForeColor  = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblAddrHdr4.Location   = new System.Drawing.Point(20, 346);
            this.lblAddrHdr4.Name       = "lblAddrHdr4";
            this.lblAddrHdr4.Size       = new System.Drawing.Size(210, 54);
            this.lblAddrHdr4.TabIndex   = 7;
            this.lblAddrHdr4.Text       = "4번 탄 중량 주소";
            this.lblAddrHdr4.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblAddrVal4.BackColor   = System.Drawing.Color.White;
            this.lblAddrVal4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAddrVal4.Cursor      = System.Windows.Forms.Cursors.Hand;
            this.lblAddrVal4.Font        = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.lblAddrVal4.ForeColor   = System.Drawing.Color.FromArgb(31, 97, 141);
            this.lblAddrVal4.Location    = new System.Drawing.Point(248, 346);
            this.lblAddrVal4.Name        = "lblAddrVal4";
            this.lblAddrVal4.Size        = new System.Drawing.Size(172, 52);
            this.lblAddrVal4.TabIndex    = 6;
            this.lblAddrVal4.Text        = "-";
            this.lblAddrVal4.TextAlign   = System.Drawing.ContentAlignment.MiddleCenter;

            // ── 버튼 (y=416, 480) ─────────────────────────────────────────
            this.btnPollingToggle.FlatAppearance.BorderSize = 0;
            this.btnPollingToggle.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnPollingToggle.Font                      = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.btnPollingToggle.ForeColor                 = System.Drawing.Color.White;
            this.btnPollingToggle.Location                  = new System.Drawing.Point(20, 416);
            this.btnPollingToggle.Name                      = "btnPollingToggle";
            this.btnPollingToggle.Size                      = new System.Drawing.Size(400, 54);
            this.btnPollingToggle.TabIndex                  = 2;
            this.btnPollingToggle.Text                      = "PLC 중량 체크 ON";
            this.btnPollingToggle.UseVisualStyleBackColor   = false;

            this.btnClose.BackColor                 = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font                      = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor                 = System.Drawing.Color.White;
            this.btnClose.Location                  = new System.Drawing.Point(20, 480);
            this.btnClose.Name                      = "btnClose";
            this.btnClose.Size                      = new System.Drawing.Size(400, 54);
            this.btnClose.TabIndex                  = 0;
            this.btnClose.Text                      = "닫  기";
            this.btnClose.UseVisualStyleBackColor   = false;

            // ── PlcSettingForm ────────────────────────────────────────────
            this.AutoScaleMode   = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor       = System.Drawing.Color.FromArgb(240, 244, 248);
            this.ClientSize      = new System.Drawing.Size(440, 550);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPollingToggle);
            this.Controls.Add(this.lblAddrVal4);
            this.Controls.Add(this.lblAddrHdr4);
            this.Controls.Add(this.lblAddrVal3);
            this.Controls.Add(this.lblAddrHdr3);
            this.Controls.Add(this.lblAddrVal2);
            this.Controls.Add(this.lblAddrHdr2);
            this.Controls.Add(this.lblAddrVal1);
            this.Controls.Add(this.lblAddrHdr1);
            this.Controls.Add(this.lblPollVal);
            this.Controls.Add(this.lblPollHdr);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name            = "PlcSettingForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "PLC 설정";
            this.TopMost         = true;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label  lblTitle;
        private System.Windows.Forms.Label  lblPollHdr;
        private System.Windows.Forms.Label  lblPollVal;
        private System.Windows.Forms.Label  lblAddrHdr1;
        private System.Windows.Forms.Label  lblAddrVal1;
        private System.Windows.Forms.Label  lblAddrHdr2;
        private System.Windows.Forms.Label  lblAddrVal2;
        private System.Windows.Forms.Label  lblAddrHdr3;
        private System.Windows.Forms.Label  lblAddrVal3;
        private System.Windows.Forms.Label  lblAddrHdr4;
        private System.Windows.Forms.Label  lblAddrVal4;
        private System.Windows.Forms.Button btnPollingToggle;
        private System.Windows.Forms.Button btnClose;
    }
}
