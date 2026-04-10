namespace PoongSan_Angang_BCR
{
    partial class SettingsForm
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
            this.lblTitle          = new System.Windows.Forms.Label();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnTimeout        = new System.Windows.Forms.Button();
            this.btnModelSetting   = new System.Windows.Forms.Button();
            this.btnX              = new System.Windows.Forms.Button();
            this.btnClose          = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTitle.Font      = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(20, 15);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Size      = new System.Drawing.Size(360, 50);
            this.lblTitle.Text      = "설  정";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnChangePassword
            //
            this.btnChangePassword.BackColor = System.Drawing.Color.White;
            this.btnChangePassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnChangePassword.FlatAppearance.BorderSize = 1;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font      = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.btnChangePassword.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnChangePassword.Location  = new System.Drawing.Point(20, 75);
            this.btnChangePassword.Name      = "btnChangePassword";
            this.btnChangePassword.Size      = new System.Drawing.Size(360, 60);
            this.btnChangePassword.Text      = "비밀번호 변경";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            //
            // btnTimeout
            //
            this.btnTimeout.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnTimeout.FlatAppearance.BorderSize = 0;
            this.btnTimeout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimeout.Font      = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.btnTimeout.ForeColor = System.Drawing.Color.White;
            this.btnTimeout.Location  = new System.Drawing.Point(20, 145);
            this.btnTimeout.Name      = "btnTimeout";
            this.btnTimeout.Size      = new System.Drawing.Size(360, 60);
            this.btnTimeout.Text      = "타임아웃 설정";
            this.btnTimeout.UseVisualStyleBackColor = false;
            //
            // btnModelSetting
            //
            this.btnModelSetting.BackColor = System.Drawing.Color.White;
            this.btnModelSetting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnModelSetting.FlatAppearance.BorderSize = 1;
            this.btnModelSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModelSetting.Font      = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.btnModelSetting.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnModelSetting.Location  = new System.Drawing.Point(20, 215);
            this.btnModelSetting.Name      = "btnModelSetting";
            this.btnModelSetting.Size      = new System.Drawing.Size(360, 60);
            this.btnModelSetting.Text      = "바코드 설정";
            this.btnModelSetting.UseVisualStyleBackColor = false;
            //
            // btnX
            //
            this.btnX.BackColor = System.Drawing.Color.FromArgb(214, 229, 241);
            this.btnX.FlatAppearance.BorderSize = 0;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnX.ForeColor = System.Drawing.Color.FromArgb(31, 97, 141);
            this.btnX.Location  = new System.Drawing.Point(350, 5);
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
            this.btnClose.Font      = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location  = new System.Drawing.Point(260, 285);
            this.btnClose.Name      = "btnClose";
            this.btnClose.Size      = new System.Drawing.Size(120, 48);
            this.btnClose.Text      = "닫  기";
            this.btnClose.UseVisualStyleBackColor = false;
            //
            // SettingsForm
            //
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor           = System.Drawing.Color.FromArgb(240, 244, 248);
            this.ClientSize          = new System.Drawing.Size(400, 355);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.btnModelSetting);
            this.Controls.Add(this.btnTimeout);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name            = "SettingsForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "설정";
            this.TopMost         = true;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label  lblTitle;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnTimeout;
        private System.Windows.Forms.Button btnModelSetting;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Button btnClose;
    }
}
