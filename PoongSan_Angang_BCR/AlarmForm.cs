using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public partial class AlarmForm : Form
    {
        public Form1 frm1;
        private static AlarmForm instance;
        private static Control uiInvoker;

        public AlarmForm(Form1 frm)
        {
            frm1 = frm;
            InitializeComponent();
        }
        // 메인 폼에서 호출해서 UI 핸들 설정
        public static void Initialize(Control anyControlOnUIThread)
        {
            uiInvoker = anyControlOnUIThread;
        }

        public static void ShowAlarm(string message, Form1 frm)
        {
            if (uiInvoker == null || !uiInvoker.IsHandleCreated)
                return;

            frm.bAlarmPopupFocousStop = true;
            frm.m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_RED, 1);
            frm.m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_BUZZER, 1);
            frm.m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_GREEN, 0);

            frm.m_VasimPlatform.m_history.AlarmLog.Add(DateTime.Now, "AMR : " + message);

            uiInvoker.BeginInvoke((MethodInvoker)(() =>
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new AlarmForm(frm);
                    instance.SetMessage(message);
                    instance.Show();
                }
                else
                {
                    instance.SetMessage(message);

                    if (!instance.Visible)
                    {
                        instance.Show(); // ✅ 숨겨졌으면 다시 보이게
                    }
                    else
                    {
                        instance.BringToFront();
                    }
                }
            }));
        }
        public static void AlarmHide()
        {
            if (instance == null || instance.IsDisposed)
                return;

            instance.Hide();
        }
        public void SetMessage(string message)
        {
            lb_AlarmCode.Text = message;
        }
        public void UpdateUI()
        {
            //if (frm1.m_VasimPlatform.m_SystemData.BlobUse == "True")
            //    cb_Blob_Use.Checked = true;
            //else
            //    cb_Blob_Use.Checked = false;

            //rT_Pix_Threshold.Text = frm1.m_VasimPlatform.m_SystemData.PixGrayThreshold;
        }

        private void CloseAlarm()
        {
            frm1.m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_BUZZER, 0);
            this.Hide();
            frm1.bAlarmPopupFocousStop = false;


            // 알람 해제 후 초록불
            frm1.m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_RED, 0);
            frm1.m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_YELLOW, 0);
            frm1.m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_GREEN, 1);
        }

        // 클릭하면 CloseAlarm() 호출
        private void AlarmForm_MouseClick(object sender, MouseEventArgs e)
        {
            CloseAlarm();
        }

        private void btn_Buzzer_off_Click(object sender, EventArgs e)
        {
            frm1.m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_BUZZER, 0);
            frm1.m_VasimPlatform.m_pci.pci_Write(Define.IO_OUT_LAMP_RED, 0);
        }

        private void lb_AlarmCode_Click(object sender, EventArgs e)
        {

        }

        private void lb_AlarmCode_Click_1(object sender, EventArgs e)
        {

        }
    }
}
