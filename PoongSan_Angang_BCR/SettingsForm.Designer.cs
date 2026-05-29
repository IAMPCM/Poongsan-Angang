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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnTimeout = new System.Windows.Forms.Button();
            this.btnModelSetting = new System.Windows.Forms.Button();
            this.btnPlcSetting = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTitle.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(360, 50);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "설  정";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.White;
            this.btnChangePassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.btnChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnChangePassword.Location = new System.Drawing.Point(20, 75);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(360, 60);
            this.btnChangePassword.TabIndex = 4;
            this.btnChangePassword.Text = "비밀번호 변경";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            // 
            // btnTimeout
            // 
            this.btnTimeout.BackColor = System.Drawing.Color.White;
            this.btnTimeout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.btnTimeout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimeout.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.btnTimeout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnTimeout.Location = new System.Drawing.Point(20, 145);
            this.btnTimeout.Name = "btnTimeout";
            this.btnTimeout.Size = new System.Drawing.Size(360, 60);
            this.btnTimeout.TabIndex = 3;
            this.btnTimeout.Text = "타임아웃 설정";
            this.btnTimeout.UseVisualStyleBackColor = false;
            // 
            // btnModelSetting
            // 
            this.btnModelSetting.BackColor = System.Drawing.Color.White;
            this.btnModelSetting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.btnModelSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModelSetting.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.btnModelSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnModelSetting.Location = new System.Drawing.Point(20, 215);
            this.btnModelSetting.Name = "btnModelSetting";
            this.btnModelSetting.Size = new System.Drawing.Size(360, 60);
            this.btnModelSetting.TabIndex = 2;
            this.btnModelSetting.Text = "바코드 설정";
            this.btnModelSetting.UseVisualStyleBackColor = false;
            // 
            // btnPlcSetting
            //
            this.btnPlcSetting.BackColor = System.Drawing.Color.White;
            this.btnPlcSetting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.btnPlcSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlcSetting.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.btnPlcSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnPlcSetting.Location = new System.Drawing.Point(20, 285);
            this.btnPlcSetting.Name = "btnPlcSetting";
            this.btnPlcSetting.Size = new System.Drawing.Size(360, 60);
            this.btnPlcSetting.TabIndex = 1;
            this.btnPlcSetting.Text = "PLC 설정";
            this.btnPlcSetting.UseVisualStyleBackColor = false;
            this.btnPlcSetting.Visible = true;
            //
            // btnClose
            //
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(260, 355);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 48);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "닫  기";
            this.btnClose.UseVisualStyleBackColor = false;
            //
            // SettingsForm
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(400, 425);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPlcSetting);
            this.Controls.Add(this.btnModelSetting);
            this.Controls.Add(this.btnTimeout);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "설정";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label  lblTitle;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnTimeout;
        private System.Windows.Forms.Button btnModelSetting;
        private System.Windows.Forms.Button btnPlcSetting;
        private System.Windows.Forms.Button btnClose;
    }
}
