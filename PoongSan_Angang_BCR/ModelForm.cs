using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public partial class ModelForm : Form
    {
        // ── 데이터 구조 ──
        private class ModelRow
        {
            public string Bore       { get; set; }
            public string Bullet     { get; set; }
            public string CartonBCD_A { get; set; }
            public string CartonBCD_E { get; set; }
            public string BoxBCD     { get; set; }
            public string WeightMin  { get; set; }
            public string WeightMax  { get; set; }
        }

        private List<ModelRow> _models      = new List<ModelRow>();
        private List<string>   _altRows     = new List<string>(); // 대체 바코드 행 보존용
        private string         _csvPath     = Define.BcdCsvPath;
        private const int      ROWS_PER_PAGE = 8;
        private int            _currentPage  = 0;
        private int            _selectedIndex = -1;

        // SystemData 참조 (비밀번호 변경에 사용)
        private SystemData _systemData;

        // 추가/변경/삭제/저장 버튼 클릭 여부 플래그
        // true(1)이면 Form1에서 CSV 재로드 및 콤보박스 초기화 수행
        public bool DataModified { get; private set; } = false;

        public ModelForm(SystemData systemData)
        {
            InitializeComponent();
            _systemData = systemData;
            LoadCsv();
            RefreshGrid();
        }

        // ────────────────────────────────────────────
        // CSV 불러오기
        // ────────────────────────────────────────────
        private void LoadCsv()
        {
            _models.Clear();
            _altRows.Clear();

            if (!File.Exists(_csvPath))
            {
                MessageBox.Show("CSV 파일을 찾을 수 없습니다.\n" + _csvPath);
                return;
            }

            var lines = File.ReadAllLines(_csvPath)
                            .Where(l => !string.IsNullOrWhiteSpace(l))
                            .ToList();

            var dict = new Dictionary<string, ModelRow>();

            for (int i = 1; i < lines.Count; i++)
            {
                string[] cells = lines[i].Split(',');
                if (cells.Length < 5) continue;

                string bore     = cells[0].Trim();
                string bullet   = cells[1].Trim();
                string local    = cells[2].Trim();
                string cartonBcd = cells[3].Trim();
                string boxBcd   = cells[4].Trim();
                string key      = bore + "|" + bullet;

                if (!dict.ContainsKey(key))
                {
                    dict[key] = new ModelRow
                    {
                        Bore       = bore,
                        Bullet     = bullet,
                        CartonBCD_A = "",
                        CartonBCD_E = "",
                        BoxBCD     = boxBcd,
                        WeightMin  = cells.Length > 5 ? cells[5].Trim() : "",
                        WeightMax  = cells.Length > 6 ? cells[6].Trim() : ""
                    };
                }

                if (local == "A")
                {
                    if (!string.IsNullOrEmpty(dict[key].CartonBCD_A) && dict[key].CartonBCD_A != "X")
                    {
                        // 이미 A 바코드가 있으면 기존 값을 대체 행으로 보존
                        _altRows.Add(string.Format("{0},{1},A,{2},{3}",
                            dict[key].Bore, dict[key].Bullet,
                            dict[key].CartonBCD_A, dict[key].BoxBCD));
                    }
                    dict[key].CartonBCD_A = cartonBcd;
                    if (cells.Length > 5) dict[key].WeightMin = cells[5].Trim();
                    if (cells.Length > 6) dict[key].WeightMax = cells[6].Trim();
                }
                else if (local == "E")
                {
                    dict[key].CartonBCD_E = cartonBcd;
                }

                dict[key].BoxBCD = boxBcd;
            }

            _models = dict.Values.ToList();
        }

        // ────────────────────────────────────────────
        // CSV 저장
        // ────────────────────────────────────────────
        private void SaveCsv()
        {
            try
            {
                var lines = new List<string>();
                lines.Add("bore,bullet,Local,Carton BCD,Box BCD");

                foreach (var m in _models)
                {
                    string wMin = string.IsNullOrEmpty(m.WeightMin) ? "0" : m.WeightMin;
                    string wMax = string.IsNullOrEmpty(m.WeightMax) ? "0" : m.WeightMax;

                    lines.Add(string.Format("{0},{1},A,{2},{3},{4},{5}",
                        m.Bore, m.Bullet,
                        string.IsNullOrEmpty(m.CartonBCD_A) ? "X" : m.CartonBCD_A,
                        string.IsNullOrEmpty(m.BoxBCD)      ? "X" : m.BoxBCD,
                        wMin, wMax));

                    lines.Add(string.Format("{0},{1},E,{2},{3},{4},{5}",
                        m.Bore, m.Bullet,
                        string.IsNullOrEmpty(m.CartonBCD_E) ? "X" : m.CartonBCD_E,
                        string.IsNullOrEmpty(m.BoxBCD)      ? "X" : m.BoxBCD,
                        wMin, wMax));
                }

                // 대체 바코드 행 추가 (714569 등 alternate 버전 보존)
                foreach (var alt in _altRows)
                    lines.Add(alt);

                File.WriteAllLines(_csvPath, lines, System.Text.Encoding.UTF8);
                MessageBox.Show("저장 완료했습니다.", "저장",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("저장 실패: " + ex.Message, "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ────────────────────────────────────────────
        // 페이지
        // ────────────────────────────────────────────
        private int TotalPages
        {
            get
            {
                int total = (int)Math.Ceiling(_models.Count / (double)ROWS_PER_PAGE);
                return Math.Max(1, total);
            }
        }

        // ────────────────────────────────────────────
        // 그리드 새로고침
        // ────────────────────────────────────────────
        private void RefreshGrid()
        {
            dataGridView1.Rows.Clear();

            int start = _currentPage * ROWS_PER_PAGE;
            int end   = Math.Min(start + ROWS_PER_PAGE, _models.Count);

            for (int i = start; i < end; i++)
            {
                var m = _models[i];
                dataGridView1.Rows.Add(
                    i + 1,
                    m.Bore,
                    m.Bullet,
                    m.CartonBCD_A,
                    m.CartonBCD_E,
                    m.BoxBCD,
                    m.WeightMin,
                    m.WeightMax);
            }

            // DataGridView 자동 선택 해제 (첫 번째 행이 자동으로 파란색이 되는 문제 방지)
            dataGridView1.ClearSelection();

            // 선택 행 색상
            if (_selectedIndex >= start && _selectedIndex < end)
            {
                int rowIdx = _selectedIndex - start;
                dataGridView1.Rows[rowIdx].DefaultCellStyle.BackColor =
                    Color.FromArgb(0, 100, 180);
                dataGridView1.Rows[rowIdx].DefaultCellStyle.ForeColor = Color.White;
            }

            lblPage.Text    = string.Format("{0} / {1} 페이지", _currentPage + 1, TotalPages);
            btn_Prev.Enabled = _currentPage > 0;
            btn_Next.Enabled = _currentPage < TotalPages - 1;
        }

        // ────────────────────────────────────────────
        // 이벤트 핸들러
        // ────────────────────────────────────────────

        // 행 선택
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedIndex = _currentPage * ROWS_PER_PAGE + e.RowIndex;
            RefreshGrid();
        }

        // ── 추가 버튼 ──
        // 빈 AddEditModelForm 으로 신규 모델 입력
        private void btn_Add_Click(object sender, EventArgs e)
        {
            using (var dlg = new AddEditModelForm(isEditMode: false))
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                // 중복 확인
                bool exists = _models.Any(m =>
                    m.Bore   == dlg.ResultBore &&
                    m.Bullet == dlg.ResultBullet);

                if (exists)
                {
                    MessageBox.Show("이미 존재하는 구경/탄종입니다.",
                        "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _models.Add(new ModelRow
                {
                    Bore       = dlg.ResultBore,
                    Bullet     = dlg.ResultBullet,
                    CartonBCD_A = dlg.ResultCartonA,
                    CartonBCD_E = dlg.ResultCartonE,
                    BoxBCD     = dlg.ResultBox,
                    WeightMin  = dlg.ResultWeightMin,
                    WeightMax  = dlg.ResultWeightMax
                });

                DataModified   = true;   // ← 추가 플래그 ON
                _selectedIndex = _models.Count - 1;
                _currentPage   = (_models.Count - 1) / ROWS_PER_PAGE;
                RefreshGrid();
            }
        }

        // ── 변경 버튼 ──
        // 선택된 행의 기존 값을 AddEditModelForm 에 미리 채워서 수정
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (_selectedIndex < 0 || _selectedIndex >= _models.Count)
            {
                MessageBox.Show("변경할 항목을 선택해 주세요.",
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var m = _models[_selectedIndex];

            using (var dlg = new AddEditModelForm(
                isEditMode: true,
                bore:      m.Bore,
                bullet:    m.Bullet,
                cartonA:   m.CartonBCD_A,
                cartonE:   m.CartonBCD_E,
                box:       m.BoxBCD,
                weightMin: m.WeightMin,
                weightMax: m.WeightMax))
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                _models[_selectedIndex] = new ModelRow
                {
                    Bore       = dlg.ResultBore,
                    Bullet     = dlg.ResultBullet,
                    CartonBCD_A = dlg.ResultCartonA,
                    CartonBCD_E = dlg.ResultCartonE,
                    BoxBCD     = dlg.ResultBox,
                    WeightMin  = dlg.ResultWeightMin,
                    WeightMax  = dlg.ResultWeightMax
                };

                DataModified = true;     // ← 변경 플래그 ON
                RefreshGrid();
                MessageBox.Show("변경되었습니다.", "완료",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ── 삭제 버튼 ──
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (_selectedIndex < 0 || _selectedIndex >= _models.Count)
            {
                MessageBox.Show("삭제할 항목을 선택해 주세요.",
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var m  = _models[_selectedIndex];
            var dr = MessageBox.Show(
                string.Format("{0} / {1} 을(를) 삭제하시겠습니까?", m.Bore, m.Bullet),
                "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                _models.RemoveAt(_selectedIndex);
                DataModified   = true;   // ← 삭제 플래그 ON
                _selectedIndex = -1;

                if (_currentPage >= TotalPages)
                    _currentPage = TotalPages - 1;

                RefreshGrid();
            }
        }

        // ── 저장 버튼 ──
        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveCsv();
            DataModified = true;     // ← 저장 플래그 ON
        }

        // ── 페이지 이동 ──
        private void btn_Prev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 0) { _currentPage--; RefreshGrid(); }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (_currentPage < TotalPages - 1) { _currentPage++; RefreshGrid(); }
        }

        // ── 닫기 ──
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
