using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public partial class EmployeeForm : Form
    {
        private readonly SystemData _systemData;

        // VS Designer용 기본 생성자
        public EmployeeForm()
        {
            InitializeComponent();
        }

        public EmployeeForm(SystemData systemData)
        {
            _systemData = systemData;
            InitializeComponent();
            WireEvents();
            RefreshList();
        }

        private void WireEvents()
        {
            btnClose.Click  += (s, e) => this.Close();
            btnSelect.Click += OnSelectClick;
            btnAdd.Click    += OnAddClick;
            btnDelete.Click += OnDeleteClick;
        }

        private void RefreshList()
        {
            _listBox.Items.Clear();
            foreach (var id in GetCurrentIds())
                _listBox.Items.Add(id);

            if (!string.IsNullOrEmpty(_systemData.CurrentEmployeeId))
            {
                int idx = _listBox.Items.IndexOf(_systemData.CurrentEmployeeId);
                if (idx >= 0)
                    _listBox.SetSelected(idx, true);
            }
        }

        private List<string> GetCurrentIds()
        {
            if (string.IsNullOrEmpty(_systemData.EmployeeIds))
                return new List<string>();
            return _systemData.EmployeeIds
                .Split(',')
                .Select(s => s.Trim())
                .Where(s => s.Length > 0)
                .ToList();
        }

        private void SaveIds(List<string> ids)
        {
            _systemData.EmployeeIds = string.Join(",", ids);
            _systemData.Save();
        }

        private bool Authenticate()
        {
            using (var pw = new PasswordForm(_systemData.LoginPassword))
            {
                pw.ShowDialog(this);
                return pw.IsAuthenticated;
            }
        }

        private void OnSelectClick(object sender, EventArgs e)
        {
            if (_listBox.SelectedItem == null)
            {
                MessageBox.Show("출근할 사번을 선택하세요.", "안내",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _systemData.CurrentEmployeeId = _listBox.SelectedItem.ToString();
            _systemData.Save();
            MessageBox.Show(string.Format("작업자 [{0}] 출근 처리되었습니다.", _systemData.CurrentEmployeeId),
                "출근 선택", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void OnAddClick(object sender, EventArgs e)
        {
            if (!Authenticate()) return;

            using (var keypad = new InputKeypadForm("사번 (숫자 8자리)"))
            {
                if (keypad.ShowDialog(this) != DialogResult.OK) return;

                string id = keypad.InputText.Trim();
                if (id.Length != 8 || !id.All(char.IsDigit))
                {
                    MessageBox.Show("사번은 숫자 8자리여야 합니다.", "입력 오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var ids = GetCurrentIds();
                if (ids.Contains(id))
                {
                    MessageBox.Show("이미 등록된 사번입니다.", "중복",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ids.Add(id);
                SaveIds(ids);
                RefreshList();
            }
        }

        private void OnDeleteClick(object sender, EventArgs e)
        {
            if (_listBox.SelectedItem == null)
            {
                MessageBox.Show("삭제할 사번을 선택하세요.", "안내",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!Authenticate()) return;

            string target = _listBox.SelectedItem.ToString();
            var ids = GetCurrentIds();
            ids.Remove(target);
            SaveIds(ids);

            if (_systemData.CurrentEmployeeId == target)
            {
                _systemData.CurrentEmployeeId = "";
                _systemData.Save();
            }

            RefreshList();
        }
    }
}
