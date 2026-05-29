using System;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    /// <summary>
    /// 숫자 전용 키패드 입력 창.
    /// ShowDialog() 후 DialogResult.OK 이면 InputText 에 결과 저장됨.
    /// </summary>
    public partial class NumericInputForm : Form
    {
        public string InputText { get; private set; } = "";

        private string _current = "";

        // VS Designer용 기본 생성자
        public NumericInputForm()
        {
            InitializeComponent();
        }

        public NumericInputForm(string title, string currentValue = "")
        {
            _current  = currentValue ?? "";
            InputText = _current;
            InitializeComponent();
            lblTitle.Text   = title + " 입력";
            lblDisplay.Text = _current;
            WireEvents();
        }

        private void WireEvents()
        {
            btnKey1.Click    += (s, e) => AppendKey("1");
            btnKey2.Click    += (s, e) => AppendKey("2");
            btnKey3.Click    += (s, e) => AppendKey("3");
            btnKey4.Click    += (s, e) => AppendKey("4");
            btnKey5.Click    += (s, e) => AppendKey("5");
            btnKey6.Click    += (s, e) => AppendKey("6");
            btnKey7.Click    += (s, e) => AppendKey("7");
            btnKey8.Click    += (s, e) => AppendKey("8");
            btnKey9.Click    += (s, e) => AppendKey("9");
            btnKey0.Click    += (s, e) => AppendKey("0");
            btnKeyCLR.Click  += (s, e) => { _current = ""; lblDisplay.Text = ""; };
            btnKeyBack.Click += (s, e) =>
            {
                if (_current.Length > 0)
                    _current = _current.Substring(0, _current.Length - 1);
                lblDisplay.Text = _current;
            };
            btnOk.Click += (s, e) =>
            {
                InputText         = _current;
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
        }

        private void AppendKey(string key)
        {
            _current += key;
            lblDisplay.Text = _current;
        }
    }
}
