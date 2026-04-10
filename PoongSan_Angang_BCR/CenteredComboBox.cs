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
        private const int WM_MEASUREITEM   = 0x002C;
        private const int WM_REFLECT       = 0x2000;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public CenteredComboBox()
        {
            DrawMode      = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // ComboBox.ItemHeight 은 virtual 아님 → new 로 숨김(hiding)
        public new int ItemHeight
        {
            get => base.ItemHeight;
            set
            {
                _targetItemHeight = value;
                base.ItemHeight   = value;
            }
        }

        // WM_MEASUREITEM 응답을 직접 제어 — Windows 가 처음부터 올바른 높이를 사용하게 함
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_REFLECT + WM_MEASUREITEM && _targetItemHeight > 0)
            {
                // MEASUREITEMSTRUCT 레이아웃: CtlType(4)+CtlID(4)+itemID(4)+itemWidth(4)+itemHeight(4)
                // itemHeight 는 바이트 오프셋 16 (x86/x64 동일)
                Marshal.WriteInt32(m.LParam, 16, _targetItemHeight);
            }
        }

        // CB_SETITEMHEIGHT 메시지로 네이티브 높이를 강제 설정
        private void ForceItemHeight()
        {
            if (_targetItemHeight <= 0 || !IsHandleCreated) return;
            var h = new IntPtr(_targetItemHeight);
            SendMessage(Handle, CB_SETITEMHEIGHT, IntPtr.Zero,    h); // 드롭다운 목록 항목
            SendMessage(Handle, CB_SETITEMHEIGHT, new IntPtr(-1), h); // 선택 필드(상단 표시 영역)
        }

        // 네이티브 높이 갱신 후 컨트롤 크기를 재계산하도록 강제
        private void ApplyTargetHeight()
        {
            if (_targetItemHeight <= 0 || !IsHandleCreated) return;
            ForceItemHeight();
            // SetBoundsCore 가 PreferredHeight = CB_GETITEMHEIGHT + borders 로 재계산
            SetBounds(Left, Top, Width, Height, BoundsSpecified.Height);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (_targetItemHeight > 0)
            {
                ApplyTargetHeight();
                // BeginInvoke: AutoScale·Form_Load·InitBoreCombo 등 모든 초기화 완료 후 한 번 더 적용
                BeginInvoke(new Action(ApplyTargetHeight));
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            ApplyTargetHeight();
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
