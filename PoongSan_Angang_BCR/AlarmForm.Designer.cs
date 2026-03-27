namespace PoongSan_Angang_BCR
{
    partial class AlarmForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_AlarmCode = new System.Windows.Forms.Label();
            this.btn_Buzzer_off = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_AlarmCode
            // 
            this.lb_AlarmCode.BackColor = System.Drawing.Color.Red;
            this.lb_AlarmCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_AlarmCode.Font = new System.Drawing.Font("굴림", 120F, System.Drawing.FontStyle.Bold);
            this.lb_AlarmCode.ForeColor = System.Drawing.Color.Yellow;
            this.lb_AlarmCode.Location = new System.Drawing.Point(0, 0);
            this.lb_AlarmCode.Name = "lb_AlarmCode";
            this.lb_AlarmCode.Size = new System.Drawing.Size(1681, 1050);
            this.lb_AlarmCode.TabIndex = 120;
            this.lb_AlarmCode.Text = "NG";
            this.lb_AlarmCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_AlarmCode.Click += new System.EventHandler(this.lb_AlarmCode_Click_1);
            this.lb_AlarmCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AlarmForm_MouseClick);
            // 
            // btn_Buzzer_off
            // 
            this.btn_Buzzer_off.Location = new System.Drawing.Point(1857, 1530);
            this.btn_Buzzer_off.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Buzzer_off.Name = "btn_Buzzer_off";
            this.btn_Buzzer_off.Size = new System.Drawing.Size(277, 56);
            this.btn_Buzzer_off.TabIndex = 127;
            this.btn_Buzzer_off.Text = "BUZZER";
            this.btn_Buzzer_off.UseVisualStyleBackColor = true;
            this.btn_Buzzer_off.Visible = false;
            this.btn_Buzzer_off.Click += new System.EventHandler(this.btn_Buzzer_off_Click);
            // 
            // AlarmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(1681, 1050);
            this.Controls.Add(this.btn_Buzzer_off);
            this.Controls.Add(this.lb_AlarmCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AlarmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AlarmForm";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AlarmForm_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label lb_AlarmCode;
        private System.Windows.Forms.Button btn_Buzzer_off;
    }
}