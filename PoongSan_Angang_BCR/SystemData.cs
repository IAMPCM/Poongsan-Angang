namespace PoongSan_Angang_BCR
{
    public class SystemData
    {
        public Form1 frm1;

        public string SimulationUse;
        public string AutoMachineUse;
        public string TimeoutUse;
        public string TimeoutMinutes;  // 타임아웃 시간(분)
        public string LoginPassword; // 로그인 비밀번호
        public string melsecplcUse;

        public string PLC_Address;
        public string PLC_Port;
        public string PlcStationNo;      // MX Component 논리 스테이션 번호
        public string WeightPlcAddress1;  // 1번 탄 중량 레지스터 주소 (예: D1000)
        public string WeightPlcAddress2;  // 2번 탄 중량 레지스터 주소
        public string WeightPlcAddress3;  // 3번 탄 중량 레지스터 주소
        public string WeightPlcAddress4;  // 4번 탄 중량 레지스터 주소
        public string WeightPollSeconds;    // 중량 폴링 주기 (초, 1~999)
        public string WeightPollingEnabled; // 중량 폴링 ON/OFF ("true"/"false")

        // PLC D레지스터 주소 (앱 설정 화면에서 변경 가능)
        public string PlcAddrBoreData;      // PLC→PC 구경 데이터 주소       (기본: D10000)
        public string PlcAddrBoreDataLen;   // PLC→PC 구경 데이터 글자 수    (기본: 10)
        public string PlcAddrBcdLen;        // PLC→PC 바코드 길이 주소       (기본: D25008)
        public string PlcAddrBcdData;       // PLC→PC 바코드 데이터 주소     (기본: D25009)
        public string PlcAddrResultIndiv;   // PC→PLC 개별 검사결과 주소     (기본: D28060)
        public string PlcAddrResultBox;     // PC→PLC 박스 검사결과 주소     (기본: D28070)
        // 금일 검사 수량
        public string CountDate;       // 마지막 저장 날짜
        public string CartonOkList;    // 카톤박스 OK 바코드 목록 (쉼표 구분)
        public string CartonNgList;    // 카톤박스 NG 바코드 목록
        public string BoxOkList;       // 골판지 OK 바코드 목록
        public string BoxNgList;       // 골판지 NG 바코드 목록

        // 마지막 선택된 생산 모델 (프로그램 재시작 시 복원용)
        public string SavedBore;       // 마지막 선택 구경
        public string SavedBullet;     // 마지막 선택 탄종
        public string SavedLocal;      // 마지막 선택 Local (A/E)

        // 사번 관리
        public string EmployeeIds;        // 등록된 사번 목록 (쉼표 구분)
        public string CurrentEmployeeId;  // 현재 작업자 사번
        
        public SystemData(Form1 frm)
        {
            frm1 = frm;
        }

        public void Initalize()
        {

        }

        public void Load()
        {
            using (CIniFile ini = new CIniFile(Define.SystemDataFilePath))
            {
                string section = "System";

                SimulationUse = ini.ReadString(section, "SIMULATION", "");
                AutoMachineUse = ini.ReadString(section, "AutoMachineUse", "");
                TimeoutUse     = ini.ReadString(section, "TimeoutUse",     "true");
                TimeoutMinutes = ini.ReadString(section, "TimeoutMinutes", "1");
                LoginPassword = ini.ReadString(section, "LoginPassword", "1234");
                melsecplcUse = ini.ReadString(section, "melsecplcUse", "");
                PLC_Address = ini.ReadString(section, "PLC_Address", "");
                PLC_Port = ini.ReadString(section, "PLC_Port", "");
                PlcStationNo      = ini.ReadString(section, "PlcStationNo",      "0");
                WeightPlcAddress1 = ini.ReadString(section, "WeightPlcAddress1", "");
                WeightPlcAddress2 = ini.ReadString(section, "WeightPlcAddress2", "");
                WeightPlcAddress3 = ini.ReadString(section, "WeightPlcAddress3", "");
                WeightPlcAddress4 = ini.ReadString(section, "WeightPlcAddress4", "");
                // 구버전 마이그레이션: WeightPlcAddress(단일) → WeightPlcAddress1
                if (string.IsNullOrEmpty(WeightPlcAddress1))
                {
                    string old = ini.ReadString(section, "WeightPlcAddress", "");
                    if (!string.IsNullOrEmpty(old))
                        WeightPlcAddress1 = old;
                }
                WeightPollSeconds    = ini.ReadString(section, "WeightPollSeconds",    "30");
                WeightPollingEnabled = ini.ReadString(section, "WeightPollingEnabled", "true");

                // PLC D레지스터 주소
                PlcAddrBoreData    = ini.ReadString(section, "PlcAddrBoreData",    "D10000");
                PlcAddrBoreDataLen = ini.ReadString(section, "PlcAddrBoreDataLen", "10");
                PlcAddrBcdLen      = ini.ReadString(section, "PlcAddrBcdLen",      "D25008");
                PlcAddrBcdData     = ini.ReadString(section, "PlcAddrBcdData",     "D25009");
                PlcAddrResultIndiv = ini.ReadString(section, "PlcAddrResultIndiv", "D28060");
                PlcAddrResultBox   = ini.ReadString(section, "PlcAddrResultBox",   "D28070");

                // 금일 검사 수량 불러오기
                CountDate = ini.ReadString(section, "CountDate", "");
                CartonOkList = ini.ReadString(section, "CartonOkList", "");
                CartonNgList = ini.ReadString(section, "CartonNgList", "");
                BoxOkList = ini.ReadString(section, "BoxOkList", "");
                BoxNgList = ini.ReadString(section, "BoxNgList", "");

                // 마지막 선택 모델 불러오기
                SavedBore   = ini.ReadString(section, "SavedBore",   "");
                SavedBullet = ini.ReadString(section, "SavedBullet", "");
                SavedLocal  = ini.ReadString(section, "SavedLocal",  "");

                // 사번 불러오기
                EmployeeIds       = ini.ReadString(section, "EmployeeIds",       "");
                CurrentEmployeeId = ini.ReadString(section, "CurrentEmployeeId", "");
            }
        }

        public void Save()
        {
            // ── 저장 경로의 폴더가 없으면 자동 생성 ──
            // (Data 폴더가 없으면 WritePrivateProfileString이 조용히 실패하여
            //  읽을 때 기본값("")이 반환됨 → CountDate 불일치 → 수량 초기화 버그 원인)
            string dir = System.IO.Path.GetDirectoryName(Define.SystemDataFilePath);
            if (!string.IsNullOrEmpty(dir) && !System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);

            using (CIniFile ini = new CIniFile(Define.SystemDataFilePath))
            {
                string section = "System";

                ini.WriteString(section, "SIMULATION", SimulationUse);
                ini.WriteString(section, "melsecplcUse", melsecplcUse);
                ini.WriteString(section, "AutoMachineUse", AutoMachineUse);
                ini.WriteString(section, "TimeoutUse",     TimeoutUse);
                ini.WriteString(section, "TimeoutMinutes", TimeoutMinutes ?? "1");
                ini.WriteString(section, "LoginPassword", LoginPassword);

                // 금일 검사 수량 저장
                ini.WriteString(section, "CountDate", CountDate);
                ini.WriteString(section, "CartonOkList", CartonOkList);
                ini.WriteString(section, "CartonNgList", CartonNgList);
                ini.WriteString(section, "BoxOkList", BoxOkList);
                ini.WriteString(section, "BoxNgList", BoxNgList);

                // 마지막 선택 모델 저장
                ini.WriteString(section, "SavedBore",   SavedBore   ?? "");
                ini.WriteString(section, "SavedBullet", SavedBullet ?? "");
                ini.WriteString(section, "SavedLocal",  SavedLocal  ?? "");

                // 사번 저장
                ini.WriteString(section, "EmployeeIds",       EmployeeIds       ?? "");
                ini.WriteString(section, "CurrentEmployeeId", CurrentEmployeeId ?? "");

                // PLC 중량 연동 설정 저장
                ini.WriteString(section, "PlcStationNo",       PlcStationNo       ?? "0");
                ini.WriteString(section, "WeightPlcAddress1",  WeightPlcAddress1  ?? "");
                ini.WriteString(section, "WeightPlcAddress2",  WeightPlcAddress2  ?? "");
                ini.WriteString(section, "WeightPlcAddress3",  WeightPlcAddress3  ?? "");
                ini.WriteString(section, "WeightPlcAddress4",  WeightPlcAddress4  ?? "");
                ini.WriteString(section, "WeightPollSeconds",  WeightPollSeconds  ?? "30");
                ini.WriteString(section, "WeightPollingEnabled", WeightPollingEnabled ?? "true");

                // PLC D레지스터 주소
                ini.WriteString(section, "PlcAddrBoreData",    PlcAddrBoreData    ?? "D10000");
                ini.WriteString(section, "PlcAddrBoreDataLen", PlcAddrBoreDataLen ?? "10");
                ini.WriteString(section, "PlcAddrBcdLen",      PlcAddrBcdLen      ?? "D25008");
                ini.WriteString(section, "PlcAddrBcdData",     PlcAddrBcdData     ?? "D25009");
                ini.WriteString(section, "PlcAddrResultIndiv", PlcAddrResultIndiv ?? "D28060");
                ini.WriteString(section, "PlcAddrResultBox",   PlcAddrResultBox   ?? "D28070");
            }
        }
    }
}
