using System.IO;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public class Define
    {
        // ── 실행 파일 폴더 기준 기본 경로 ──
        // 어느 드라이브/폴더에 설치해도 별도 코드 수정 없이 동작합니다.
        //   [실행파일 위치]\Data\System.ini
        //   [실행파일 위치]\PoongSanBCD.csv
        //   [실행파일 위치]\History\카톤\yyyy년\M월\d일\CartonBCD_yyyyMMdd.csv  (카톤 검사 이력)
        //   [실행파일 위치]\History\골판지\yyyy년\M월\d일\BoxBCD_yyyyMMdd.csv   (골판지 검사 이력)
        //   [실행파일 위치]\History\Log\...                  (애플리케이션 로그)
        public static readonly string AppDir = Application.StartupPath;

        public static string SystemDataFileName = "System.ini";
        public static string SystemDataFilePath = Path.Combine(AppDir, "Data", "System.ini");
        public static string HistoryPath = Path.Combine(AppDir, "History");
        public static string BcdCsvPath         = Path.Combine(AppDir, "PoongSanBCD.csv");

        public static bool bSucessError = false;

        public static int IO_OUT_LAMP_RED    = 0;
        public static int IO_OUT_LAMP_YELLOW = 1;
        public static int IO_OUT_LAMP_GREEN  = 2;
        public static int IO_OUT_LAMP_BUZZER = 3;

    }
}
