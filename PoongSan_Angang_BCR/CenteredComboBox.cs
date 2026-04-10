using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public class CenteredComboBox : ComboBox
    {
        private int _targetItemHeight = -1;

        public CenteredComboBox()
        {
            DrawMode      = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public override int ItemHeight
        {
            get => base.ItemHeight;
            set
            {
                _targetItemHeight = value;
                base.ItemHeight   = value;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (_targetItemHeight > 0)
                base.ItemHeight = _targetItemHeight;
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (_targetItemHeight > 0)
                base.ItemHeight = _targetItemHeight;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0) { base.OnDrawItem(e); return; }
            e.DrawBackground();
            string text = Items[e.Index].ToString();
            TextRenderer.DrawText(
                e.Graphics, text, e.Font, e.Bounds, e.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
            e.DrawFocusRectangle();
        }
    }
}
