namespace PoongSan_Angang_BCR
{
    partial class TimeoutSettingForm
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
            this.lblTitle        = new System.Windows.Forms.Label();
            this.lblStatusHeader = new System.Windows.Forms.Label();
            this.btnToggle       = new System.Windows.Forms.Button();
            this.lblTimeHeader   = new System.Windows.Forms.Label();
            this.btnHourDown     = new System.Windows.Forms.Button();
            this.lblHour         = new System.Windows.Forms.Label();
            this.lblHourUnit     = new System.Windows.Forms.Label();
            this.btnHourUp       = new System.Windows.Forms.Button();
            this.btnMinDown      = new System.Windows.Forms.Button();
            this.lblMin          = new System.Windows.Forms.Label();
            this.lblMinUnit      = new System.Windows.Forms.Label();
            this.btnMinUp        = new System.Windows.Forms.Button();
            this.btnClose        = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.BackColor  = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTitle.Font       = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor  = System.Drawing.Color.White;
            this.lblTitle.Location   = new System.Drawing.Point(20, 14);
            this.lblTitle.Name       = "lblTitle";
            this.lblTitle.Size       = new System.Drawing.Size(520, 54);
            this.lblTitle.TabIndex   = 10;
            this.lblTitle.Text       = "타임아웃 설정";
            this.lblTitle.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;

            // lblStatusHeader
            this.lblStatusHeader.BackColor  = System.Drawing.Color.FromArgb(240, 244, 248);
            this.lblStatusHeader.Font       = new System.Drawing.Font("굴림", 11F);
            this.lblStatusHeader.ForeColor  = System.Drawing.Color.FromArgb(100, 120, 140);
            this.lblStatusHeader.Location   = new System.Drawing.Point(20, 80);
            this.lblStatusHeader.Name       = "lblStatusHeader";
            this.lblStatusHeader.Size       = new System.Drawing.Size(520, 24);
            this.lblStatusHeader.TabIndex   = 9;
            this.lblStatusHeader.Text       = "현재 상태";
            this.lblStatusHeader.TextAlign  = System.Drawing.ContentAlignment.MiddleLeft;

            // btnToggle
            this.btnToggle.BackColor                 = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnToggle.FlatAppearance.BorderSize = 0;
            this.btnToggle.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Font                      = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.btnToggle.ForeColor                 = System.Drawing.Color.White;
            this.btnToggle.Location                  = new System.Drawing.Point(68, 122);
            this.btnToggle.Name                      = "btnToggle";
            this.btnToggle.Size                      = new System.Drawing.Size(396, 59);
            this.btnToggle.TabIndex                  = 8;
            this.btnToggle.Text                      = "타임아웃 OFF  (터치하여 ON)";
            this.btnToggle.UseVisualStyleBackColor   = false;

            // lblTimeHeader
            this.lblTimeHeader.BackColor  = System.Drawing.Color.FromArgb(240, 244, 248);
            this.lblTimeHeader.Font       = new System.Drawing.Font("굴림", 11F);
            this.lblTimeHeader.ForeColor  = System.Drawing.Color.FromArgb(100, 120, 140);
            this.lblTimeHeader.Location   = new System.Drawing.Point(20, 200);
            this.lblTimeHeader.Name       = "lblTimeHeader";
            this.lblTimeHeader.Size       = new System.Drawing.Size(520, 24);
            this.lblTimeHeader.TabIndex   = 7;
            this.lblTimeHeader.Text       = "설정 시간";
            this.lblTimeHeader.TextAlign  = System.Drawing.ContentAlignment.MiddleLeft;

            // ── 시간 스피너 ─────────────────────────────────
            // btnHourDown  (x=37)
            this.btnHourDown.BackColor                 = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnHourDown.FlatAppearance.BorderSize = 0;
            this.btnHourDown.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnHourDown.Font                      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.btnHourDown.ForeColor                 = System.Drawing.Color.White;
            this.btnHourDown.Location                  = new System.Drawing.Point(37, 242);
            this.btnHourDown.Name                      = "btnHourDown";
            this.btnHourDown.Size                      = new System.Drawing.Size(55, 62);
            this.btnHourDown.TabIndex                  = 6;
            this.btnHourDown.Text                      = "−";
            this.btnHourDown.UseVisualStyleBackColor   = false;

            // lblHour  (x=97)
            this.lblHour.BackColor   = System.Drawing.Color.White;
            this.lblHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHour.Font        = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.lblHour.ForeColor   = System.Drawing.Color.FromArgb(31, 97, 141);
            this.lblHour.Location    = new System.Drawing.Point(97, 242);
            this.lblHour.Name        = "lblHour";
            this.lblHour.Size        = new System.Drawing.Size(72, 62);
            this.lblHour.TabIndex    = 5;
            this.lblHour.Text        = "0";
            this.lblHour.TextAlign   = System.Drawing.ContentAlignment.MiddleCenter;

            // lblHourUnit  (x=174)
            this.lblHourUnit.BackColor  = System.Drawing.Color.FromArgb(240, 244, 248);
            this.lblHourUnit.Font       = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.lblHourUnit.ForeColor  = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblHourUnit.Location   = new System.Drawing.Point(174, 242);
            this.lblHourUnit.Name       = "lblHourUnit";
            this.lblHourUnit.Size       = new System.Drawing.Size(50, 62);
            this.lblHourUnit.TabIndex   = 4;
            this.lblHourUnit.Text       = "시간";
            this.lblHourUnit.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;

