
namespace PoongSan_Angang_BCR
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lb_MachineName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_Result = new System.Windows.Forms.Label();
            this.cboBore = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboBullet = new System.Windows.Forms.ComboBox();
            this.cboLocal = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCartonBCD = new System.Windows.Forms.Label();
            this.txtBoxBCD = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtInputCartonBCD = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_TimeoutToggle = new System.Windows.Forms.Button();
            this.btn_ModelSetting = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label_PLC_Status = new System.Windows.Forms.Label();
            this.txtInputBoxBCD = new System.Windows.Forms.Label();
            this.txtHiddenInput = new System.Windows.Forms.TextBox();
            this.txtInputBCR = new System.Windows.Forms.TextBox();
            this.btn_ChangePassword = new System.Windows.Forms.Button();
            this.btnResetCount = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_MachineName
            // 
            this.lb_MachineName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.lb_MachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_MachineName.Font = new System.Drawing.Font("굴림", 40F, System.Drawing.FontStyle.Bold);
            this.lb_MachineName.ForeColor = System.Drawing.SystemColors.Window;
            this.lb_MachineName.Location = new System.Drawing.Point(3, 2);
            this.lb_MachineName.Name = "lb_MachineName";
            this.lb_MachineName.Size = new System.Drawing.Size(1852, 140);
            this.lb_MachineName.TabIndex = 120;
            this.lb_MachineName.Text = "자동 검사 장비";
            this.lb_MachineName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(501, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 121;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Exit.Location = new System.Drawing.Point(1699, 45);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(141, 62);
            this.btn_Exit.TabIndex = 131;
            this.btn_Exit.Text = "종료";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.SystemColors.Window;
            this.label18.Location = new System.Drawing.Point(1, 248);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(671, 101);
            this.label18.TabIndex = 145;
            this.label18.Text = "구경";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(1, 1287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(671, 106);
            this.label3.TabIndex = 151;
            this.label3.Text = "매칭 결과";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Result
            // 
            this.lb_Result.BackColor = System.Drawing.Color.White;
            this.lb_Result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Result.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Bold);
            this.lb_Result.ForeColor = System.Drawing.Color.Black;
            this.lb_Result.Location = new System.Drawing.Point(676, 1287);
            this.lb_Result.Name = "lb_Result";
            this.lb_Result.Size = new System.Drawing.Size(1178, 106);
            this.lb_Result.TabIndex = 152;
            this.lb_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboBore
            // 
            this.cboBore.Font = new System.Drawing.Font("굴림", 45F);
            this.cboBore.FormattingEnabled = true;
            this.cboBore.Location = new System.Drawing.Point(676, 248);
            this.cboBore.Margin = new System.Windows.Forms.Padding(4);
            this.cboBore.Name = "cboBore";
            this.cboBore.Size = new System.Drawing.Size(1178, 98);
            this.cboBore.TabIndex = 153;
            this.cboBore.SelectedIndexChanged += new System.EventHandler(this.cboBore_SelectedIndexChanged);
            this.cboBore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cboBore_MouseDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(1, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(671, 101);
            this.label1.TabIndex = 154;
            this.label1.Text = "탄종";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboBullet
            // 
            this.cboBullet.Font = new System.Drawing.Font("굴림", 45F);
            this.cboBullet.FormattingEnabled = true;
            this.cboBullet.Location = new System.Drawing.Point(676, 351);
            this.cboBullet.Margin = new System.Windows.Forms.Padding(4);
            this.cboBullet.Name = "cboBullet";
            this.cboBullet.Size = new System.Drawing.Size(1178, 98);
            this.cboBullet.TabIndex = 155;
            this.cboBullet.SelectedIndexChanged += new System.EventHandler(this.cboBullet_SelectedIndexChanged);
            this.cboBullet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cboBullet_MouseDown);
            // 
            // cboLocal
            // 
            this.cboLocal.Font = new System.Drawing.Font("굴림", 45F);
            this.cboLocal.FormattingEnabled = true;
            this.cboLocal.Location = new System.Drawing.Point(676, 454);
            this.cboLocal.Margin = new System.Windows.Forms.Padding(4);
            this.cboLocal.Name = "cboLocal";
            this.cboLocal.Size = new System.Drawing.Size(1178, 98);
            this.cboLocal.TabIndex = 157;
            this.cboLocal.SelectedIndexChanged += new System.EventHandler(this.cboLocal_SelectedIndexChanged);
            this.cboLocal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cboLocal_MouseDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(1, 454);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(671, 101);
            this.label2.TabIndex = 156;
            this.label2.Text = "미국(A)/유럽(E)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(1, 662);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(669, 101);
            this.label4.TabIndex = 158;
            this.label4.Text = "카톤 박스 바코드 (설정)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(1, 765);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(669, 101);
            this.label7.TabIndex = 159;
            this.label7.Text = "골판지 박스 바코드 (설정)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtCartonBCD
            // 
            this.txtCartonBCD.BackColor = System.Drawing.Color.White;
            this.txtCartonBCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCartonBCD.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Bold);
            this.txtCartonBCD.ForeColor = System.Drawing.Color.Black;
            this.txtCartonBCD.Location = new System.Drawing.Point(676, 662);
            this.txtCartonBCD.Name = "txtCartonBCD";
            this.txtCartonBCD.Size = new System.Drawing.Size(1179, 101);
            this.txtCartonBCD.TabIndex = 160;
            this.txtCartonBCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxBCD
            // 
            this.txtBoxBCD.BackColor = System.Drawing.Color.White;
            this.txtBoxBCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxBCD.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Bold);
            this.txtBoxBCD.ForeColor = System.Drawing.Color.Black;
            this.txtBoxBCD.Location = new System.Drawing.Point(676, 765);
            this.txtBoxBCD.Name = "txtBoxBCD";
            this.txtBoxBCD.Size = new System.Drawing.Size(1179, 101);
            this.txtBoxBCD.TabIndex = 161;
            this.txtBoxBCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.Window;
            this.label10.Location = new System.Drawing.Point(3, 1076);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(669, 101);
            this.label10.TabIndex = 163;
            this.label10.Text = "골판지 박스 바코드 (입력)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.Window;
            this.label11.Location = new System.Drawing.Point(3, 972);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(669, 101);
            this.label11.TabIndex = 162;
            this.label11.Text = "카톤 박스 바코드 (입력)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(261, 48);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 62);
            this.button1.TabIndex = 166;
            this.button1.Text = "Buzzer Off";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.Window;
            this.label12.Location = new System.Drawing.Point(1, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1853, 101);
            this.label12.TabIndex = 167;
            this.label12.Text = "생산 모델";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.Window;
            this.label13.Location = new System.Drawing.Point(3, 868);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(1851, 101);
            this.label13.TabIndex = 168;
            this.label13.Text = "바코드 입력";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(169, 48);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 62);
            this.button2.TabIndex = 169;
            this.button2.Text = "시스템";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // txtInputCartonBCD
            // 
            this.txtInputCartonBCD.BackColor = System.Drawing.Color.White;
            this.txtInputCartonBCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInputCartonBCD.Font = new System.Drawing.Font("굴림", 30F);
            this.txtInputCartonBCD.Location = new System.Drawing.Point(676, 973);
            this.txtInputCartonBCD.Margin = new System.Windows.Forms.Padding(4);
            this.txtInputCartonBCD.Name = "txtInputCartonBCD";
            this.txtInputCartonBCD.Size = new System.Drawing.Size(1178, 101);
            this.txtInputCartonBCD.TabIndex = 170;
            this.txtInputCartonBCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.Window;
            this.label8.Location = new System.Drawing.Point(1, 558);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(669, 101);
            this.label8.TabIndex = 172;
            this.label8.Text = "PLC 설비 DATA";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(676, 558);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1179, 101);
            this.label9.TabIndex = 173;
            this.label9.Text = "미사용";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("굴림", 40F, System.Drawing.FontStyle.Bold);
            this.btn_Start.Location = new System.Drawing.Point(1, 1404);
            this.btn_Start.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(909, 124);
            this.btn_Start.TabIndex = 174;
            this.btn_Start.Text = "시작";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Font = new System.Drawing.Font("굴림", 40F, System.Drawing.FontStyle.Bold);
            this.btn_Stop.Location = new System.Drawing.Point(946, 1404);
            this.btn_Stop.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(909, 124);
            this.btn_Stop.TabIndex = 175;
            this.btn_Stop.Text = "정지";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_TimeoutToggle
            // 
            this.btn_TimeoutToggle.BackColor = System.Drawing.Color.Green;
            this.btn_TimeoutToggle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_TimeoutToggle.ForeColor = System.Drawing.Color.Black;
            this.btn_TimeoutToggle.Location = new System.Drawing.Point(1301, 45);
            this.btn_TimeoutToggle.Margin = new System.Windows.Forms.Padding(4);
            this.btn_TimeoutToggle.Name = "btn_TimeoutToggle";
            this.btn_TimeoutToggle.Size = new System.Drawing.Size(200, 62);
            this.btn_TimeoutToggle.TabIndex = 180;
            this.btn_TimeoutToggle.Text = "타임아웃 ON";
            this.btn_TimeoutToggle.UseVisualStyleBackColor = false;
            this.btn_TimeoutToggle.Click += new System.EventHandler(this.btn_TimeoutToggle_Click);
            // 
            // btn_ModelSetting
            // 
            this.btn_ModelSetting.BackColor = System.Drawing.Color.White;
            this.btn_ModelSetting.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ModelSetting.ForeColor = System.Drawing.Color.Black;
            this.btn_ModelSetting.Location = new System.Drawing.Point(1521, 45);
            this.btn_ModelSetting.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ModelSetting.Name = "btn_ModelSetting";
            this.btn_ModelSetting.Size = new System.Drawing.Size(160, 62);
            this.btn_ModelSetting.TabIndex = 181;
            this.btn_ModelSetting.Text = "바코드 설정";
            this.btn_ModelSetting.UseVisualStyleBackColor = false;
            this.btn_ModelSetting.Click += new System.EventHandler(this.btn_ModelSetting_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(676, 1179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(978, 106);
            this.label6.TabIndex = 177;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            //
            // btnResetCount
            //
            this.btnResetCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnResetCount.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnResetCount.ForeColor = System.Drawing.Color.White;
            this.btnResetCount.Location = new System.Drawing.Point(1658, 1179);
            this.btnResetCount.Margin = new System.Windows.Forms.Padding(4);
            this.btnResetCount.Name = "btnResetCount";
            this.btnResetCount.Size = new System.Drawing.Size(196, 106);
            this.btnResetCount.TabIndex = 183;
            this.btnResetCount.Text = "수량 초기화";
            this.btnResetCount.UseVisualStyleBackColor = false;
            this.btnResetCount.Click += new System.EventHandler(this.btnResetCount_Click);
            //
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.SystemColors.Window;
            this.label14.Location = new System.Drawing.Point(1, 1179);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(671, 106);
            this.label14.TabIndex = 176;
            this.label14.Text = "금일 검사 수량";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_PLC_Status
            // 
            this.label_PLC_Status.BackColor = System.Drawing.Color.White;
            this.label_PLC_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_PLC_Status.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_PLC_Status.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_PLC_Status.Location = new System.Drawing.Point(347, 48);
            this.label_PLC_Status.Name = "label_PLC_Status";
            this.label_PLC_Status.Size = new System.Drawing.Size(62, 62);
            this.label_PLC_Status.TabIndex = 178;
            this.label_PLC_Status.Text = "PLC";
            this.label_PLC_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtInputBoxBCD
            // 
            this.txtInputBoxBCD.BackColor = System.Drawing.Color.White;
            this.txtInputBoxBCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInputBoxBCD.Font = new System.Drawing.Font("굴림", 30F);
            this.txtInputBoxBCD.Location = new System.Drawing.Point(676, 1077);
            this.txtInputBoxBCD.Margin = new System.Windows.Forms.Padding(4);
            this.txtInputBoxBCD.Name = "txtInputBoxBCD";
            this.txtInputBoxBCD.Size = new System.Drawing.Size(1178, 101);
            this.txtInputBoxBCD.TabIndex = 171;
            this.txtInputBoxBCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHiddenInput
            // 
            this.txtHiddenInput.Location = new System.Drawing.Point(-200, -200);
            this.txtHiddenInput.Name = "txtHiddenInput";
            this.txtHiddenInput.Size = new System.Drawing.Size(100, 28);
            this.txtHiddenInput.TabIndex = 200;
            // 
            // txtInputBCR
            // 
            this.txtInputBCR.BackColor = System.Drawing.Color.White;
            this.txtInputBCR.Font = new System.Drawing.Font("굴림", 10F);
            this.txtInputBCR.Location = new System.Drawing.Point(1264, 901);
            this.txtInputBCR.Name = "txtInputBCR";
            this.txtInputBCR.Size = new System.Drawing.Size(520, 30);
            this.txtInputBCR.TabIndex = 201;
            this.txtInputBCR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInputBCR.TextChanged += new System.EventHandler(this.txtInputBCR_TextChanged);
            this.txtInputBCR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputBCR_KeyPress);
            // 
            // btn_ChangePassword
            // 
            this.btn_ChangePassword.BackColor = System.Drawing.Color.White;
            this.btn_ChangePassword.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ChangePassword.ForeColor = System.Drawing.Color.Black;
            this.btn_ChangePassword.Location = new System.Drawing.Point(22, 48);
            this.btn_ChangePassword.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ChangePassword.Name = "btn_ChangePassword";
            this.btn_ChangePassword.Size = new System.Drawing.Size(139, 62);
            this.btn_ChangePassword.TabIndex = 182;
            this.btn_ChangePassword.Text = "비밀번호 변경";
            this.btn_ChangePassword.UseVisualStyleBackColor = false;
            this.btn_ChangePassword.Click += new System.EventHandler(this.btn_ChangePassword_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1857, 1530);
            this.Controls.Add(this.txtInputBCR);
            this.Controls.Add(this.btn_ChangePassword);
            this.Controls.Add(this.btnResetCount);
            this.Controls.Add(this.btn_TimeoutToggle);
            this.Controls.Add(this.btn_ModelSetting);
            this.Controls.Add(this.cboBore);
            this.Controls.Add(this.label_PLC_Status);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtInputBoxBCD);
            this.Controls.Add(this.txtHiddenInput);
            this.Controls.Add(this.txtInputCartonBCD);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBoxBCD);
            this.Controls.Add(this.txtCartonBCD);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboLocal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboBullet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_Result);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lb_MachineName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_MachineName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lb_Result;
        private System.Windows.Forms.ComboBox cboBore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBullet;
        private System.Windows.Forms.ComboBox cboLocal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label txtCartonBCD;
        public System.Windows.Forms.Label txtBoxBCD;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label txtInputCartonBCD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Stop;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label label_PLC_Status;
        private System.Windows.Forms.Button btn_TimeoutToggle;
        private System.Windows.Forms.Button btn_ModelSetting;
        private System.Windows.Forms.Label txtInputBoxBCD;
        private System.Windows.Forms.TextBox txtHiddenInput;
        private System.Windows.Forms.TextBox txtInputBCR;
        private System.Windows.Forms.Button btn_ChangePassword;
        private System.Windows.Forms.Button btnResetCount;
    }
}

