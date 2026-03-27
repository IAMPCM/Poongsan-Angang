using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    /// <summary>
    /// 터치 스크린용 알파뉴메릭 키패드 입력 창
    /// ShowDialog() 후 DialogResult.OK이면 InputText에 결과 저장됨
    /// </summary>
    public class InputKeypadForm : Form
    {
        public string InputText { get; private set; }

        private string _currentText;
        private TextBox txtDisplay;

        private static readonly string[][] KeyRows = new string[][]
        {
            new string[] { "1","2","3","4","5","6","7","8","9","0" },
            new string[] { "Q","W","E","R","T","Y","U","I","O","P" },
            new string[] { "A","S","D","F","G","H","J","K","L","." },
            new string[] { "Z","X","C","V","B","N","M","-","/","_" }
        };

        public InputKeypadForm(string fieldName, string currentValue = "")
        {
            _currentText = currentValue ?? "";
            InputText = _currentText;
            BuildUI(fieldName);
        }

        private void BuildUI(string fieldName)
        {
            const int keyW = 65;
            const int keyH = 52;
            const int keyGap = 4;
            const int padX = 10;

            int totalKeysWidth = 10 * keyW + 9 * keyGap;  // 686
            int formW = totalKeysWidth + padX * 2;          // 706 → 710
            if (formW < 710) formW = 710;

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(35, 35, 40);
            this.TopMost = true;

            // ── 타이틀 ──
            var lblTitle = new Label
            {
                Text = fieldName + " 입력",
                Font = new Font("굴림", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(51, 51, 56),
                Location = new Point(0, 0),
                Size = new Size(formW, 44),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(lblTitle);

            // ── 입력 표시창 ──
            txtDisplay = new TextBox
            {
                Text = _currentText,
                Font = new Font("굴림", 16F),
                ForeColor = Color.Yellow,
                BackColor = Color.FromArgb(55, 55, 60),
                Location = new Point(padX, 50),
                Size = new Size(formW - padX * 2, 46),
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Center,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(txtDisplay);

            // ── 키 버튼 ──
            int rowStartY = 106;
            for (int row = 0; row < KeyRows.Length; row++)
            {
                for (int col = 0; col < KeyRows[row].Length; col++)
                {
                    string key = KeyRows[row][col];
                    var btn = new Button
                    {
                        Text = key,
                        Font = new Font("굴림", 12F, FontStyle.Bold),
                        ForeColor = Color.White,
                        BackColor = Color.FromArgb(68, 68, 76),
                        FlatStyle = FlatStyle.Flat,
                        Location = new Point(padX + col * (keyW + keyGap),
                                             rowStartY + row * (keyH + keyGap)),
                        Size = new Size(keyW, keyH),
                        Tag = key
                    };
                    btn.FlatAppearance.BorderColor = Color.FromArgb(95, 95, 105);
                    btn.FlatAppearance.BorderSize = 1;
                    btn.Click += (s, e) =>
                    {
                        _currentText += ((Button)s).Tag.ToString();
                        txtDisplay.Text = _currentText;
                    };
                    this.Controls.Add(btn);
                }
            }

            // ── 하단 컨트롤 버튼 4개 ──
            int ctrlY = rowStartY + KeyRows.Length * (keyH + keyGap) + 6;
            const int ctrlH = 54;
            int usableW = formW - padX * 2;
            int btnW = (usableW - 3 * 8) / 4;

            int bx(int i) => padX + i * (btnW + 8);

            // ← 한 글자 삭제
            var btnBack = MakeCtrlBtn("← 삭제", Color.FromArgb(100, 55, 55), bx(0), ctrlY, btnW, ctrlH);
            btnBack.Click += (s, e) =>
            {
                if (_currentText.Length > 0)
                {
                    _currentText = _currentText.Substring(0, _currentText.Length - 1);
                    txtDisplay.Text = _currentText;
                }
            };

            // 전체 삭제
            var btnClear = MakeCtrlBtn("전체 삭제", Color.FromArgb(110, 60, 0), bx(1), ctrlY, btnW, ctrlH);
            btnClear.Click += (s, e) => { _currentText = ""; txtDisplay.Text = ""; };

            // 확인
            var btnOk = MakeCtrlBtn("확  인", Color.FromArgb(0, 115, 55), bx(2), ctrlY, btnW, ctrlH);
            btnOk.Click += (s, e) =>
            {
                InputText = _currentText;
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            // 취소
            var btnCancel = MakeCtrlBtn("취  소", Color.FromArgb(72, 72, 78), bx(3), ctrlY, btnW, ctrlH);
            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            this.Controls.Add(btnBack);
            this.Controls.Add(btnClear);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);

            this.ClientSize = new Size(formW, ctrlY + ctrlH + 8);
        }

        private Button MakeCtrlBtn(string text, Color backColor, int x, int y, int w, int h)
        {
            var btn = new Button
            {
                Text = text,
                Font = new Font("굴림", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = backColor,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(x, y),
                Size = new Size(w, h)
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }
    }
}
