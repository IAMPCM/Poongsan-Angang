namespace PoongSan_Angang_BCR
{
    partial class OkForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lb_OkCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_OkCode
            // 
            this.lb_OkCode.BackColor = System.Drawing.Color.Green;
            this.lb_OkCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_OkCode.Font = new System.Drawing.Font("굴림", 120F, System.Drawing.FontStyle.Bold);
            this.lb_OkCode.ForeColor = System.Drawing.Color.Yellow;
            this.lb_OkCode.Location = new System.Drawing.Point(0, 0);
            this.lb_OkCode.Name = "lb_OkCode";
            this.lb_OkCode.Size = new System.Drawing.Size(1681, 1050);
            this.lb_OkCode.TabIndex = 0;
            this.lb_OkCode.Text = "OK";
            this.lb_OkCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(1681, 1050);
            this.Controls.Add(this.lb_OkCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "OkForm";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        public System.Windows.Forms.Label lb_OkCode;
    }
}
