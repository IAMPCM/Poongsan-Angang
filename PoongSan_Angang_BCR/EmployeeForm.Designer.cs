namespace PoongSan_Angang_BCR
{
    partial class EmployeeForm
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
            this.btnClose   = new System.Windows.Forms.Button();
            this._listBox   = new System.Windows.Forms.ListBox();
            this.btnSelect  = new System.Windows.Forms.Button();
            this.btnAdd     = new System.Windows.Forms.Button();
            this.btnDelete  = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTitle.Font      = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(20, 12);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Size      = new System.Drawing.Size(410, 44);
            this.lblTitle.Text      = "사번 관리";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnClose
            //
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font      = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location  = new System.Drawing.Point(341, 320);
            this.btnClose.Name      = "btnClose";
            this.btnClose.Size      = new System.Drawing.Size(99, 55);
            this.btnClose.Text      = "닫  기";
            this.btnClose.UseVisualStyleBackColor = false;
            //
            // _listBox
            //
            this._listBox.BackColor   = System.Drawing.Color.FromArgb(240, 240, 240);
            this._listBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._listBox.Font        = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this._listBox.ForeColor   = System.Drawing.Color.Black;
            this._listBox.Location    = new System.Drawing.Point(20, 65);
            this._listBox.Name        = "_listBox";
            this._listBox.Size        = new System.Drawing.Size(420, 240);
            //
            // btnSelect
            //
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSelect.FlatAppearance.BorderSize = 0;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font      = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Location  = new System.Drawing.Point(20, 320);
            this.btnSelect.Name      = "btnSelect";
            this.btnSelect.Size      = new System.Drawing.Size(99, 55);
            this.btnSelect.Text      = "출근 선택";
            this.btnSelect.UseVisualStyleBackColor = false;
            //
            // btnAdd
            //
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font      = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location  = new System.Drawing.Point(127, 320);
            this.btnAdd.Name      = "btnAdd";
            this.btnAdd.Size      = new System.Drawing.Size(99, 55);
            this.btnAdd.Text      = "추  가";
            this.btnAdd.UseVisualStyleBackColor = false;
            //
            // btnDelete
            //
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font      = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location  = new System.Drawing.Point(234, 320);
            this.btnDelete.Name      = "btnDelete";
            this.btnDelete.Size      = new System.Drawing.Size(99, 55);
            this.btnDelete.Text      = "삭  제";
            this.btnDelete.UseVisualStyleBackColor = false;
            //
            // EmployeeForm
            //
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor           = System.Drawing.Color.FromArgb(240, 244, 248);
            this.ClientSize          = new System.Drawing.Size(460, 400);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this._listBox);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name            = "EmployeeForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "사번 관리";
            this.TopMost         = true;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Button  btnClose;
        private System.Windows.Forms.ListBox _listBox;
        private System.Windows.Forms.Button  btnSelect;
        private System.Windows.Forms.Button  btnAdd;
        private System.Windows.Forms.Button  btnDelete;
    }
}
