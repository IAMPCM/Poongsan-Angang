using System.Drawing;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public class CenteredComboBox : ComboBox
    {
        public CenteredComboBox()
        {
            DrawMode      = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
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
