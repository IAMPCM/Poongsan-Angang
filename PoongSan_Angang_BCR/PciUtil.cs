using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoongSan_Angang_BCR
{
    public class PciUtil
    {
        public Form1 frm1;
        private ushort Pci = 0;
        public DASK dask = new DASK();
        public PciUtil(Form1 frm)
        {
            frm1 = frm;
            //if (!Define.Simulation)
            try
            {
                Pci = (ushort)DASK.Register_Card(DASK.PCI_7230, 0);   //7230 io보드 종류
            }
            catch (Exception ex)
            {

            }
        }

        public void pci_Write(object pin, ushort value)
        {
            try
            {
                ushort Pin = Convert.ToUInt16(pin);

                DASK.DO_WriteLine(Pci, 0, Pin, value);
            }
            catch { }
        }

        //ADLink 접점 읽기
        public bool pci_Read(object pin)
        {
            try
            {
                ushort Dec = 0;

                ushort Pin = Convert.ToUInt16(pin);

                DASK.DI_ReadLine(Pci, 0, Pin, out Dec);

                return Convert.ToBoolean(Dec);
            }
            catch
            {
                return false;
            }
        }
    }
}
