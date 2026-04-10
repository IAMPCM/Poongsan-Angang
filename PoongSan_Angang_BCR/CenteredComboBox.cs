using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public class CenteredComboBox : ComboBox
    {
        private int _targetItemHeight = -1;

        private const int CB_SETITEMHEIGHT = 0x0153;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public CenteredComboBox()
        {
            DrawMode      = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public new int ItemHeight
        {
            get => base.ItemHeight;
            set
            {
                _targetItemHeight = value;
                base.ItemHeight   = value;
            }
        }

        // WinForms ItemHeight setter은 내부 저장값과 같으면 CB_SETITEMHEIGHT를 보내지 않으므로
        // 핸들 생성 후 Windows가 폰트 기반으로 덮어쓴 높이를 강제로 복원한다.
        private void ForceItemHeight()
        {
            if (_targetItemHeight <= 0 || !IsHandleCreated) return;
            var h = new IntPtr(_targetItemHeight);
            SendMessage(Handle, CB_SETITEMHEIGHT, IntPtr.Zero,    h); // 드롭다운 목록 항목
            SendMessage(Handle, CB_SETITEMHEIGHT, new IntPtr(-1), h); // 선택 필드(상단 표시 영역)
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ForceItemHeight();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            ForceItemHeight();
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
