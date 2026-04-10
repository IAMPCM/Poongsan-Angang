using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    /// <summary>
    /// 신규 모델 추가 / 기존 모델 변경 공용 다이얼로그
    ///   isEditMode = false → 추가 (빈 필드로 시작)
    ///   isEditMode = true  → 변경 (기존 값 미리 채워짐)
    /// 각 텍스트 박스를 터치하면 InputKeypadForm 이 열립니다.
    /// </summary>
    public partial class AddEditModelForm : Form
    {
        // ── 결과값 (DialogResult.OK 일 때만 유효) ──
        public string ResultBore      { get; private set; }
        public string ResultBullet    { get; private set; }
        public string ResultCartonA   { get; private set; }
        public string ResultCartonE   { get; private set; }
        public string ResultBox       { get; private set; }
        public string ResultWeightMin { get; private set; }
        public string ResultWeightMax { get; private set; }

        private readonly bool _isEditMode;

        // VS Designer용 기본 생성자
        public AddEditModelForm()
        {
            InitializeComponent();
        }

        public AddEditModelForm(
            bool   isEditMode,
            string bore      = "",
            string bullet    = "",
            string cartonA   = "",
            string cartonE   = "",
            string box       = "",
            string weightMin = "",
            string weightMax = "")
        {
            _isEditMode = isEditMode;
            InitializeComponent();

            // 모드별 타이틀 / 힌트 / 버튼 설정
            lblTitle.Text    = isEditMode ? "모델 변경" : "신규 모델 추가";
            lblHint.Text     = isEditMode
                ? "▶  수정할 항목을 터치하면 키패드가 열립니다"
                : "▶  각 항목을 터치하여 값을 입력하세요";
            btnOk.Text       = isEditMode ? "변경 저장" : "추  가";
            btnOk.BackColor  = isEditMode
                ? Color.FromArgb(0, 85, 170)
                : Color.FromArgb(0, 120, 55);

            // 기존 값 채우기
            txtBore.Text      = bore;
            txtBullet.Text    = bullet;
            txtCartonA.Text   = cartonA;
            txtCartonE.Text   = cartonE;
            txtBox.Text       = box;
            txtWeightMin.Text = weightMin;
            txtWeightMax.Text = weightMax;

            WireEvents();
        }

        private void WireEvents()
        {
            txtBore.Click      += (s, e) => OpenKeypad(txtBore,      "구경");
            txtBullet.Click    += (s, e) => OpenKeypad(txtBullet,    "탄종");
            txtCartonA.Click   += (s, e) => OpenKeypad(txtCartonA,   "카톤 BCD (미국)");
            txtCartonE.Click   += (s, e) => OpenKeypad(txtCartonE,   "카톤 BCD (유럽)");
            txtBox.Click       += (s, e) => OpenKeypad(txtBox,       "골판지 BCD");
            txtWeightMin.Click += (s, e) => OpenKeypad(txtWeightMin, "무게 최소");
            txtWeightMax.Click += (s, e) => OpenKeypad(txtWeightMax, "무게 최대");
            btnOk.Click        += btn_Confirm_Click;
            btnCancel.Click    += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private void OpenKeypad(TextBox txt, string fieldName)
        {
            using (var kpd = new InputKeypadForm(fieldName, txt.Text))
            {
                if (kpd.ShowDialog(this) == DialogResult.OK)
                    txt.Text = kpd.InputText;
            }
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBore.Text) ||
                string.IsNullOrWhiteSpace(txtBullet.Text))
            {
                MessageBox.Show("구경과 탄종을 입력해 주세요.",
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ResultBore      = txtBore.Text.Trim();
            ResultBullet    = txtBullet.Text.Trim();
            ResultCartonA   = txtCartonA.Text.Trim();
            ResultCartonE   = txtCartonE.Text.Trim();
            ResultBox       = txtBox.Text.Trim();
            ResultWeightMin = txtWeightMin.Text.Trim();
            ResultWeightMax = txtWeightMax.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
