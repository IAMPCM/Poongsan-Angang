using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PoongSan_Angang_BCR
{
    public class EmployeeForm : Form
    {
        private readonly SystemData _systemData;
        private ListBox _listBox;

        public EmployeeForm(SystemData systemData)
        {
            _systemData = systemData;
            BuildUI();
            RefreshList();
        }

        private void BuildUI()
        {
            this.Text            = "사번 관리";
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor       = Color.FromArgb(51, 51, 56);
            this.Size            = new Size(460, 400);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.TopMost         = true;

            // 타이틀
            var lblTitle = new Label
            {
                Text      = "사번 관리",
                Font      = new Font("굴림", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(51, 51, 56),
                Size      = new Size(410, 44),
                Location  = new Point(20, 12),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // 닫기 버튼
            var btnClose = new Button
            {
                Text      = "✕",
                Font      = new Font("굴림", 12F, FontStyle.Bold),
                BackColor = Color.FromArgb(51, 51, 56),
                ForeColor = Color.White,
                Size      = new Size(40, 30),
                Location  = new Point(410, 5),
                FlatStyle = FlatStyle.Flat
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();

            // 사번 목록
            _listBox = new ListBox
            {
                Font      = new Font("굴림", 16F, FontStyle.Bold),
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black,
                Size      = new Size(420, 240),
                Location  = new Point(20, 65),
                BorderStyle = BorderStyle.FixedSingle
            };

            // 버튼 3개
            int btnY = 320;
            int btnW = 125;

            var btnSelect = MakeBtn("출근 선택", Color.FromArgb(39, 174, 96),  20,  btnY, btnW);
            var btnAdd    = MakeBtn("추  가",    Color.FromArgb(52, 152, 219), 160, btnY, btnW);
            var btnDelete = MakeBtn("삭  제",    Color.FromArgb(231, 76, 60),  300, btnY, btnW);

            btnSelect.Click += OnSelectClick;
            btnAdd.Click    += OnAddClick;
            btnDelete.Click += OnDeleteClick;

            this.Controls.Add(lblTitle);
            this.Controls.Add(btnClose);
            this.Controls.Add(_listBox);
            this.Controls.Add(btnSelect);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnDelete);
        }

        private Button MakeBtn(string text, Color color, int x, int y, int w)
        {
            var btn = new Button
            {
                Text      = text,
                Font      = new Font("굴림", 13F, FontStyle.Bold),
                BackColor = color,
                ForeColor = Color.White,
                Size      = new Size(w, 55),
                Location  = new Point(x, y),
                FlatStyle = FlatStyle.Flat
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private void RefreshList()
        {
            _listBox.Items.Clear();
            foreach (var id in GetCurrentIds())
                _listBox.Items.Add(id);

            // 현재 작업자 선택 표시
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
                if (keypad.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;

                string id = keypad.InputText.Trim();

                // 유효성 검사: 8자리 숫자
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

            // 현재 작업자가 삭제된 경우 초기화
            if (_systemData.CurrentEmployeeId == target)
            {
                _systemData.CurrentEmployeeId = "";
                _systemData.Save();
            }

            RefreshList();
        }
    }
}
