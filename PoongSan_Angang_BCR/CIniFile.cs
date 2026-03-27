using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PoongSan_Angang_BCR
{
    public class CIniFile : IDisposable
    {
        #region ------ CONTRCUTOR / DISPOSE ------

        private string m_filePath = "";

        public CIniFile(string filePath)
        {
            this.m_filePath = filePath;
        }

        public void Dispose()
        {
            // DO NOTHING
            // BUT DON'T REMOVE THIS FUNC. BECAUSE USING STATEMENT
        }

        #endregion

        #region ------ DLL IMPORT ------

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        #endregion

        #region ------ WRITE & READ ------

        public void WriteString(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, this.m_filePath);
        }

        public void WriteInt(string section, string key, int value)
        {
            WritePrivateProfileString(section, key, value.ToString(), this.m_filePath);
        }

        public void WriteDouble(string section, string key, double value)
        {
            WritePrivateProfileString(section, key, value.ToString(), this.m_filePath);
        }

        public string ReadString(string section, string key, string defaultValue)
        {
            StringBuilder temp = new StringBuilder(8192);

            if (GetPrivateProfileString(section, key, "", temp, 8192, this.m_filePath) == 0)
            {
                return defaultValue;
            }

            return temp.ToString();
        }

        public int ReadInt(string section, string key, int defaultValue)
        {
            StringBuilder temp = new StringBuilder(8192);

            if (GetPrivateProfileString(section, key, "", temp, 8192, this.m_filePath) == 0)
            {
                return defaultValue;
            }

            int result = 0;
            if (!int.TryParse(temp.ToString(), out result))
            {
                return defaultValue;
            }

            return result;
        }

        public double ReadDouble(string section, string key, double defaultValue)
        {
            StringBuilder temp = new StringBuilder(8192);

            if (GetPrivateProfileString(section, key, "", temp, 8192, this.m_filePath) == 0)
            {
                return defaultValue;
            }

            double result = 0.0;
            if (!double.TryParse(temp.ToString(), out result))
            {
                return defaultValue;
            }

            return result;
        }

        #endregion        
    }
}
