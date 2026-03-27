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
    public class AddEditModelForm : Form
    {
        // ── 결과값 (DialogResult.OK 일 때만 유효) ──
        public string ResultBore      { get; private set; }
        public string ResultBullet    { get; private set; }
        public string ResultCartonA   { get; private set; }
        public string ResultCartonE   { get; private set; }
        public string ResultBox       { get; private set; }
        public string ResultWeightMin { get; private set; }
        public string ResultWeightMax { get; private set; }

        private TextBox txt_Bore, txt_Bullet, txt_CartonA, txt_CartonE,
                        txt_Box, txt_WeightMin, txt_WeightMax;
        private readonly bool _isEditMode;

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
            BuildUI();

            // 기존 값 채우기 (변경 모드 또는 추가 시 기본값 있을 경우)
            txt_Bore.Text      = bore;
            txt_Bullet.Text    = bullet;
            txt_CartonA.Text   = cartonA;
            txt_CartonE.Text   = cartonE;
            txt_Box.Text       = box;
            txt_WeightMin.Text = weightMin;
            txt_WeightMax.Text = weightMax;
        }

        private void BuildUI()
        {
            const int formW  = 820;
            const int rowH   = 60;
            const int startY = 58;
            const int labelW = 180;
            const int txtX   = 196;
            int txtW = formW - txtX - 12;

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.BackColor       = Color.FromArgb(38, 38, 43);
            this.TopMost         = true;

            // ── 타이틀 ──
            var lblTitle = new Label
            {
                Text      = _isEditMode ? "모델 변경" : "신규 모델 추가",
                Font      = new Font("굴림", 17F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(51, 51, 56),
                Location  = new Point(0, 0),
                Size      = new Size(formW, 52),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(lblTitle);

            // ── 모드 안내 ──
            string hint = _isEditMode
                ? "▶  수정할 항목을 터치하면 키패드가 열립니다"
                : "▶  각 항목을 터치하여 값을 입력하세요";
            var lblHint = new Label
            {
                Text      = hint,
                Font      = new Font("굴림", 10F),
                ForeColor = Color.FromArgb(180, 180, 180),
                BackColor = Color.FromArgb(38, 38, 43),
                Location  = new Point(8, 52),
                Size      = new Size(formW - 8, 22),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(lblHint);

            // ── 필드 정의 ──
            var fieldDefs = new[]
            {
                ("구경",           "구경"),
                ("탄종",           "탄종"),
                ("카톤 BCD (미국)", "카톤 BCD (미국)"),
                ("카톤 BCD (유럽)", "카톤 BCD (유럽)"),
                ("골판지 BCD",     "골판지 BCD"),
                ("무게 최소",      "무게 최소"),
                ("무게 최대",      "무게 최대")
            };

            var textboxes = new TextBox[fieldDefs.Length];

            Font labelFont = new Font("굴림", 12F, FontStyle.Bold);
            Font inputFont = new Font("굴림", 14F);

            for (int i = 0; i < fieldDefs.Length; i++)
            {
                int y = startY + i * rowH;

                // 구분선
                var sep = new Panel
                {
                    BackColor = Color.FromArgb(60, 60, 65),
                    Location  = new Point(0, y),
                    Size      = new Size(formW, 1)
                };
                this.Controls.Add(sep);

                // 레이블
                var lbl = new Label
                {
                    Text      = fieldDefs[i].Item1,
                    Font      = labelFont,
                    ForeColor = Color.FromArgb(200, 200, 200),
                    BackColor = Color.FromArgb(44, 44, 50),
                    Location  = new Point(0, y + 1),
                    Size      = new Size(labelW, rowH - 1),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                this.Controls.Add(lbl);

                // 텍스트박스 (ReadOnly, 터치하면 키패드 열림)
                var txt = new TextBox
                {
                    Font        = inputFont,
                    ForeColor   = Color.Yellow,
                    BackColor   = Color.FromArgb(55, 55, 62),
                    Location    = new Point(txtX, y + (rowH - 36) / 2),
                    Size        = new Size(txtW, 36),
                    ReadOnly    = true,
                    TextAlign   = HorizontalAlignment.Center,
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor      = Cursors.Hand,
                    Tag         = fieldDefs[i].Item2
                };
                string fieldName = fieldDefs[i].Item2;
                txt.Click += (s, e) => OpenKeypad((TextBox)s, fieldName);
                this.Controls.Add(txt);
                textboxes[i] = txt;
            }

            // 마지막 구분선
            this.Controls.Add(new Panel
            {
                BackColor = Color.FromArgb(60, 60, 65),
                Location  = new Point(0, startY + fieldDefs.Length * rowH),
                Size      = new Size(formW, 1)
            });

            // 텍스트박스 변수 연결
            txt_Bore      = textboxes[0];
            txt_Bullet    = textboxes[1];
            txt_CartonA   = textboxes[2];
            txt_CartonE   = textboxes[3];
            txt_Box       = textboxes[4];
            txt_WeightMin = textboxes[5];
            txt_WeightMax = textboxes[6];

            // ── 하단 버튼 ──
            int btnAreaY = startY + fieldDefs.Length * rowH + 10;
            const int btnH = 58;

            // 확인 / 저장 버튼
            var btnOk = new Button
            {
                Text      = _isEditMode ? "변경 저장" : "추  가",
                Font      = new Font("굴림", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = _isEditMode
                            ? Color.FromArgb(0, 85, 170)
                            : Color.FromArgb(0, 120, 55),
                FlatStyle = FlatStyle.Flat,
                Location  = new Point(formW - 2 * (180 + 8), btnAreaY),
                Size      = new Size(180, btnH)
            };
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.Click += btn_Confirm_Click;
            this.Controls.Add(btnOk);

            // 취소 버튼
            var btnCancel = new Button
            {
                Text      = "취  소",
                Font      = new Font("굴림", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(75, 75, 82),
                FlatStyle = FlatStyle.Flat,
                Location  = new Point(formW - (180 + 4), btnAreaY),
                Size      = new Size(180, btnH)
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
            this.Controls.Add(btnCancel);

            this.ClientSize = new Size(formW, btnAreaY + btnH + 8);
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
            if (string.IsNullOrWhiteSpace(txt_Bore.Text) ||
                string.IsNullOrWhiteSpace(txt_Bullet.Text))
            {
                MessageBox.Show("구경과 탄종을 입력해 주세요.",
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ResultBore      = txt_Bore.Text.Trim();
            ResultBullet    = txt_Bullet.Text.Trim();
            ResultCartonA   = txt_CartonA.Text.Trim();
            ResultCartonE   = txt_CartonE.Text.Trim();
            ResultBox       = txt_Box.Text.Trim();
            ResultWeightMin = txt_WeightMin.Text.Trim();
            ResultWeightMax = txt_WeightMax.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
