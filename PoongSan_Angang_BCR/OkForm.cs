using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public partial class OkForm : Form
    {
        private static OkForm instance;
        private static Control uiInvoker;
        private System.Windows.Forms.Timer _autoCloseTimer;

        public OkForm()
        {
            InitializeComponent();
            _autoCloseTimer = new System.Windows.Forms.Timer();
            _autoCloseTimer.Interval = 500;
            _autoCloseTimer.Tick += (s, e) =>
            {
                _autoCloseTimer.Stop();
                this.Hide();
            };
        }

        public static void Initialize(Control anyControlOnUIThread)
        {
            uiInvoker = anyControlOnUIThread;
        }

        public static void ShowOk(string message)
        {
            if (uiInvoker == null || !uiInvoker.IsHandleCreated)
                return;

            uiInvoker.BeginInvoke((MethodInvoker)(() =>
            {
                if (instance == null || instance.IsDisposed)
                    instance = new OkForm();

                instance.lb_OkCode.Text = message;

                if (!instance.Visible)
                    instance.Show();
                else
                    instance.BringToFront();

                instance._autoCloseTimer.Stop();
                instance._autoCloseTimer.Start();
            }));
        }
    }
}
