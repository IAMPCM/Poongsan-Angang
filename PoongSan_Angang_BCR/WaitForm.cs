using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public partial class WaitForm : Form
    {
        public WaitForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }
        public WaitForm(Form parent)
        {
            InitializeComponent();
            if (parent != null)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(parent.Location.X + parent.Width / 2 - this.Width / 2,
                    parent.Location.Y + parent.Height / 2 - this.Height / 2);
            }
            else
                this.StartPosition = FormStartPosition.CenterParent;
        }
        public void CloseWaitForm()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            if (label1.Image != null)
            {
                label1.Image.Dispose();
            }
        }
    }
    public class WaitFormFunc
    {
        public Form1 frm1;
        WaitForm wait;
        Thread loadThread;

        public WaitFormFunc(Form1 frm)
        {
            frm1 = frm;
        }

        public void Show()
        {
            loadThread = new Thread(new ThreadStart(LoadingProcess));
            loadThread.Start();
        }
        public void Show(Form parent)
        {
            loadThread = new Thread(new ParameterizedThreadStart(LoadingProcess));
            loadThread.Start(parent);
        }
        public void Close()
        {
            if (wait != null)
            {
                wait.BeginInvoke(new System.Threading.ThreadStart(wait.CloseWaitForm));
                wait = null;
                loadThread = null;
            }
        }
        public void LoadingProcess()
        {
            wait = new WaitForm();
            wait.ShowDialog();
        }

        private void LoadingProcess(object parent)
        {
            Form parent1 = parent as Form;
            wait = new WaitForm(parent1);
            wait.ShowDialog();
        }
    }
}