            // btnHourUp  (x=229)
            this.btnHourUp.BackColor                 = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnHourUp.FlatAppearance.BorderSize = 0;
            this.btnHourUp.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnHourUp.Font                      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.btnHourUp.ForeColor                 = System.Drawing.Color.White;
            this.btnHourUp.Location                  = new System.Drawing.Point(229, 242);
            this.btnHourUp.Name                      = "btnHourUp";
            this.btnHourUp.Size                      = new System.Drawing.Size(55, 62);
            this.btnHourUp.TabIndex                  = 3;
            this.btnHourUp.Text                      = "+";
            this.btnHourUp.UseVisualStyleBackColor   = false;

            // ── 분 스피너 ───────────────────────────────────
            // btnMinDown  (x=302)
            this.btnMinDown.BackColor                 = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnMinDown.FlatAppearance.BorderSize = 0;
            this.btnMinDown.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinDown.Font                      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.btnMinDown.ForeColor                 = System.Drawing.Color.White;
            this.btnMinDown.Location                  = new System.Drawing.Point(302, 242);
            this.btnMinDown.Name                      = "btnMinDown";
            this.btnMinDown.Size                      = new System.Drawing.Size(55, 62);
            this.btnMinDown.TabIndex                  = 2;
            this.btnMinDown.Text                      = "−";
            this.btnMinDown.UseVisualStyleBackColor   = false;

            // lblMin  (x=362)
            this.lblMin.BackColor   = System.Drawing.Color.White;
            this.lblMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMin.Font        = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.lblMin.ForeColor   = System.Drawing.Color.FromArgb(31, 97, 141);
            this.lblMin.Location    = new System.Drawing.Point(362, 242);
            this.lblMin.Name        = "lblMin";
            this.lblMin.Size        = new System.Drawing.Size(72, 62);
            this.lblMin.TabIndex    = 1;
            this.lblMin.Text        = "1";
            this.lblMin.TextAlign   = System.Drawing.ContentAlignment.MiddleCenter;

            // lblMinUnit  (x=439)
            this.lblMinUnit.BackColor  = System.Drawing.Color.FromArgb(240, 244, 248);
            this.lblMinUnit.Font       = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.lblMinUnit.ForeColor  = System.Drawing.Color.FromArgb(60, 80, 100);
            this.lblMinUnit.Location   = new System.Drawing.Point(439, 242);
            this.lblMinUnit.Name       = "lblMinUnit";
            this.lblMinUnit.Size       = new System.Drawing.Size(36, 62);
            this.lblMinUnit.TabIndex   = 11;
            this.lblMinUnit.Text       = "분";
            this.lblMinUnit.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;

            // btnMinUp  (x=480)
            this.btnMinUp.BackColor                 = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnMinUp.FlatAppearance.BorderSize = 0;
            this.btnMinUp.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinUp.Font                      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.btnMinUp.ForeColor                 = System.Drawing.Color.White;
            this.btnMinUp.Location                  = new System.Drawing.Point(480, 242);
            this.btnMinUp.Name                      = "btnMinUp";
            this.btnMinUp.Size                      = new System.Drawing.Size(55, 62);
            this.btnMinUp.TabIndex                  = 12;
            this.btnMinUp.Text                      = "+";
            this.btnMinUp.UseVisualStyleBackColor   = false;

            // btnClose
            this.btnClose.BackColor                 = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font                      = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor                 = System.Drawing.Color.White;
            this.btnClose.Location                  = new System.Drawing.Point(380, 360);
            this.btnClose.Name                      = "btnClose";
            this.btnClose.Size                      = new System.Drawing.Size(160, 54);
            this.btnClose.TabIndex                  = 0;
            this.btnClose.Text                      = "닫  기";
            this.btnClose.UseVisualStyleBackColor   = false;

            // TimeoutSettingForm
            this.AutoScaleMode   = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor       = System.Drawing.Color.FromArgb(240, 244, 248);
            this.ClientSize      = new System.Drawing.Size(560, 430);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMinUp);
            this.Controls.Add(this.lblMinUnit);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.btnMinDown);
            this.Controls.Add(this.btnHourUp);
            this.Controls.Add(this.lblHourUnit);
            this.Controls.Add(this.lblHour);
            this.Controls.Add(this.btnHourDown);
            this.Controls.Add(this.lblTimeHeader);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.lblStatusHeader);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name            = "TimeoutSettingForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "타임아웃 설정";
            this.TopMost         = true;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label  lblTitle;
        private System.Windows.Forms.Label  lblStatusHeader;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Label  lblTimeHeader;
        private System.Windows.Forms.Button btnHourDown;
        private System.Windows.Forms.Label  lblHour;
        private System.Windows.Forms.Label  lblHourUnit;
        private System.Windows.Forms.Button btnHourUp;
        private System.Windows.Forms.Button btnMinDown;
        private System.Windows.Forms.Label  lblMin;
        private System.Windows.Forms.Label  lblMinUnit;
        private System.Windows.Forms.Button btnMinUp;
        private System.Windows.Forms.Button btnClose;
    }
}
