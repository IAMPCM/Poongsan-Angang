namespace PoongSan_Angang_BCR
{
    public class VasimPlatform
    {
        public Form1 frm1;
        public History m_history;
        public SystemData m_SystemData;
        public PciUtil m_pci;
        public PLCDefine m_plcDefine;
        public MXPlc m_mxPlc;
        public mcOMRON.OmronPLC plc_omron;

        public VasimPlatform(Form1 frm)
        {
            frm1 = frm;
            m_plcDefine = new PLCDefine(frm1);
            m_SystemData = new SystemData(frm1);
            m_history = new History(frm1);
            m_pci = new PciUtil(frm1);
            m_mxPlc = new MXPlc(frm1);
            plc_omron = new mcOMRON.OmronPLC(mcOMRON.TransportType.Tcp);
        }
    }
}
