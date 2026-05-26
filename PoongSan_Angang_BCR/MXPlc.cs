using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoongSan_Angang_BCR
{
    public class MXPlc
    {
        public Form1 frm1;
        private Thread connectionThread;
        private Thread PlcDataThread;
        public Thread PlcAliveThread;

        private bool stopRequested = false;
        private ActUtlType64Lib.ActUtlType64Class lpcom_ReferencesUtlType;
        private ActProgType64Lib.ActProgType64Class lpcom_ReferencesProgType;
        private ActSupportMsg64Lib.ActSupportMsg64Class lpcom_ReferencesMsg;
        public bool m_bConnected = false;

        public delegate void EvePlcReceiveHandler(string name, object data);
        public event EvePlcReceiveHandler PLCReceivedData;
        object PLCLock = new object();

        /// <summary>
        /// 연결 상태가 변화할 때 호출되는 콜백 (true=연결됨, false=끊김)
        /// UI 스레드 전환은 호출 측에서 처리해야 합니다.
        /// </summary>
        public Action<bool> OnConnectionChanged;
        
        public MXPlc(Form1 frm)
        {
            frm1 = frm;
        }
        public void Initialize()
        {
            lpcom_ReferencesUtlType = new ActUtlType64Lib.ActUtlType64Class();
            lpcom_ReferencesProgType = new ActProgType64Lib.ActProgType64Class();
            lpcom_ReferencesMsg = new ActSupportMsg64Lib.ActSupportMsg64Class();
            Connect();
        }

        public void Connect()
        {
            int stationNo = 0;
            int.TryParse(frm1.m_VasimPlatform.m_SystemData.PlcStationNo, out stationNo);
            lpcom_ReferencesUtlType.ActLogicalStationNumber = stationNo;
            Start();
        }
        public void Start()
        {
            if (connectionThread == null || !connectionThread.IsAlive)
            {
                stopRequested = false;
                connectionThread = new Thread(new ThreadStart(ConnectionThreadProc));
                connectionThread.Start();

                PlcDataThread = new Thread(new ThreadStart(PlcDataThreadProc));
                PlcDataThread.Start();
            }
        }
        public void Stop()
        {
            if (connectionThread != null && connectionThread.IsAlive)
            {
                stopRequested = true;
                connectionThread.Join(); // Wait for the thread to finish
            }
        }
        private void ConnectionThreadProc()
        {
            while (!stopRequested)
            {
                try
                {
                    int result = lpcom_ReferencesUtlType.Open();
                    if (result == 0)
                    {
                        Console.WriteLine("Connection established successfully.");

                        // Do work here (e.g., read/write operations)
                    }
                    else
                    {
                        //Console.WriteLine($"Connection failed with error code: {result}. Attempting to reconnect...");
                    }

                    // Check connection status periodically
                    while (!stopRequested && IsConnectionAlive())
                    {
                        Thread.Sleep(5000); // Check every 5 seconds
                    }

                    if (!stopRequested)
                    {
                        //Console.WriteLine("Connection lost. Attempting to reconnect...");
                        lpcom_ReferencesUtlType.Close(); // Close the current connection
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            // Cleanup
            lpcom_ReferencesUtlType.Close();
            Console.WriteLine("Connection thread has stopped.");
        }
        private void PlcDataThreadProc()
        {
            while (true)
            {
                if (m_bConnected)
                {
                    try
                    {

                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(10);
            }
        }

        private bool IsConnectionAlive()
        {
            string device = "D0";
            int readValue;
            int result = lpcom_ReferencesUtlType.GetDevice(device, out readValue);

            // MX Component의 GetDevice 메서드는 연결이 성공적으로 수행되면 0을 반환합니다.
            // 상태가 변화한 경우에만 OnConnectionChanged 콜백을 발동합니다.
            bool newConnected = (result == 0);
            if (newConnected != m_bConnected)
            {
                m_bConnected = newConnected;
                OnConnectionChanged?.Invoke(m_bConnected);
            }
            return m_bConnected;
        }
        public int BitWrite(string sDevice, string sBit, string sDeiveData)
        {
            lock (PLCLock)
            {
                int iReturnCode;

                // 개별 비트 쓰기: M100.3에 1 쓰기
                int writeData = 1; // 1을 쓰려면 ON, 0을 쓰려면 OFF
                writeData = int.Parse(sDeiveData);
                string sDeviceAddress = string.Format("{0}.{1} ", sDevice, sBit);

                iReturnCode = lpcom_ReferencesUtlType.SetDevice(sDeviceAddress, writeData);
                //result = lpcom_ReferencesUtlType.SetDevice("D0.3", writeData);
                if (iReturnCode == 0)
                {
                    Console.WriteLine("M100.3에 성공적으로 쓰기 완료");
                }
                else
                {
                    Console.WriteLine("비트 쓰기 실패");
                }

                return iReturnCode;
            }
        }
        public int BitRead(string sDevice, string sBit, out int readData)
        {
            lock (PLCLock)
            {
                int iReturnCode;
                //int readData;

                string sDeviceAddress = string.Format("{0}.{1} ", sDevice, sBit);

                iReturnCode = lpcom_ReferencesUtlType.GetDevice(sDeviceAddress, out readData);
                if (iReturnCode == 0)
                {
                    Console.WriteLine($"M100.2의 값은: {readData}");
                }
                else
                {
                    Console.WriteLine("비트 읽기 실패");
                }

                return iReturnCode;
            }
        }
        //public int WriteShort(string sDevice, string sDeiveData) //최대  32767
        //{
        //    lock (PLCLock)
        //    {
        //        int iReturnCode = -1;
        //        short shreadDeiveData;
        //        try
        //        {
        //            if (lpcom_ReferencesUtlType == null)
        //            {
        //                return iReturnCode;
        //            }

        //            ReadShort(sDevice, out shreadDeiveData);
        //            if (shreadDeiveData == short.Parse(sDeiveData))
        //            {
        //                iReturnCode = 0;
        //                return iReturnCode;
        //            }

        //            short writeData = 1; // 1을 쓰려면 ON, 0을 쓰려면 OFF
        //            writeData = short.Parse(sDeiveData);

        //            iReturnCode = lpcom_ReferencesUtlType.SetDevice2(sDevice, writeData);
        //            if (iReturnCode != 0)
        //            {
        //                Console.WriteLine($"쓰기 실패: {iReturnCode}");
        //                return iReturnCode;
        //            }

        //            return iReturnCode;
        //        }
        //        catch (Exception ex)
        //        {
        //            return iReturnCode;
        //        }
        //    }
        //}
        //public int WriteShort(string sDevice, string sDeiveData, ref short lastValue) //최대  32767
        //{
        //    lock (PLCLock)
        //    {
        //        int iReturnCode = -1;
        //        short shreadDeiveData;
        //        try
        //        {
        //            if (lpcom_ReferencesUtlType == null)
        //            {
        //                return iReturnCode;
        //            }

        //            //ReadShort(sDevice, out shreadDeiveData);
        //            //if (shreadDeiveData == short.Parse(sDeiveData))
        //            //{
        //            //    iReturnCode = 0;
        //            //    return iReturnCode;
        //            //}

        //            short writeData = short.Parse(sDeiveData);

        //            if (lastValue == writeData)
        //            {
        //                return iReturnCode;
        //            }

        //            iReturnCode = lpcom_ReferencesUtlType.SetDevice2(sDevice, writeData);
        //            if (iReturnCode != 0)
        //            {
        //                //Console.WriteLine($"쓰기 실패: {iReturnCode}");
        //                return iReturnCode;
        //            }
        //            if (iReturnCode == 0)
        //            {
        //                lastValue = writeData;
        //            }

        //            return iReturnCode;
        //        }
        //        catch (Exception ex)
        //        {
        //            return iReturnCode;
        //        }
        //    }
        //}
        public int WriteShort(string sDevice, string sDeiveData, ref short lastValue) //최대  32767
        {
            if (lpcom_ReferencesUtlType == null)
            {
                return -1;
            }

            short writeData;
            try
            {
                writeData = short.Parse(sDeiveData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing data: {ex.Message}");
                return -1;
            }

            if (lastValue == writeData)
            {
                return 0; // 값이 변경되지 않았으므로 쓰기 불필요
            }

            lock (PLCLock)
            {
                if (lastValue == writeData)
                {
                    return 0; // 다른 스레드가 이미 값을 업데이트한 경우
                }

                int iReturnCode;
                try
                {
                    iReturnCode = lpcom_ReferencesUtlType.SetDevice2(sDevice, writeData);
                    if (iReturnCode == 0)
                    {
                        lastValue = writeData; // 성공적으로 쓴 경우에만 lastValue 업데이트
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing data: {ex.Message}");
                    return -1;
                }

                return iReturnCode;
            }
        }
        /// <summary>
        /// 미쓰비시 PLC의 32비트 실수(REAL)를 읽습니다.
        /// 연속된 2개 레지스터(sDevice, sDevice+1)를 읽어 IEEE 754 float로 변환합니다.
        /// 예: D100 → D100(하위 16비트) + D101(상위 16비트)
        /// </summary>
        public int ReadFloat(string sDevice, out float value)
        {
            lock (PLCLock)
            {
                value = 0f;
                if (lpcom_ReferencesUtlType == null) return -1;

                // 주소 파싱: "D100" → prefix="D", addr=100
                int splitIdx = 0;
                while (splitIdx < sDevice.Length && !char.IsDigit(sDevice[splitIdx]))
                    splitIdx++;
                if (splitIdx == 0 || splitIdx >= sDevice.Length) return -1;

                string prefix  = sDevice.Substring(0, splitIdx);
                int    addrNum = int.Parse(sDevice.Substring(splitIdx));

                string addrLow  = $"{prefix}{addrNum}";       // 하위 16비트 레지스터
                string addrHigh = $"{prefix}{addrNum + 1}";   // 상위 16비트 레지스터

                short low, high;
                int ret;

                ret = lpcom_ReferencesUtlType.GetDevice2(addrLow, out low);
                if (ret != 0)
                {
                    Console.WriteLine($"ReadFloat 하위 읽기 실패: {ret}");
                    return ret;
                }

                ret = lpcom_ReferencesUtlType.GetDevice2(addrHigh, out high);
                if (ret != 0)
                {
                    Console.WriteLine($"ReadFloat 상위 읽기 실패: {ret}");
                    return ret;
                }

                // 하위 word + 상위 word → 32비트 IEEE 754 float
                uint bits = ((uint)(ushort)high << 16) | (uint)(ushort)low;
                value = BitConverter.ToSingle(BitConverter.GetBytes(bits), 0);
                return 0;
            }
        }

        public int ReadShort(string sDevice, out short sDeiveData) //최대  32767
        {
            lock (PLCLock)
            {
                int iReturnCode = -1;
                sDeiveData = -1;
                if (lpcom_ReferencesUtlType == null)
                {
                    return iReturnCode;
                }
                iReturnCode = lpcom_ReferencesUtlType.GetDevice2(sDevice, out sDeiveData);

                if (iReturnCode != 0)
                {
                    Console.WriteLine($"읽기 실패: {iReturnCode}");
                    return iReturnCode;
                }

                return iReturnCode;
            }
        }
        public int WriteString(string sDevice, string sDeiveData)
        {
            lock (PLCLock)
            {
                int iReturnCode = -1;

                string sDevieFirst = sDevice.Substring(0, 1);
                string sStartAddress = sDevice.Substring(1);
                int startAddress = int.Parse(sStartAddress);

                // 쓰고 싶은 문자열
                string strToWrite = sDeiveData;
                // 문자열을 ASCII 코드 배열로 변환
                byte[] asciiBytes = Encoding.ASCII.GetBytes(strToWrite);

                for (int i = 0; i < asciiBytes.Length; i++)
                {
                    // ASCII 값을 WORD 단위로 쓰기 위해 변환 (D레지스터는 16비트 단위로 데이터를 저장)
                    short value = asciiBytes[i];
                    // D레지스터 주소 산출
                    string address = $"{sDevieFirst}{startAddress + i}";
                    // 값을 쓰기
                    iReturnCode = lpcom_ReferencesUtlType.SetDevice(address, value);
                    if (iReturnCode != 0)
                    {
                        Console.WriteLine($"쓰기 실패: {iReturnCode}");
                        break;
                    }
                }

                //string strToWrite = string.Format("{0}.{1} ", sDevice, sDeiveData);

                return iReturnCode;
            }
        }
        public int ReadString(string sDevice, string sDeviceLength, out string readString)
        {
            lock (PLCLock)
            {
                int iReturnCode = -1;
                readString = "";
                string sDevieFirst = sDevice.Substring(0, 1);
                string sStartAddress = sDevice.Substring(1);
                int startAddress = int.Parse(sStartAddress);
                int length = int.Parse(sDeviceLength); // "Hello"의 길이와 같음

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < length; i++)
                {
                    short readValue;
                    string address = $"D{startAddress + i}";

                    // PLC에서 D레지스터 읽기
                    iReturnCode = lpcom_ReferencesUtlType.GetDevice2(address, out readValue);
                    if (iReturnCode != 0)
                    {
                        Console.WriteLine($"읽기 실패: {iReturnCode}");
                        lpcom_ReferencesUtlType.Close();
                        return iReturnCode;
                    }

                    // 읽은 데이터(ASCII 코드)를 문자로 변환하여 StringBuilder에 추가
                    char character = (char)readValue;
                    sb.Append(character);
                }

                // 완성된 문자열 출력
                readString = sb.ToString();
                Console.WriteLine($"PLC로부터 읽은 문자열: {readString}");

                return iReturnCode;
            }
        }
        //Hi
        //첫 번째 문자(H)는 상위 바이트로, 두 번째 문자(i)는 하위 바이트
        public int Write2WordReverseString(string sDevice, string sDeiveData)
        {
            lock (PLCLock)
            {
                int iReturnCode = -1;
                string sDevieFirst = sDevice.Substring(0, 1);
                string sStartAddress = sDevice.Substring(1);
                int startAddress = int.Parse(sStartAddress);

                // 쓰고 싶은 문자열 "Hello, World!";
                // 쓰고 싶은 긴 문자열
                string strToWrite = sDeiveData;

                // 문자열의 길이가 홀수인 경우 마지막에 NULL 문자(ASCII 0)를 추가
                if (strToWrite.Length % 2 != 0)
                {
                    strToWrite += "\0";
                }

                // 문자열을 ASCII 코드 배열로 변환
                byte[] asciiBytes = Encoding.ASCII.GetBytes(strToWrite);

                // D레지스터의 시작 주소
                //int startAddress = 1000;

                for (int i = 0; i < asciiBytes.Length; i += 2)
                {
                    // 두 개의 ASCII 값을 하나의 WORD(16비트)로 조합
                    // 첫 번째 바이트는 상위 바이트, 두 번째 바이트는 하위 바이트
                    short value = (short)((asciiBytes[i] << 8) | asciiBytes[i + 1]);

                    // D레지스터 주소 계산
                    string address = $"D{startAddress + (i / 2)}";

                    // 조합된 값을 D레지스터에 쓰기
                    iReturnCode = lpcom_ReferencesUtlType.SetDevice(address, value);
                    if (iReturnCode != 0)
                    {
                        Console.WriteLine($"쓰기 실패: {iReturnCode}");
                        return iReturnCode;
                    }
                }
                return iReturnCode;
            }
        }
        public int Read2WordReverseString(string sDevice, string sDeviceLength, out string readString)
        {
            lock (PLCLock)
            {
                int iReturnCode = -1;
                readString = "";
                string sDevieFirst = sDevice.Substring(0, 1);
                string sStartAddress = sDevice.Substring(1);
                int startAddress = int.Parse(sStartAddress);
                int length = int.Parse(sDeviceLength); // "Hello"의 길이와 같음
                                                       //if(length%2==1)
                                                       //{
                                                       //    length = length + 1;
                                                       //}

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < length; i++)
                {
                    short readValue;
                    string address = $"D{startAddress + i}";

                    // PLC에서 D레지스터 읽기
                    iReturnCode = lpcom_ReferencesUtlType.GetDevice2(address, out readValue);
                    if (iReturnCode != 0)
                    {
                        Console.WriteLine($"읽기 실패: {iReturnCode}");
                        lpcom_ReferencesUtlType.Close();
                        return iReturnCode;
                    }

                    // 읽은 데이터에서 상위 바이트(첫 번째 문자)와 하위 바이트(두 번째 문자) 추출
                    char char1 = (char)(readValue >> 8);
                    char char2 = (char)(readValue & 0xFF);

                    // 문자열로 변환하여 StringBuilder에 추가
                    // NULL 문자를 만나면 반복 종료
                    if (char1 == '\0') break;
                    sb.Append(char1);
                    if (char2 == '\0') break;
                    sb.Append(char2);
                }

                // 완성된 문자열 출력
                readString = sb.ToString();

                Console.WriteLine($"PLC로부터 읽은 문자열: {readString}");

                return iReturnCode;
            }
        }
        public int Write2WordForwardString(string sDevice, string sDeiveData)
        {
            lock (PLCLock)
            {
                int iReturnCode = -1;
                string sDevieFirst = sDevice.Substring(0, 1);
                string sStartAddress = sDevice.Substring(1);
                int startAddress = int.Parse(sStartAddress);

                // 쓰고 싶은 문자열 "Hello, World!";
                // 쓰고 싶은 긴 문자열
                string strToWrite = sDeiveData;

                // 문자열의 길이가 홀수인 경우 마지막에 NULL 문자(ASCII 0)를 추가
                if (strToWrite.Length % 2 != 0)
                {
                    strToWrite += "\0";
                }

                // 문자열을 ASCII 코드 배열로 변환
                byte[] asciiBytes = Encoding.ASCII.GetBytes(strToWrite);

                // D레지스터의 시작 주소
                //int startAddress = 1000;

                for (int i = 0; i < asciiBytes.Length; i += 2)
                {
                    // 두 개의 ASCII 값을 하나의 WORD(16비트)로 조합
                    // 첫 번째 바이트는 상위 바이트, 두 번째 바이트는 하위 바이트
                    short value = (short)((asciiBytes[i + 1] << 8) | asciiBytes[i]);

                    // D레지스터 주소 계산
                    string address = $"D{startAddress + (i / 2)}";

                    // 조합된 값을 D레지스터에 쓰기
                    iReturnCode = lpcom_ReferencesUtlType.SetDevice(address, value);
                    if (iReturnCode != 0)
                    {
                        Console.WriteLine($"쓰기 실패: {iReturnCode}");
                        return iReturnCode;
                    }
                }
                return iReturnCode;
            }
        }
        public int ClearWordForwardString(string sDevice, int length)
        {
            lock (PLCLock)
            {
                int iReturnCode = -1;
                string sDeviceFirst = sDevice.Substring(0, 1);
                string sStartAddress = sDevice.Substring(1);
                int startAddress = int.Parse(sStartAddress);

                // 초기화할 D 레지스터의 길이가 홀수인 경우 하나를 더 추가하여 짝수로 만듦
                if (length % 2 != 0)
                {
                    length += 1;
                }

                // 초기화할 WORD(16비트) 배열 생성
                short[] zeroValues = new short[length / 2];

                // D 레지스터를 0으로 초기화
                for (int i = 0; i < zeroValues.Length; i++)
                {
                    // D레지스터 주소 계산
                    string address = $"D{startAddress + i}";

                    // 0 값을 D레지스터에 쓰기
                    iReturnCode = lpcom_ReferencesUtlType.SetDevice(address, 0);
                    if (iReturnCode != 0)
                    {
                        Console.WriteLine($"쓰기 실패: {iReturnCode}");
                        return iReturnCode;
                    }
                }
                return iReturnCode;
            }
        }
        public int Read2WordForwardString(string sDevice, string sDeviceLength, out string readString)
        {
            lock (PLCLock)
            {
                int iReturnCode = -1;
                readString = "";
                string sDevieFirst = sDevice.Substring(0, 1);
                string sStartAddress = sDevice.Substring(1);
                int startAddress = int.Parse(sStartAddress);
                int length = int.Parse(sDeviceLength); // "Hello"의 길이와 같음
                                                       //if(length%2==1)
                                                       //{
                                                       //    length = length + 1;
                                                       //}

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < length; i++)
                {
                    short readValue;
                    string address = $"D{startAddress + i}";

                    // PLC에서 D레지스터 읽기
                    iReturnCode = lpcom_ReferencesUtlType.GetDevice2(address, out readValue);
                    if (iReturnCode != 0)
                    {
                        Console.WriteLine($"읽기 실패: {iReturnCode}");
                        lpcom_ReferencesUtlType.Close();
                        return iReturnCode;
                    }

                    // 읽은 데이터에서 상위 바이트(첫 번째 문자)와 하위 바이트(두 번째 문자) 추출
                    char char1 = (char)(readValue & 0xFF);
                    char char2 = (char)(readValue >> 8);

                    // 문자열로 변환하여 StringBuilder에 추가
                    // NULL 문자를 만나면 반복 종료
                    if (char1 == '\0') break;
                    sb.Append(char1);
                    if (char2 == '\0') break;
                    sb.Append(char2);
                }

                // 완성된 문자열 출력
                readString = sb.ToString();

                Console.WriteLine($"PLC로부터 읽은 문자열: {readString}");

                return iReturnCode;
            }
        }
        public void Dispose()
        {
            connectionThread.Abort();
            PlcDataThread.Abort();
            PlcAliveThread.Abort();

            lpcom_ReferencesUtlType = null;
            lpcom_ReferencesProgType = null;
            lpcom_ReferencesMsg = null;
        }
    }
    public class PulseDetector
    {
        int data = 0;
        object PLCLock = new object();
        /// <summary>
        /// 데이터가 바뀌기만 해도 감지합니다.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool Detect(int input)
        {
            lock (PLCLock)
            {
                if (input != data)
                {
                    data = input;

                    return true;
                }
                else
                {
                    data = input;

                    return false;
                }
            }
        }

        /// <summary>
        /// 특정 값을 감지합니다.
        /// input데이터에 값을 넣고, DetectValue에 데이터를 집어넣으면
        /// 그값을 감지합니다.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="DetectValue"></param>
        /// <returns></returns>
        public bool Detect(int input, int DetectValue)
        {
            lock (PLCLock)
            {
                if (input == DetectValue && input != data)
                {
                    data = input;

                    return true;
                }
                else
                {
                    data = input;

                    return false;
                }
            }

        }

        /// <summary>
        /// 이전 데이터 파라미터 추가됨.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="DetectValue"></param>
        /// <param name="BeforeValue"></param>
        /// <returns></returns>
        public bool Detect(int input, int DetectValue, int BeforeValue)
        {
            lock (PLCLock)
            {
                if (input == DetectValue && data == BeforeValue)
                {
                    data = input;

                    return true;
                }
                else
                {
                    data = input;

                    return false;
                }
            }

        }
    }
}
