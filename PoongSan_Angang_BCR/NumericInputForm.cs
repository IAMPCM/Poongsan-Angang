using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    /// <summary>
    /// 숫자 전용 키패드 입력 창.
    /// ShowDialog() 후 DialogResult.OK 이면 InputText 에 결과 저장됨.
    /// </summary>
    public class NumericInputForm : Form
    {
        public string InputText { get; private set; } = "";

        private string  _current = "";
        private Label   _lblDisplay;

        private const int KeyW = 90;
        private const int KeyH = 70;
        private const int Gap  = 6;
        private const int PadX = 20;
        private const int PadY = 20;

        public NumericInputForm(string title, string currentValue = "")
        {
            _current   = currentValue ?? "";
            InputText  = _current;
            BuildUI(title);
        }

        private void BuildUI(string title)
        {
            int formW = PadX * 2 + KeyW * 3 + Gap * 2;  // 20+90*3+6*2+20 = 298

            this.Text            = title;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor       = Color.FromArgb(35, 35, 40);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.TopMost         = true;

            // 타이틀 바
            var lblTitle = new Label
            {
                Text      = title + " 입력",
                Font      = new Font("굴림", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(51, 51, 56),
                Location  = new Point(0, 0),
                Size      = new Size(formW, 46),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // 입력 표시창
            _lblDisplay = new Label
            {
                Font        = new Font("굴림", 22F, FontStyle.Bold),
                ForeColor   = Color.FromArgb(255, 220, 80),
                BackColor   = Color.FromArgb(55, 55, 60),
                Location    = new Point(PadX, 54),
                Size        = new Size(formW - PadX * 2, 54),
                TextAlign   = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle,
                Text        = _current
            };

            // 숫자 키 배치: 1~9 → CLR, 0, ←
            string[][] keys = new string[][]
            {
                new[] { "1", "2", "3" },
                new[] { "4", "5", "6" },
                new[] { "7", "8", "9" },
                new[] { "CLR", "0", "←" }
            };

            int keyStartY = 120;

            for (int row = 0; row < keys.Length; row++)
            {
                for (int col = 0; col < keys[row].Length; col++)
                {
                    string key = keys[row][col];
                    int x = PadX + col * (KeyW + Gap);
                    int y = keyStartY + row * (KeyH + Gap);

                    Color bg = key == "CLR" ? Color.FromArgb(110, 60, 0)
                             : key == "←"  ? Color.FromArgb(100, 55, 55)
                             : Color.FromArgb(68, 68, 76);

                    var btn = new Button
                    {
                        Text      = key,
                        Font      = new Font("굴림", 16F, FontStyle.Bold),
                        ForeColor = Color.White,
                        BackColor = bg,
                        FlatStyle = FlatStyle.Flat,
                        Location  = new Point(x, y),
                        Size      = new Size(KeyW, KeyH),
                        Tag       = key
                    };
                    btn.FlatAppearance.BorderColor = Color.FromArgb(90, 90, 100);
                    btn.FlatAppearance.BorderSize  = 1;
                    btn.Click += OnKeyClick;
                    this.Controls.Add(btn);
                }
            }

            // 확인 / 취소
            int ctrlY = keyStartY + keys.Length * (KeyH + Gap) + 8;
            int halfW = (formW - PadX * 2 - Gap) / 2;

            var btnOk = new Button
            {
                Text      = "확  인",
                Font      = new Font("굴림", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(0, 115, 55),
                FlatStyle = FlatStyle.Flat,
                Location  = new Point(PadX, ctrlY),
                Size      = new Size(halfW, 56)
            };
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.Click += (s, e) =>
            {
                InputText        = _current;
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            var btnCancel = new Button
            {
                Text      = "취  소",
                Font      = new Font("굴림", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(72, 72, 78),
                FlatStyle = FlatStyle.Flat,
                Location  = new Point(PadX + halfW + Gap, ctrlY),
                Size      = new Size(halfW, 56)
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            this.Controls.Add(lblTitle);
            this.Controls.Add(_lblDisplay);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);

            this.ClientSize = new Size(formW, ctrlY + 56 + PadY);
        }

        private void OnKeyClick(object sender, EventArgs e)
        {
            string key = ((Button)sender).Tag.ToString();
            if (key == "←")
            {
                if (_current.Length > 0)
                    _current = _current.Substring(0, _current.Length - 1);
            }
            else if (key == "CLR")
            {
                _current = "";
            }
            else
            {
                _current += key;
            }
            _lblDisplay.Text = _current;
        }
    }
}
