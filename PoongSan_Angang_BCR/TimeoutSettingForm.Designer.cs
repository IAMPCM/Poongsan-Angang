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
            this.lblMinutes      = new System.Windows.Forms.Label();
            this.btnChangeTime   = new System.Windows.Forms.Button();
            this.btnX            = new System.Windows.Forms.Button();
            this.btnClose        = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTitle.Font      = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(20, 14);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Size      = new System.Drawing.Size(520, 54);
            this.lblTitle.Text      = "타임아웃 설정";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblStatusHeader
            //
            this.lblStatusHeader.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.lblStatusHeader.Font      = new System.Drawing.Font("굴림", 13F);
            this.lblStatusHeader.ForeColor = System.Drawing.Color.FromArgb(100, 120, 140);
            this.lblStatusHeader.Location  = new System.Drawing.Point(20, 80);
            this.lblStatusHeader.Name      = "lblStatusHeader";
            this.lblStatusHeader.Size      = new System.Drawing.Size(520, 28);
            this.lblStatusHeader.Text      = "현재 상태";
            this.lblStatusHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnToggle
            //
            this.btnToggle.FlatAppearance.BorderSize = 0;
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Font      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.btnToggle.ForeColor = System.Drawing.Color.White;
            this.btnToggle.Location  = new System.Drawing.Point(20, 108);
            this.btnToggle.Name      = "btnToggle";
            this.btnToggle.Size      = new System.Drawing.Size(520, 80);
            this.btnToggle.Text      = "타임아웃 OFF  (클릭하여 ON)";
            this.btnToggle.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnToggle.UseVisualStyleBackColor = false;
            //
            // lblTimeHeader
            //
            this.lblTimeHeader.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.lblTimeHeader.Font      = new System.Drawing.Font("굴림", 13F);
            this.lblTimeHeader.ForeColor = System.Drawing.Color.FromArgb(100, 120, 140);
            this.lblTimeHeader.Location  = new System.Drawing.Point(20, 208);
            this.lblTimeHeader.Name      = "lblTimeHeader";
            this.lblTimeHeader.Size      = new System.Drawing.Size(520, 28);
            this.lblTimeHeader.Text      = "설정 시간";
            this.lblTimeHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblMinutes
            //
            this.lblMinutes.BackColor   = System.Drawing.Color.White;
            this.lblMinutes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMinutes.Font        = new System.Drawing.Font("굴림", 22F, System.Drawing.FontStyle.Bold);
            this.lblMinutes.ForeColor   = System.Drawing.Color.FromArgb(31, 97, 141);
            this.lblMinutes.Location    = new System.Drawing.Point(20, 238);
            this.lblMinutes.Name        = "lblMinutes";
            this.lblMinutes.Size        = new System.Drawing.Size(310, 80);
            this.lblMinutes.Text        = "1 분";
            this.lblMinutes.TextAlign   = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnChangeTime
            //
            this.btnChangeTime.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnChangeTime.FlatAppearance.BorderSize = 0;
            this.btnChangeTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeTime.Font      = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold);
            this.btnChangeTime.ForeColor = System.Drawing.Color.White;
            this.btnChangeTime.Location  = new System.Drawing.Point(350, 238);
            this.btnChangeTime.Name      = "btnChangeTime";
            this.btnChangeTime.Size      = new System.Drawing.Size(190, 80);
            this.btnChangeTime.Text      = "시간 변경";
            this.btnChangeTime.UseVisualStyleBackColor = false;
            //
            // btnX
            //
            this.btnX.BackColor = System.Drawing.Color.FromArgb(214, 229, 241);
            this.btnX.FlatAppearance.BorderSize = 0;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnX.ForeColor = System.Drawing.Color.FromArgb(31, 97, 141);
            this.btnX.Location  = new System.Drawing.Point(510, 5);
            this.btnX.Name      = "btnX";
            this.btnX.Size      = new System.Drawing.Size(40, 30);
            this.btnX.Text      = "✕";
            this.btnX.UseVisualStyleBackColor = false;
            //
            // btnClose
            //
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font      = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location  = new System.Drawing.Point(380, 360);
            this.btnClose.Name      = "btnClose";
            this.btnClose.Size      = new System.Drawing.Size(160, 54);
            this.btnClose.Text      = "닫  기";
            this.btnClose.UseVisualStyleBackColor = false;
            //
            // TimeoutSettingForm
            //
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor           = System.Drawing.Color.FromArgb(240, 244, 248);
            this.ClientSize          = new System.Drawing.Size(560, 430);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.btnChangeTime);
            this.Controls.Add(this.lblMinutes);
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
        private System.Windows.Forms.Label  lblMinutes;
        private System.Windows.Forms.Button btnChangeTime;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Button btnClose;
    }
}
