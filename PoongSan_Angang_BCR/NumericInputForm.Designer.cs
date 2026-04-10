namespace PoongSan_Angang_BCR
{
    partial class NumericInputForm
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
            this.lblTitle   = new System.Windows.Forms.Label();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.btnKey1    = new System.Windows.Forms.Button();
            this.btnKey2    = new System.Windows.Forms.Button();
            this.btnKey3    = new System.Windows.Forms.Button();
            this.btnKey4    = new System.Windows.Forms.Button();
            this.btnKey5    = new System.Windows.Forms.Button();
            this.btnKey6    = new System.Windows.Forms.Button();
            this.btnKey7    = new System.Windows.Forms.Button();
            this.btnKey8    = new System.Windows.Forms.Button();
            this.btnKey9    = new System.Windows.Forms.Button();
            this.btnKeyCLR  = new System.Windows.Forms.Button();
            this.btnKey0    = new System.Windows.Forms.Button();
            this.btnKeyBack = new System.Windows.Forms.Button();
            this.btnOk      = new System.Windows.Forms.Button();
            this.btnCancel  = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTitle.Font      = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(0, 0);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Size      = new System.Drawing.Size(322, 46);
            this.lblTitle.Text      = "입력";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblDisplay
            //
            this.lblDisplay.BackColor   = System.Drawing.Color.White;
            this.lblDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDisplay.Font        = new System.Drawing.Font("굴림", 22F, System.Drawing.FontStyle.Bold);
            this.lblDisplay.ForeColor   = System.Drawing.Color.FromArgb(31, 97, 141);
            this.lblDisplay.Location    = new System.Drawing.Point(20, 54);
            this.lblDisplay.Name        = "lblDisplay";
            this.lblDisplay.Size        = new System.Drawing.Size(282, 54);
            this.lblDisplay.TextAlign   = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // 숫자 키 — 3열 4행 (1~9, CLR, 0, ←)
            // KeyW=90, KeyH=70, Gap=6, PadX=20, keyStartY=120
            //
            // Row 0: 1, 2, 3  (y=120)
            this.btnKey1.BackColor = System.Drawing.Color.White;
            this.btnKey1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnKey1.FlatAppearance.BorderSize  = 1;
            this.btnKey1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey1.Font      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.btnKey1.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnKey1.Location  = new System.Drawing.Point(20, 120);
            this.btnKey1.Name      = "btnKey1";
            this.btnKey1.Size      = new System.Drawing.Size(90, 70);
            this.btnKey1.Tag       = "1";
            this.btnKey1.Text      = "1";
            this.btnKey1.UseVisualStyleBackColor = false;

            this.btnKey2.BackColor = System.Drawing.Color.White;
            this.btnKey2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnKey2.FlatAppearance.BorderSize  = 1;
            this.btnKey2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey2.Font      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.btnKey2.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnKey2.Location  = new System.Drawing.Point(116, 120);
            this.btnKey2.Name      = "btnKey2";
            this.btnKey2.Size      = new System.Drawing.Size(90, 70);
            this.btnKey2.Tag       = "2";
            this.btnKey2.Text      = "2";
            this.btnKey2.UseVisualStyleBackColor = false;

            this.btnKey3.BackColor = System.Drawing.Color.White;
            this.btnKey3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnKey3.FlatAppearance.BorderSize  = 1;
            this.btnKey3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey3.Font      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.btnKey3.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnKey3.Location  = new System.Drawing.Point(212, 120);
            this.btnKey3.Name      = "btnKey3";
            this.btnKey3.Size      = new System.Drawing.Size(90, 70);
            this.btnKey3.Tag       = "3";
            this.btnKey3.Text      = "3";
            this.btnKey3.UseVisualStyleBackColor = false;

            // Row 1: 4, 5, 6  (y=196)
            this.btnKey4.BackColor = System.Drawing.Color.White;
            this.btnKey4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnKey4.FlatAppearance.BorderSize  = 1;
            this.btnKey4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey4.Font      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.btnKey4.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnKey4.Location  = new System.Drawing.Point(20, 196);
            this.btnKey4.Name      = "btnKey4";
            this.btnKey4.Size      = new System.Drawing.Size(90, 70);
            this.btnKey4.Tag       = "4";
            this.btnKey4.Text      = "4";
            this.btnKey4.UseVisualStyleBackColor = false;

            this.btnKey5.BackColor = System.Drawing.Color.White;
            this.btnKey5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnKey5.FlatAppearance.BorderSize  = 1;
            this.btnKey5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey5.Font      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.btnKey5.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnKey5.Location  = new System.Drawing.Point(116, 196);
            this.btnKey5.Name      = "btnKey5";
            this.btnKey5.Size      = new System.Drawing.Size(90, 70);
            this.btnKey5.Tag       = "5";
            this.btnKey5.Text      = "5";
            this.btnKey5.UseVisualStyleBackColor = false;

            this.btnKey6.BackColor = System.Drawing.Color.White;
            this.btnKey6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnKey6.FlatAppearance.BorderSize  = 1;
            this.btnKey6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey6.Font      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.btnKey6.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnKey6.Location  = new System.Drawing.Point(212, 196);
            this.btnKey6.Name      = "btnKey6";
            this.btnKey6.Size      = new System.Drawing.Size(90, 70);
            this.btnKey6.Tag       = "6";
            this.btnKey6.Text      = "6";
            this.btnKey6.UseVisualStyleBackColor = false;

            // Row 2: 7, 8, 9  (y=272)
            this.btnKey7.BackColor = System.Drawing.Color.White;
            this.btnKey7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnKey7.FlatAppearance.BorderSize  = 1;
            this.btnKey7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey7.Font      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.btnKey7.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnKey7.Location  = new System.Drawing.Point(20, 272);
            this.btnKey7.Name      = "btnKey7";
            this.btnKey7.Size      = new System.Drawing.Size(90, 70);
            this.btnKey7.Tag       = "7";
            this.btnKey7.Text      = "7";
            this.btnKey7.UseVisualStyleBackColor = false;

            this.btnKey8.BackColor = System.Drawing.Color.White;
            this.btnKey8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnKey8.FlatAppearance.BorderSize  = 1;
            this.btnKey8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey8.Font      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.btnKey8.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnKey8.Location  = new System.Drawing.Point(116, 272);
            this.btnKey8.Name      = "btnKey8";
            this.btnKey8.Size      = new System.Drawing.Size(90, 70);
            this.btnKey8.Tag       = "8";
            this.btnKey8.Text      = "8";
            this.btnKey8.UseVisualStyleBackColor = false;

            this.btnKey9.BackColor = System.Drawing.Color.White;
            this.btnKey9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnKey9.FlatAppearance.BorderSize  = 1;
            this.btnKey9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey9.Font      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.btnKey9.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnKey9.Location  = new System.Drawing.Point(212, 272);
            this.btnKey9.Name      = "btnKey9";
            this.btnKey9.Size      = new System.Drawing.Size(90, 70);
            this.btnKey9.Tag       = "9";
            this.btnKey9.Text      = "9";
            this.btnKey9.UseVisualStyleBackColor = false;

            // Row 3: CLR, 0, ←  (y=348)
            this.btnKeyCLR.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.btnKeyCLR.FlatAppearance.BorderSize  = 0;
            this.btnKeyCLR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyCLR.Font      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.btnKeyCLR.ForeColor = System.Drawing.Color.White;
            this.btnKeyCLR.Location  = new System.Drawing.Point(20, 348);
            this.btnKeyCLR.Name      = "btnKeyCLR";
            this.btnKeyCLR.Size      = new System.Drawing.Size(90, 70);
            this.btnKeyCLR.Tag       = "CLR";
            this.btnKeyCLR.Text      = "CLR";
            this.btnKeyCLR.UseVisualStyleBackColor = false;

            this.btnKey0.BackColor = System.Drawing.Color.White;
            this.btnKey0.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnKey0.FlatAppearance.BorderSize  = 1;
            this.btnKey0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey0.Font      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.btnKey0.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnKey0.Location  = new System.Drawing.Point(116, 348);
            this.btnKey0.Name      = "btnKey0";
            this.btnKey0.Size      = new System.Drawing.Size(90, 70);
            this.btnKey0.Tag       = "0";
            this.btnKey0.Text      = "0";
            this.btnKey0.UseVisualStyleBackColor = false;

            this.btnKeyBack.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnKeyBack.FlatAppearance.BorderSize  = 0;
            this.btnKeyBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyBack.Font      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.btnKeyBack.ForeColor = System.Drawing.Color.White;
            this.btnKeyBack.Location  = new System.Drawing.Point(212, 348);
            this.btnKeyBack.Name      = "btnKeyBack";
            this.btnKeyBack.Size      = new System.Drawing.Size(90, 70);
            this.btnKeyBack.Tag       = "←";
            this.btnKeyBack.Text      = "←";
            this.btnKeyBack.UseVisualStyleBackColor = false;
            //
            // btnOk
            //
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font      = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location  = new System.Drawing.Point(20, 432);
            this.btnOk.Name      = "btnOk";
            this.btnOk.Size      = new System.Drawing.Size(138, 56);
            this.btnOk.Text      = "확  인";
            this.btnOk.UseVisualStyleBackColor = false;
            //
            // btnCancel
            //
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font      = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location  = new System.Drawing.Point(164, 432);
            this.btnCancel.Name      = "btnCancel";
            this.btnCancel.Size      = new System.Drawing.Size(138, 56);
            this.btnCancel.Text      = "취  소";
            this.btnCancel.UseVisualStyleBackColor = false;
            //
            // NumericInputForm
            //
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor           = System.Drawing.Color.FromArgb(240, 244, 248);
            this.ClientSize          = new System.Drawing.Size(322, 508);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnKeyBack);
            this.Controls.Add(this.btnKey0);
            this.Controls.Add(this.btnKeyCLR);
            this.Controls.Add(this.btnKey9);
            this.Controls.Add(this.btnKey8);
            this.Controls.Add(this.btnKey7);
            this.Controls.Add(this.btnKey6);
            this.Controls.Add(this.btnKey5);
            this.Controls.Add(this.btnKey4);
            this.Controls.Add(this.btnKey3);
            this.Controls.Add(this.btnKey2);
            this.Controls.Add(this.btnKey1);
            this.Controls.Add(this.lblDisplay);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name            = "NumericInputForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost         = true;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label  lblTitle;
        private System.Windows.Forms.Label  lblDisplay;
        private System.Windows.Forms.Button btnKey1;
        private System.Windows.Forms.Button btnKey2;
        private System.Windows.Forms.Button btnKey3;
        private System.Windows.Forms.Button btnKey4;
        private System.Windows.Forms.Button btnKey5;
        private System.Windows.Forms.Button btnKey6;
        private System.Windows.Forms.Button btnKey7;
        private System.Windows.Forms.Button btnKey8;
        private System.Windows.Forms.Button btnKey9;
        private System.Windows.Forms.Button btnKeyCLR;
        private System.Windows.Forms.Button btnKey0;
        private System.Windows.Forms.Button btnKeyBack;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
