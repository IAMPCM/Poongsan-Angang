namespace PoongSan_Angang_BCR
{

    public class PLCDefine
    {
        public Form1 frm1;

        public PLCDefine(Form1 frm)
        {
            frm1 = frm;
        }

        //PC->PLC

        public short lastPC_Individual_BCD_Result = short.MinValue;
        public short lastPC_Box_BCD_Result = short.MinValue;

        //PC->PLC
        //[BCD]
        public static string PC_Individual_BCD_Result = "D28060";
        public static string PC_Box_BCD_Result = "D28070";

        //PLC->PC
        //[BCD]
        public static string PLC_Individual_BCD_Length = "D25008";
        public static string PLC_Individual_BCD = "D25009";

        public static string PLC_Data = "D10000";
        public static string PLC_Data_Length = "10";
    }
}
