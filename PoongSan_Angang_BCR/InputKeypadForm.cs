using System;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    /// <summary>
    /// 터치 스크린용 알파뉴메릭 키패드 입력 창
    /// ShowDialog() 후 DialogResult.OK이면 InputText에 결과 저장됨
    /// </summary>
    public partial class InputKeypadForm : Form
    {
        public string InputText { get; private set; }

        private string _currentText;

        // VS Designer용 기본 생성자
        public InputKeypadForm()
        {
            InitializeComponent();
        }

        public InputKeypadForm(string fieldName, string currentValue = "")
        {
            _currentText = currentValue ?? "";
            InputText    = _currentText;
            InitializeComponent();
            lblTitle.Text   = fieldName + " 입력";
            txtDisplay.Text = _currentText;
            WireEvents();
        }

        private void WireEvents()
        {
            Button[] keyButtons =
            {
                btnK1, btnK2, btnK3, btnK4, btnK5,
                btnK6, btnK7, btnK8, btnK9, btnK0,
                btnKQ, btnKW, btnKE, btnKR, btnKT,
                btnKY, btnKU, btnKI, btnKO, btnKP,
                btnKA, btnKS, btnKD, btnKF, btnKG,
                btnKH, btnKJ, btnKK, btnKL, btnKDot,
                btnKZ, btnKX, btnKC, btnKV, btnKB,
                btnKN, btnKM, btnKMinus, btnKSlash, btnKUnderscore
            };

            foreach (var btn in keyButtons)
            {
                btn.Click += (s, e) =>
                {
                    _currentText   += ((Button)s).Tag.ToString();
                    txtDisplay.Text = _currentText;
                };
            }

            btnBack.Click += (s, e) =>
            {
                if (_currentText.Length > 0)
                    _currentText = _currentText.Substring(0, _currentText.Length - 1);
                txtDisplay.Text = _currentText;
            };
            btnClear.Click += (s, e) => { _currentText = ""; txtDisplay.Text = ""; };
            btnOk.Click    += (s, e) =>
            {
                InputText         = _currentText;
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
        }
    }
}
