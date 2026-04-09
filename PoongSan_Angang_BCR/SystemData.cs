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
                //ini.WriteString(section, "melsecplcUse", melsecplcUse);
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
            }
        }
    }
}
