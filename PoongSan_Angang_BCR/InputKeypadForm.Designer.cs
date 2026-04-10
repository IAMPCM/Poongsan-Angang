namespace PoongSan_Angang_BCR
{
    partial class InputKeypadForm
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
            this.lblTitle    = new System.Windows.Forms.Label();
            this.txtDisplay  = new System.Windows.Forms.TextBox();
            // Row 0: 1 2 3 4 5 6 7 8 9 0
            this.btnK1       = new System.Windows.Forms.Button();
            this.btnK2       = new System.Windows.Forms.Button();
            this.btnK3       = new System.Windows.Forms.Button();
            this.btnK4       = new System.Windows.Forms.Button();
            this.btnK5       = new System.Windows.Forms.Button();
            this.btnK6       = new System.Windows.Forms.Button();
            this.btnK7       = new System.Windows.Forms.Button();
            this.btnK8       = new System.Windows.Forms.Button();
            this.btnK9       = new System.Windows.Forms.Button();
            this.btnK0       = new System.Windows.Forms.Button();
            // Row 1: Q W E R T Y U I O P
            this.btnKQ       = new System.Windows.Forms.Button();
            this.btnKW       = new System.Windows.Forms.Button();
            this.btnKE       = new System.Windows.Forms.Button();
            this.btnKR       = new System.Windows.Forms.Button();
            this.btnKT       = new System.Windows.Forms.Button();
            this.btnKY       = new System.Windows.Forms.Button();
            this.btnKU       = new System.Windows.Forms.Button();
            this.btnKI       = new System.Windows.Forms.Button();
            this.btnKO       = new System.Windows.Forms.Button();
            this.btnKP       = new System.Windows.Forms.Button();
            // Row 2: A S D F G H J K L .
            this.btnKA       = new System.Windows.Forms.Button();
            this.btnKS       = new System.Windows.Forms.Button();
            this.btnKD       = new System.Windows.Forms.Button();
            this.btnKF       = new System.Windows.Forms.Button();
            this.btnKG       = new System.Windows.Forms.Button();
            this.btnKH       = new System.Windows.Forms.Button();
            this.btnKJ       = new System.Windows.Forms.Button();
            this.btnKK       = new System.Windows.Forms.Button();
            this.btnKL       = new System.Windows.Forms.Button();
            this.btnKDot     = new System.Windows.Forms.Button();
            // Row 3: Z X C V B N M - / _
            this.btnKZ          = new System.Windows.Forms.Button();
            this.btnKX          = new System.Windows.Forms.Button();
            this.btnKC          = new System.Windows.Forms.Button();
            this.btnKV          = new System.Windows.Forms.Button();
            this.btnKB          = new System.Windows.Forms.Button();
            this.btnKN          = new System.Windows.Forms.Button();
            this.btnKM          = new System.Windows.Forms.Button();
            this.btnKMinus      = new System.Windows.Forms.Button();
            this.btnKSlash      = new System.Windows.Forms.Button();
            this.btnKUnderscore = new System.Windows.Forms.Button();
            // Control buttons
            this.btnBack    = new System.Windows.Forms.Button();
            this.btnClear   = new System.Windows.Forms.Button();
            this.btnOk      = new System.Windows.Forms.Button();
            this.btnCancel  = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(51, 51, 56);
            this.lblTitle.Font      = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(0, 0);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Size      = new System.Drawing.Size(710, 44);
            this.lblTitle.Text      = "입력";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // txtDisplay
            //
            this.txtDisplay.BackColor   = System.Drawing.Color.FromArgb(55, 55, 60);
            this.txtDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDisplay.Font        = new System.Drawing.Font("굴림", 16F);
            this.txtDisplay.ForeColor   = System.Drawing.Color.Yellow;
            this.txtDisplay.Location    = new System.Drawing.Point(10, 50);
            this.txtDisplay.Name        = "txtDisplay";
            this.txtDisplay.ReadOnly    = true;
            this.txtDisplay.Size        = new System.Drawing.Size(690, 46);
            this.txtDisplay.TextAlign   = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // ── Row 0 (y=106): 1 2 3 4 5 6 7 8 9 0 ──
            // keyW=65, keyH=52, gap=4, padX=10  →  x = 10 + col*69
            //
            this.btnK1.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnK1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnK1.FlatAppearance.BorderSize  = 1;
            this.btnK1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnK1.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnK1.ForeColor = System.Drawing.Color.White;
            this.btnK1.Location  = new System.Drawing.Point(10, 106);
            this.btnK1.Name      = "btnK1";
            this.btnK1.Size      = new System.Drawing.Size(65, 52);
            this.btnK1.Tag       = "1";
            this.btnK1.Text      = "1";
            this.btnK1.UseVisualStyleBackColor = false;

            this.btnK2.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnK2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnK2.FlatAppearance.BorderSize  = 1;
            this.btnK2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnK2.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnK2.ForeColor = System.Drawing.Color.White;
            this.btnK2.Location  = new System.Drawing.Point(79, 106);
            this.btnK2.Name      = "btnK2";
            this.btnK2.Size      = new System.Drawing.Size(65, 52);
            this.btnK2.Tag       = "2";
            this.btnK2.Text      = "2";
            this.btnK2.UseVisualStyleBackColor = false;

            this.btnK3.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnK3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnK3.FlatAppearance.BorderSize  = 1;
            this.btnK3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnK3.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnK3.ForeColor = System.Drawing.Color.White;
            this.btnK3.Location  = new System.Drawing.Point(148, 106);
            this.btnK3.Name      = "btnK3";
            this.btnK3.Size      = new System.Drawing.Size(65, 52);
            this.btnK3.Tag       = "3";
            this.btnK3.Text      = "3";
            this.btnK3.UseVisualStyleBackColor = false;

            this.btnK4.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnK4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnK4.FlatAppearance.BorderSize  = 1;
            this.btnK4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnK4.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnK4.ForeColor = System.Drawing.Color.White;
            this.btnK4.Location  = new System.Drawing.Point(217, 106);
            this.btnK4.Name      = "btnK4";
            this.btnK4.Size      = new System.Drawing.Size(65, 52);
            this.btnK4.Tag       = "4";
            this.btnK4.Text      = "4";
            this.btnK4.UseVisualStyleBackColor = false;

            this.btnK5.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnK5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnK5.FlatAppearance.BorderSize  = 1;
            this.btnK5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnK5.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnK5.ForeColor = System.Drawing.Color.White;
            this.btnK5.Location  = new System.Drawing.Point(286, 106);
            this.btnK5.Name      = "btnK5";
            this.btnK5.Size      = new System.Drawing.Size(65, 52);
            this.btnK5.Tag       = "5";
            this.btnK5.Text      = "5";
            this.btnK5.UseVisualStyleBackColor = false;

            this.btnK6.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnK6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnK6.FlatAppearance.BorderSize  = 1;
            this.btnK6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnK6.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnK6.ForeColor = System.Drawing.Color.White;
            this.btnK6.Location  = new System.Drawing.Point(355, 106);
            this.btnK6.Name      = "btnK6";
            this.btnK6.Size      = new System.Drawing.Size(65, 52);
            this.btnK6.Tag       = "6";
            this.btnK6.Text      = "6";
            this.btnK6.UseVisualStyleBackColor = false;

            this.btnK7.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnK7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnK7.FlatAppearance.BorderSize  = 1;
            this.btnK7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnK7.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnK7.ForeColor = System.Drawing.Color.White;
            this.btnK7.Location  = new System.Drawing.Point(424, 106);
            this.btnK7.Name      = "btnK7";
            this.btnK7.Size      = new System.Drawing.Size(65, 52);
            this.btnK7.Tag       = "7";
            this.btnK7.Text      = "7";
            this.btnK7.UseVisualStyleBackColor = false;

            this.btnK8.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnK8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnK8.FlatAppearance.BorderSize  = 1;
            this.btnK8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnK8.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnK8.ForeColor = System.Drawing.Color.White;
            this.btnK8.Location  = new System.Drawing.Point(493, 106);
            this.btnK8.Name      = "btnK8";
            this.btnK8.Size      = new System.Drawing.Size(65, 52);
            this.btnK8.Tag       = "8";
            this.btnK8.Text      = "8";
            this.btnK8.UseVisualStyleBackColor = false;

            this.btnK9.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnK9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnK9.FlatAppearance.BorderSize  = 1;
            this.btnK9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnK9.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnK9.ForeColor = System.Drawing.Color.White;
            this.btnK9.Location  = new System.Drawing.Point(562, 106);
            this.btnK9.Name      = "btnK9";
            this.btnK9.Size      = new System.Drawing.Size(65, 52);
            this.btnK9.Tag       = "9";
            this.btnK9.Text      = "9";
            this.btnK9.UseVisualStyleBackColor = false;

            this.btnK0.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnK0.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnK0.FlatAppearance.BorderSize  = 1;
            this.btnK0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnK0.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnK0.ForeColor = System.Drawing.Color.White;
            this.btnK0.Location  = new System.Drawing.Point(631, 106);
            this.btnK0.Name      = "btnK0";
            this.btnK0.Size      = new System.Drawing.Size(65, 52);
            this.btnK0.Tag       = "0";
            this.btnK0.Text      = "0";
            this.btnK0.UseVisualStyleBackColor = false;
            //
            // ── Row 1 (y=162): Q W E R T Y U I O P ──
            //
            this.btnKQ.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKQ.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKQ.FlatAppearance.BorderSize  = 1;
            this.btnKQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKQ.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKQ.ForeColor = System.Drawing.Color.White;
            this.btnKQ.Location  = new System.Drawing.Point(10, 162);
            this.btnKQ.Name      = "btnKQ";
            this.btnKQ.Size      = new System.Drawing.Size(65, 52);
            this.btnKQ.Tag       = "Q";
            this.btnKQ.Text      = "Q";
            this.btnKQ.UseVisualStyleBackColor = false;

            this.btnKW.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKW.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKW.FlatAppearance.BorderSize  = 1;
            this.btnKW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKW.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKW.ForeColor = System.Drawing.Color.White;
            this.btnKW.Location  = new System.Drawing.Point(79, 162);
            this.btnKW.Name      = "btnKW";
            this.btnKW.Size      = new System.Drawing.Size(65, 52);
            this.btnKW.Tag       = "W";
            this.btnKW.Text      = "W";
            this.btnKW.UseVisualStyleBackColor = false;

            this.btnKE.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKE.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKE.FlatAppearance.BorderSize  = 1;
            this.btnKE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKE.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKE.ForeColor = System.Drawing.Color.White;
            this.btnKE.Location  = new System.Drawing.Point(148, 162);
            this.btnKE.Name      = "btnKE";
            this.btnKE.Size      = new System.Drawing.Size(65, 52);
            this.btnKE.Tag       = "E";
            this.btnKE.Text      = "E";
            this.btnKE.UseVisualStyleBackColor = false;

            this.btnKR.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKR.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKR.FlatAppearance.BorderSize  = 1;
            this.btnKR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKR.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKR.ForeColor = System.Drawing.Color.White;
            this.btnKR.Location  = new System.Drawing.Point(217, 162);
            this.btnKR.Name      = "btnKR";
            this.btnKR.Size      = new System.Drawing.Size(65, 52);
            this.btnKR.Tag       = "R";
            this.btnKR.Text      = "R";
            this.btnKR.UseVisualStyleBackColor = false;

            this.btnKT.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKT.FlatAppearance.BorderSize  = 1;
            this.btnKT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKT.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKT.ForeColor = System.Drawing.Color.White;
            this.btnKT.Location  = new System.Drawing.Point(286, 162);
            this.btnKT.Name      = "btnKT";
            this.btnKT.Size      = new System.Drawing.Size(65, 52);
            this.btnKT.Tag       = "T";
            this.btnKT.Text      = "T";
            this.btnKT.UseVisualStyleBackColor = false;

            this.btnKY.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKY.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKY.FlatAppearance.BorderSize  = 1;
            this.btnKY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKY.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKY.ForeColor = System.Drawing.Color.White;
            this.btnKY.Location  = new System.Drawing.Point(355, 162);
            this.btnKY.Name      = "btnKY";
            this.btnKY.Size      = new System.Drawing.Size(65, 52);
            this.btnKY.Tag       = "Y";
            this.btnKY.Text      = "Y";
            this.btnKY.UseVisualStyleBackColor = false;

            this.btnKU.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKU.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKU.FlatAppearance.BorderSize  = 1;
            this.btnKU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKU.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKU.ForeColor = System.Drawing.Color.White;
            this.btnKU.Location  = new System.Drawing.Point(424, 162);
            this.btnKU.Name      = "btnKU";
            this.btnKU.Size      = new System.Drawing.Size(65, 52);
            this.btnKU.Tag       = "U";
            this.btnKU.Text      = "U";
            this.btnKU.UseVisualStyleBackColor = false;

            this.btnKI.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKI.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKI.FlatAppearance.BorderSize  = 1;
            this.btnKI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKI.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKI.ForeColor = System.Drawing.Color.White;
            this.btnKI.Location  = new System.Drawing.Point(493, 162);
            this.btnKI.Name      = "btnKI";
            this.btnKI.Size      = new System.Drawing.Size(65, 52);
            this.btnKI.Tag       = "I";
            this.btnKI.Text      = "I";
            this.btnKI.UseVisualStyleBackColor = false;

            this.btnKO.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKO.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKO.FlatAppearance.BorderSize  = 1;
            this.btnKO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKO.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKO.ForeColor = System.Drawing.Color.White;
            this.btnKO.Location  = new System.Drawing.Point(562, 162);
            this.btnKO.Name      = "btnKO";
            this.btnKO.Size      = new System.Drawing.Size(65, 52);
            this.btnKO.Tag       = "O";
            this.btnKO.Text      = "O";
            this.btnKO.UseVisualStyleBackColor = false;

            this.btnKP.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKP.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKP.FlatAppearance.BorderSize  = 1;
            this.btnKP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKP.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKP.ForeColor = System.Drawing.Color.White;
            this.btnKP.Location  = new System.Drawing.Point(631, 162);
            this.btnKP.Name      = "btnKP";
            this.btnKP.Size      = new System.Drawing.Size(65, 52);
            this.btnKP.Tag       = "P";
            this.btnKP.Text      = "P";
            this.btnKP.UseVisualStyleBackColor = false;
            //
            // ── Row 2 (y=218): A S D F G H J K L . ──
            //
            this.btnKA.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKA.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKA.FlatAppearance.BorderSize  = 1;
            this.btnKA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKA.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKA.ForeColor = System.Drawing.Color.White;
            this.btnKA.Location  = new System.Drawing.Point(10, 218);
            this.btnKA.Name      = "btnKA";
            this.btnKA.Size      = new System.Drawing.Size(65, 52);
            this.btnKA.Tag       = "A";
            this.btnKA.Text      = "A";
            this.btnKA.UseVisualStyleBackColor = false;

            this.btnKS.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKS.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKS.FlatAppearance.BorderSize  = 1;
            this.btnKS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKS.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKS.ForeColor = System.Drawing.Color.White;
            this.btnKS.Location  = new System.Drawing.Point(79, 218);
            this.btnKS.Name      = "btnKS";
            this.btnKS.Size      = new System.Drawing.Size(65, 52);
            this.btnKS.Tag       = "S";
            this.btnKS.Text      = "S";
            this.btnKS.UseVisualStyleBackColor = false;

            this.btnKD.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKD.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKD.FlatAppearance.BorderSize  = 1;
            this.btnKD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKD.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKD.ForeColor = System.Drawing.Color.White;
            this.btnKD.Location  = new System.Drawing.Point(148, 218);
            this.btnKD.Name      = "btnKD";
            this.btnKD.Size      = new System.Drawing.Size(65, 52);
            this.btnKD.Tag       = "D";
            this.btnKD.Text      = "D";
            this.btnKD.UseVisualStyleBackColor = false;

            this.btnKF.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKF.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKF.FlatAppearance.BorderSize  = 1;
            this.btnKF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKF.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKF.ForeColor = System.Drawing.Color.White;
            this.btnKF.Location  = new System.Drawing.Point(217, 218);
            this.btnKF.Name      = "btnKF";
            this.btnKF.Size      = new System.Drawing.Size(65, 52);
            this.btnKF.Tag       = "F";
            this.btnKF.Text      = "F";
            this.btnKF.UseVisualStyleBackColor = false;

            this.btnKG.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKG.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKG.FlatAppearance.BorderSize  = 1;
            this.btnKG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKG.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKG.ForeColor = System.Drawing.Color.White;
            this.btnKG.Location  = new System.Drawing.Point(286, 218);
            this.btnKG.Name      = "btnKG";
            this.btnKG.Size      = new System.Drawing.Size(65, 52);
            this.btnKG.Tag       = "G";
            this.btnKG.Text      = "G";
            this.btnKG.UseVisualStyleBackColor = false;

            this.btnKH.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKH.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKH.FlatAppearance.BorderSize  = 1;
            this.btnKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKH.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKH.ForeColor = System.Drawing.Color.White;
            this.btnKH.Location  = new System.Drawing.Point(355, 218);
            this.btnKH.Name      = "btnKH";
            this.btnKH.Size      = new System.Drawing.Size(65, 52);
            this.btnKH.Tag       = "H";
            this.btnKH.Text      = "H";
            this.btnKH.UseVisualStyleBackColor = false;

            this.btnKJ.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKJ.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKJ.FlatAppearance.BorderSize  = 1;
            this.btnKJ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKJ.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKJ.ForeColor = System.Drawing.Color.White;
            this.btnKJ.Location  = new System.Drawing.Point(424, 218);
            this.btnKJ.Name      = "btnKJ";
            this.btnKJ.Size      = new System.Drawing.Size(65, 52);
            this.btnKJ.Tag       = "J";
            this.btnKJ.Text      = "J";
            this.btnKJ.UseVisualStyleBackColor = false;

            this.btnKK.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKK.FlatAppearance.BorderSize  = 1;
            this.btnKK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKK.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKK.ForeColor = System.Drawing.Color.White;
            this.btnKK.Location  = new System.Drawing.Point(493, 218);
            this.btnKK.Name      = "btnKK";
            this.btnKK.Size      = new System.Drawing.Size(65, 52);
            this.btnKK.Tag       = "K";
            this.btnKK.Text      = "K";
            this.btnKK.UseVisualStyleBackColor = false;

            this.btnKL.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKL.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKL.FlatAppearance.BorderSize  = 1;
            this.btnKL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKL.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKL.ForeColor = System.Drawing.Color.White;
            this.btnKL.Location  = new System.Drawing.Point(562, 218);
            this.btnKL.Name      = "btnKL";
            this.btnKL.Size      = new System.Drawing.Size(65, 52);
            this.btnKL.Tag       = "L";
            this.btnKL.Text      = "L";
            this.btnKL.UseVisualStyleBackColor = false;

            this.btnKDot.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKDot.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKDot.FlatAppearance.BorderSize  = 1;
            this.btnKDot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKDot.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKDot.ForeColor = System.Drawing.Color.White;
            this.btnKDot.Location  = new System.Drawing.Point(631, 218);
            this.btnKDot.Name      = "btnKDot";
            this.btnKDot.Size      = new System.Drawing.Size(65, 52);
            this.btnKDot.Tag       = ".";
            this.btnKDot.Text      = ".";
            this.btnKDot.UseVisualStyleBackColor = false;
            //
            // ── Row 3 (y=274): Z X C V B N M - / _ ──
            //
            this.btnKZ.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKZ.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKZ.FlatAppearance.BorderSize  = 1;
            this.btnKZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKZ.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKZ.ForeColor = System.Drawing.Color.White;
            this.btnKZ.Location  = new System.Drawing.Point(10, 274);
            this.btnKZ.Name      = "btnKZ";
            this.btnKZ.Size      = new System.Drawing.Size(65, 52);
            this.btnKZ.Tag       = "Z";
            this.btnKZ.Text      = "Z";
            this.btnKZ.UseVisualStyleBackColor = false;

            this.btnKX.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKX.FlatAppearance.BorderSize  = 1;
            this.btnKX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKX.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKX.ForeColor = System.Drawing.Color.White;
            this.btnKX.Location  = new System.Drawing.Point(79, 274);
            this.btnKX.Name      = "btnKX";
            this.btnKX.Size      = new System.Drawing.Size(65, 52);
            this.btnKX.Tag       = "X";
            this.btnKX.Text      = "X";
            this.btnKX.UseVisualStyleBackColor = false;

            this.btnKC.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKC.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKC.FlatAppearance.BorderSize  = 1;
            this.btnKC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKC.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKC.ForeColor = System.Drawing.Color.White;
            this.btnKC.Location  = new System.Drawing.Point(148, 274);
            this.btnKC.Name      = "btnKC";
            this.btnKC.Size      = new System.Drawing.Size(65, 52);
            this.btnKC.Tag       = "C";
            this.btnKC.Text      = "C";
            this.btnKC.UseVisualStyleBackColor = false;

            this.btnKV.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKV.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKV.FlatAppearance.BorderSize  = 1;
            this.btnKV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKV.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKV.ForeColor = System.Drawing.Color.White;
            this.btnKV.Location  = new System.Drawing.Point(217, 274);
            this.btnKV.Name      = "btnKV";
            this.btnKV.Size      = new System.Drawing.Size(65, 52);
            this.btnKV.Tag       = "V";
            this.btnKV.Text      = "V";
            this.btnKV.UseVisualStyleBackColor = false;

            this.btnKB.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKB.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKB.FlatAppearance.BorderSize  = 1;
            this.btnKB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKB.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKB.ForeColor = System.Drawing.Color.White;
            this.btnKB.Location  = new System.Drawing.Point(286, 274);
            this.btnKB.Name      = "btnKB";
            this.btnKB.Size      = new System.Drawing.Size(65, 52);
            this.btnKB.Tag       = "B";
            this.btnKB.Text      = "B";
            this.btnKB.UseVisualStyleBackColor = false;

            this.btnKN.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKN.FlatAppearance.BorderSize  = 1;
            this.btnKN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKN.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKN.ForeColor = System.Drawing.Color.White;
            this.btnKN.Location  = new System.Drawing.Point(355, 274);
            this.btnKN.Name      = "btnKN";
            this.btnKN.Size      = new System.Drawing.Size(65, 52);
            this.btnKN.Tag       = "N";
            this.btnKN.Text      = "N";
            this.btnKN.UseVisualStyleBackColor = false;

            this.btnKM.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKM.FlatAppearance.BorderSize  = 1;
            this.btnKM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKM.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKM.ForeColor = System.Drawing.Color.White;
            this.btnKM.Location  = new System.Drawing.Point(424, 274);
            this.btnKM.Name      = "btnKM";
            this.btnKM.Size      = new System.Drawing.Size(65, 52);
            this.btnKM.Tag       = "M";
            this.btnKM.Text      = "M";
            this.btnKM.UseVisualStyleBackColor = false;

            this.btnKMinus.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKMinus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKMinus.FlatAppearance.BorderSize  = 1;
            this.btnKMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKMinus.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKMinus.ForeColor = System.Drawing.Color.White;
            this.btnKMinus.Location  = new System.Drawing.Point(493, 274);
            this.btnKMinus.Name      = "btnKMinus";
            this.btnKMinus.Size      = new System.Drawing.Size(65, 52);
            this.btnKMinus.Tag       = "-";
            this.btnKMinus.Text      = "-";
            this.btnKMinus.UseVisualStyleBackColor = false;

            this.btnKSlash.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKSlash.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKSlash.FlatAppearance.BorderSize  = 1;
            this.btnKSlash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKSlash.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKSlash.ForeColor = System.Drawing.Color.White;
            this.btnKSlash.Location  = new System.Drawing.Point(562, 274);
            this.btnKSlash.Name      = "btnKSlash";
            this.btnKSlash.Size      = new System.Drawing.Size(65, 52);
            this.btnKSlash.Tag       = "/";
            this.btnKSlash.Text      = "/";
            this.btnKSlash.UseVisualStyleBackColor = false;

            this.btnKUnderscore.BackColor = System.Drawing.Color.FromArgb(68, 68, 76);
            this.btnKUnderscore.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(95, 95, 105);
            this.btnKUnderscore.FlatAppearance.BorderSize  = 1;
            this.btnKUnderscore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKUnderscore.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnKUnderscore.ForeColor = System.Drawing.Color.White;
            this.btnKUnderscore.Location  = new System.Drawing.Point(631, 274);
            this.btnKUnderscore.Name      = "btnKUnderscore";
            this.btnKUnderscore.Size      = new System.Drawing.Size(65, 52);
            this.btnKUnderscore.Tag       = "_";
            this.btnKUnderscore.Text      = "_";
            this.btnKUnderscore.UseVisualStyleBackColor = false;
            //
            // ── 하단 컨트롤 버튼 (y=336, h=54, w=166) ──
            // bx(0)=10  bx(1)=184  bx(2)=358  bx(3)=532
            //
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(100, 55, 55);
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location  = new System.Drawing.Point(10, 336);
            this.btnBack.Name      = "btnBack";
            this.btnBack.Size      = new System.Drawing.Size(166, 54);
            this.btnBack.Text      = "← 삭제";
            this.btnBack.UseVisualStyleBackColor = false;

            this.btnClear.BackColor = System.Drawing.Color.FromArgb(110, 60, 0);
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location  = new System.Drawing.Point(184, 336);
            this.btnClear.Name      = "btnClear";
            this.btnClear.Size      = new System.Drawing.Size(166, 54);
            this.btnClear.Text      = "전체 삭제";
            this.btnClear.UseVisualStyleBackColor = false;

            this.btnOk.BackColor = System.Drawing.Color.FromArgb(0, 115, 55);
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location  = new System.Drawing.Point(358, 336);
            this.btnOk.Name      = "btnOk";
            this.btnOk.Size      = new System.Drawing.Size(166, 54);
            this.btnOk.Text      = "확  인";
            this.btnOk.UseVisualStyleBackColor = false;

            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(72, 72, 78);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location  = new System.Drawing.Point(532, 336);
            this.btnCancel.Name      = "btnCancel";
            this.btnCancel.Size      = new System.Drawing.Size(166, 54);
            this.btnCancel.Text      = "취  소";
            this.btnCancel.UseVisualStyleBackColor = false;
            //
            // InputKeypadForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(35, 35, 40);
            this.ClientSize          = new System.Drawing.Size(710, 398);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnKUnderscore);
            this.Controls.Add(this.btnKSlash);
            this.Controls.Add(this.btnKMinus);
            this.Controls.Add(this.btnKM);
            this.Controls.Add(this.btnKN);
            this.Controls.Add(this.btnKB);
            this.Controls.Add(this.btnKV);
            this.Controls.Add(this.btnKC);
            this.Controls.Add(this.btnKX);
            this.Controls.Add(this.btnKZ);
            this.Controls.Add(this.btnKDot);
            this.Controls.Add(this.btnKL);
            this.Controls.Add(this.btnKK);
            this.Controls.Add(this.btnKJ);
            this.Controls.Add(this.btnKH);
            this.Controls.Add(this.btnKG);
            this.Controls.Add(this.btnKF);
            this.Controls.Add(this.btnKD);
            this.Controls.Add(this.btnKS);
            this.Controls.Add(this.btnKA);
            this.Controls.Add(this.btnKP);
            this.Controls.Add(this.btnKO);
            this.Controls.Add(this.btnKI);
            this.Controls.Add(this.btnKU);
            this.Controls.Add(this.btnKY);
            this.Controls.Add(this.btnKT);
            this.Controls.Add(this.btnKR);
            this.Controls.Add(this.btnKE);
            this.Controls.Add(this.btnKW);
            this.Controls.Add(this.btnKQ);
            this.Controls.Add(this.btnK0);
            this.Controls.Add(this.btnK9);
            this.Controls.Add(this.btnK8);
            this.Controls.Add(this.btnK7);
            this.Controls.Add(this.btnK6);
            this.Controls.Add(this.btnK5);
            this.Controls.Add(this.btnK4);
            this.Controls.Add(this.btnK3);
            this.Controls.Add(this.btnK2);
            this.Controls.Add(this.btnK1);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name            = "InputKeypadForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost         = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Button  btnK1;
        private System.Windows.Forms.Button  btnK2;
        private System.Windows.Forms.Button  btnK3;
        private System.Windows.Forms.Button  btnK4;
        private System.Windows.Forms.Button  btnK5;
        private System.Windows.Forms.Button  btnK6;
        private System.Windows.Forms.Button  btnK7;
        private System.Windows.Forms.Button  btnK8;
        private System.Windows.Forms.Button  btnK9;
        private System.Windows.Forms.Button  btnK0;
        private System.Windows.Forms.Button  btnKQ;
        private System.Windows.Forms.Button  btnKW;
        private System.Windows.Forms.Button  btnKE;
        private System.Windows.Forms.Button  btnKR;
        private System.Windows.Forms.Button  btnKT;
        private System.Windows.Forms.Button  btnKY;
        private System.Windows.Forms.Button  btnKU;
        private System.Windows.Forms.Button  btnKI;
        private System.Windows.Forms.Button  btnKO;
        private System.Windows.Forms.Button  btnKP;
        private System.Windows.Forms.Button  btnKA;
        private System.Windows.Forms.Button  btnKS;
        private System.Windows.Forms.Button  btnKD;
        private System.Windows.Forms.Button  btnKF;
        private System.Windows.Forms.Button  btnKG;
        private System.Windows.Forms.Button  btnKH;
        private System.Windows.Forms.Button  btnKJ;
        private System.Windows.Forms.Button  btnKK;
        private System.Windows.Forms.Button  btnKL;
        private System.Windows.Forms.Button  btnKDot;
        private System.Windows.Forms.Button  btnKZ;
        private System.Windows.Forms.Button  btnKX;
        private System.Windows.Forms.Button  btnKC;
        private System.Windows.Forms.Button  btnKV;
        private System.Windows.Forms.Button  btnKB;
        private System.Windows.Forms.Button  btnKN;
        private System.Windows.Forms.Button  btnKM;
        private System.Windows.Forms.Button  btnKMinus;
        private System.Windows.Forms.Button  btnKSlash;
        private System.Windows.Forms.Button  btnKUnderscore;
        private System.Windows.Forms.Button  btnBack;
        private System.Windows.Forms.Button  btnClear;
        private System.Windows.Forms.Button  btnOk;
        private System.Windows.Forms.Button  btnCancel;
    }
}
