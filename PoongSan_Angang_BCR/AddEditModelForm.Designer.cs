namespace PoongSan_Angang_BCR
{
    partial class AddEditModelForm
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
            this.lblTitle     = new System.Windows.Forms.Label();
            this.lblHint      = new System.Windows.Forms.Label();
            // separators
            this.sep0         = new System.Windows.Forms.Panel();
            this.sep1         = new System.Windows.Forms.Panel();
            this.sep2         = new System.Windows.Forms.Panel();
            this.sep3         = new System.Windows.Forms.Panel();
            this.sep4         = new System.Windows.Forms.Panel();
            this.sep5         = new System.Windows.Forms.Panel();
            this.sep6         = new System.Windows.Forms.Panel();
            this.sep7         = new System.Windows.Forms.Panel();
            // row labels
            this.lbl0         = new System.Windows.Forms.Label();
            this.lbl1         = new System.Windows.Forms.Label();
            this.lbl2         = new System.Windows.Forms.Label();
            this.lbl3         = new System.Windows.Forms.Label();
            this.lbl4         = new System.Windows.Forms.Label();
            this.lbl5         = new System.Windows.Forms.Label();
            this.lbl6         = new System.Windows.Forms.Label();
            // text boxes
            this.txtBore      = new System.Windows.Forms.TextBox();
            this.txtBullet    = new System.Windows.Forms.TextBox();
            this.txtCartonA   = new System.Windows.Forms.TextBox();
            this.txtCartonE   = new System.Windows.Forms.TextBox();
            this.txtBox       = new System.Windows.Forms.TextBox();
            this.txtWeightMin = new System.Windows.Forms.TextBox();
            this.txtWeightMax = new System.Windows.Forms.TextBox();
            // buttons
            this.btnOk        = new System.Windows.Forms.Button();
            this.btnCancel    = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle  (formW=820, h=52)
            //
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTitle.Font      = new System.Drawing.Font("굴림", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(0, 0);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Size      = new System.Drawing.Size(700, 44);
            this.lblTitle.Text      = "신규 모델 추가";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblHint  (y=52)
            //
            this.lblHint.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.lblHint.Font      = new System.Drawing.Font("굴림", 10F);
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(100, 120, 140);
            this.lblHint.Location  = new System.Drawing.Point(6, 44);
            this.lblHint.Name      = "lblHint";
            this.lblHint.Size      = new System.Drawing.Size(692, 18);
            this.lblHint.Text      = "▶  각 항목을 터치하여 값을 입력하세요";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // ── Row 0: 구경  (y=58) ──
            //
            this.sep0.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.sep0.Location  = new System.Drawing.Point(0, 50);
            this.sep0.Name      = "sep0";
            this.sep0.Size      = new System.Drawing.Size(700, 1);

            this.lbl0.BackColor = System.Drawing.Color.FromArgb(235, 245, 255);
            this.lbl0.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.lbl0.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lbl0.Location  = new System.Drawing.Point(0, 51);
            this.lbl0.Name      = "lbl0";
            this.lbl0.Size      = new System.Drawing.Size(154, 50);
            this.lbl0.Text      = "구경";
            this.lbl0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.txtBore.BackColor   = System.Drawing.Color.White;
            this.txtBore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBore.Cursor      = System.Windows.Forms.Cursors.Hand;
            this.txtBore.Font        = new System.Drawing.Font("굴림", 14F);
            this.txtBore.ForeColor   = System.Drawing.Color.FromArgb(31, 97, 141);
            this.txtBore.Location    = new System.Drawing.Point(168, 58);
            this.txtBore.Name        = "txtBore";
            this.txtBore.ReadOnly    = true;
            this.txtBore.Size        = new System.Drawing.Size(523, 36);
            this.txtBore.TabIndex    = 0;
            this.txtBore.TextAlign   = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // ── Row 1: 탄종  (y=118) ──
            //
            this.sep1.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.sep1.Location  = new System.Drawing.Point(0, 101);
            this.sep1.Name      = "sep1";
            this.sep1.Size      = new System.Drawing.Size(700, 1);

            this.lbl1.BackColor = System.Drawing.Color.FromArgb(235, 245, 255);
            this.lbl1.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.lbl1.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lbl1.Location  = new System.Drawing.Point(0, 102);
            this.lbl1.Name      = "lbl1";
            this.lbl1.Size      = new System.Drawing.Size(154, 50);
            this.lbl1.Text      = "탄종";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.txtBullet.BackColor   = System.Drawing.Color.White;
            this.txtBullet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBullet.Cursor      = System.Windows.Forms.Cursors.Hand;
            this.txtBullet.Font        = new System.Drawing.Font("굴림", 14F);
            this.txtBullet.ForeColor   = System.Drawing.Color.FromArgb(31, 97, 141);
            this.txtBullet.Location    = new System.Drawing.Point(168, 109);
            this.txtBullet.Name        = "txtBullet";
            this.txtBullet.ReadOnly    = true;
            this.txtBullet.Size        = new System.Drawing.Size(523, 36);
            this.txtBullet.TabIndex    = 1;
            this.txtBullet.TextAlign   = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // ── Row 2: 카톤 BCD (미국)  (y=178) ──
            //
            this.sep2.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.sep2.Location  = new System.Drawing.Point(0, 152);
            this.sep2.Name      = "sep2";
            this.sep2.Size      = new System.Drawing.Size(700, 1);

            this.lbl2.BackColor = System.Drawing.Color.FromArgb(235, 245, 255);
            this.lbl2.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.lbl2.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lbl2.Location  = new System.Drawing.Point(0, 153);
            this.lbl2.Name      = "lbl2";
            this.lbl2.Size      = new System.Drawing.Size(154, 50);
            this.lbl2.Text      = "카톤 BCD (미국)";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.txtCartonA.BackColor   = System.Drawing.Color.White;
            this.txtCartonA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCartonA.Cursor      = System.Windows.Forms.Cursors.Hand;
            this.txtCartonA.Font        = new System.Drawing.Font("굴림", 14F);
            this.txtCartonA.ForeColor   = System.Drawing.Color.FromArgb(31, 97, 141);
            this.txtCartonA.Location    = new System.Drawing.Point(168, 160);
            this.txtCartonA.Name        = "txtCartonA";
            this.txtCartonA.ReadOnly    = true;
            this.txtCartonA.Size        = new System.Drawing.Size(523, 36);
            this.txtCartonA.TabIndex    = 2;
            this.txtCartonA.TextAlign   = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // ── Row 3: 카톤 BCD (유럽)  (y=238) ──
            //
            this.sep3.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.sep3.Location  = new System.Drawing.Point(0, 203);
            this.sep3.Name      = "sep3";
            this.sep3.Size      = new System.Drawing.Size(700, 1);

            this.lbl3.BackColor = System.Drawing.Color.FromArgb(235, 245, 255);
            this.lbl3.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.lbl3.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lbl3.Location  = new System.Drawing.Point(0, 204);
            this.lbl3.Name      = "lbl3";
            this.lbl3.Size      = new System.Drawing.Size(154, 50);
            this.lbl3.Text      = "카톤 BCD (유럽)";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.txtCartonE.BackColor   = System.Drawing.Color.White;
            this.txtCartonE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCartonE.Cursor      = System.Windows.Forms.Cursors.Hand;
            this.txtCartonE.Font        = new System.Drawing.Font("굴림", 14F);
            this.txtCartonE.ForeColor   = System.Drawing.Color.FromArgb(31, 97, 141);
            this.txtCartonE.Location    = new System.Drawing.Point(168, 211);
            this.txtCartonE.Name        = "txtCartonE";
            this.txtCartonE.ReadOnly    = true;
            this.txtCartonE.Size        = new System.Drawing.Size(523, 36);
            this.txtCartonE.TabIndex    = 3;
            this.txtCartonE.TextAlign   = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // ── Row 4: 골판지 BCD  (y=298) ──
            //
            this.sep4.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.sep4.Location  = new System.Drawing.Point(0, 254);
            this.sep4.Name      = "sep4";
            this.sep4.Size      = new System.Drawing.Size(700, 1);

            this.lbl4.BackColor = System.Drawing.Color.FromArgb(235, 245, 255);
            this.lbl4.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.lbl4.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lbl4.Location  = new System.Drawing.Point(0, 255);
            this.lbl4.Name      = "lbl4";
            this.lbl4.Size      = new System.Drawing.Size(154, 50);
            this.lbl4.Text      = "골판지 BCD";
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.txtBox.BackColor   = System.Drawing.Color.White;
            this.txtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBox.Cursor      = System.Windows.Forms.Cursors.Hand;
            this.txtBox.Font        = new System.Drawing.Font("굴림", 14F);
            this.txtBox.ForeColor   = System.Drawing.Color.FromArgb(31, 97, 141);
            this.txtBox.Location    = new System.Drawing.Point(168, 262);
            this.txtBox.Name        = "txtBox";
            this.txtBox.ReadOnly    = true;
            this.txtBox.Size        = new System.Drawing.Size(523, 36);
            this.txtBox.TabIndex    = 4;
            this.txtBox.TextAlign   = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // ── Row 5: 무게 최소  (y=358) ──
            //
            this.sep5.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.sep5.Location  = new System.Drawing.Point(0, 305);
            this.sep5.Name      = "sep5";
            this.sep5.Size      = new System.Drawing.Size(700, 1);

            this.lbl5.BackColor = System.Drawing.Color.FromArgb(235, 245, 255);
            this.lbl5.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.lbl5.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lbl5.Location  = new System.Drawing.Point(0, 306);
            this.lbl5.Name      = "lbl5";
            this.lbl5.Size      = new System.Drawing.Size(154, 50);
            this.lbl5.Text      = "무게 최소";
            this.lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.txtWeightMin.BackColor   = System.Drawing.Color.White;
            this.txtWeightMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWeightMin.Cursor      = System.Windows.Forms.Cursors.Hand;
            this.txtWeightMin.Font        = new System.Drawing.Font("굴림", 14F);
            this.txtWeightMin.ForeColor   = System.Drawing.Color.FromArgb(31, 97, 141);
            this.txtWeightMin.Location    = new System.Drawing.Point(168, 313);
            this.txtWeightMin.Name        = "txtWeightMin";
            this.txtWeightMin.ReadOnly    = true;
            this.txtWeightMin.Size        = new System.Drawing.Size(523, 36);
            this.txtWeightMin.TabIndex    = 5;
            this.txtWeightMin.TextAlign   = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // ── Row 6: 무게 최대  (y=418) ──
            //
            this.sep6.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.sep6.Location  = new System.Drawing.Point(0, 356);
            this.sep6.Name      = "sep6";
            this.sep6.Size      = new System.Drawing.Size(700, 1);

            this.lbl6.BackColor = System.Drawing.Color.FromArgb(235, 245, 255);
            this.lbl6.Font      = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.lbl6.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lbl6.Location  = new System.Drawing.Point(0, 357);
            this.lbl6.Name      = "lbl6";
            this.lbl6.Size      = new System.Drawing.Size(154, 50);
            this.lbl6.Text      = "무게 최대";
            this.lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.txtWeightMax.BackColor   = System.Drawing.Color.White;
            this.txtWeightMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWeightMax.Cursor      = System.Windows.Forms.Cursors.Hand;
            this.txtWeightMax.Font        = new System.Drawing.Font("굴림", 14F);
            this.txtWeightMax.ForeColor   = System.Drawing.Color.FromArgb(31, 97, 141);
            this.txtWeightMax.Location    = new System.Drawing.Point(168, 364);
            this.txtWeightMax.Name        = "txtWeightMax";
            this.txtWeightMax.ReadOnly    = true;
            this.txtWeightMax.Size        = new System.Drawing.Size(523, 36);
            this.txtWeightMax.TabIndex    = 6;
            this.txtWeightMax.TextAlign   = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // sep7 — 마지막 구분선  (y=478)
            //
            this.sep7.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.sep7.Location  = new System.Drawing.Point(0, 407);
            this.sep7.Name      = "sep7";
            this.sep7.Size      = new System.Drawing.Size(700, 1);
            //
            // btnOk  (x=444, y=488)
            //
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font      = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location  = new System.Drawing.Point(379, 417);
            this.btnOk.Name      = "btnOk";
            this.btnOk.Size      = new System.Drawing.Size(154, 50);
            this.btnOk.TabIndex  = 10;
            this.btnOk.Text      = "추  가";
            this.btnOk.UseVisualStyleBackColor = false;
            //
            // btnCancel  (x=636, y=488)
            //
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font      = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location  = new System.Drawing.Point(543, 417);
            this.btnCancel.Name      = "btnCancel";
            this.btnCancel.Size      = new System.Drawing.Size(154, 50);
            this.btnCancel.TabIndex  = 11;
            this.btnCancel.Text      = "취  소";
            this.btnCancel.UseVisualStyleBackColor = false;
            //
            // AddEditModelForm
            //
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor           = System.Drawing.Color.FromArgb(240, 244, 248);
            this.ClientSize          = new System.Drawing.Size(700, 470);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.sep7);
            this.Controls.Add(this.txtWeightMax);
            this.Controls.Add(this.lbl6);
            this.Controls.Add(this.sep6);
            this.Controls.Add(this.txtWeightMin);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.sep5);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.sep4);
            this.Controls.Add(this.txtCartonE);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.sep3);
            this.Controls.Add(this.txtCartonA);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.sep2);
            this.Controls.Add(this.txtBullet);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.sep1);
            this.Controls.Add(this.txtBore);
            this.Controls.Add(this.lbl0);
            this.Controls.Add(this.sep0);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name            = "AddEditModelForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost         = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Label   lblHint;
        private System.Windows.Forms.Panel   sep0;
        private System.Windows.Forms.Panel   sep1;
        private System.Windows.Forms.Panel   sep2;
        private System.Windows.Forms.Panel   sep3;
        private System.Windows.Forms.Panel   sep4;
        private System.Windows.Forms.Panel   sep5;
        private System.Windows.Forms.Panel   sep6;
        private System.Windows.Forms.Panel   sep7;
        private System.Windows.Forms.Label   lbl0;
        private System.Windows.Forms.Label   lbl1;
        private System.Windows.Forms.Label   lbl2;
        private System.Windows.Forms.Label   lbl3;
        private System.Windows.Forms.Label   lbl4;
        private System.Windows.Forms.Label   lbl5;
        private System.Windows.Forms.Label   lbl6;
        private System.Windows.Forms.TextBox txtBore;
        private System.Windows.Forms.TextBox txtBullet;
        private System.Windows.Forms.TextBox txtCartonA;
        private System.Windows.Forms.TextBox txtCartonE;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.TextBox txtWeightMin;
        private System.Windows.Forms.TextBox txtWeightMax;
        private System.Windows.Forms.Button  btnOk;
        private System.Windows.Forms.Button  btnCancel;
    }
}
