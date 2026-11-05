using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bai2_Lab_Equipment_Checkout
{
    public class EquipmentBorrow
    {
        public string SlipId { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string Equipment { get; set; }
        public int Quantity { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }

        public EquipmentBorrow() { }

        public EquipmentBorrow(string slipId, string studentId, string studentName, string equipment, int quantity, DateTime borrowDate, DateTime dueDate, DateTime? returnDate, string status)
        {
            SlipId = slipId;
            StudentId = studentId;
            StudentName = studentName;
            Equipment = equipment;
            Quantity = quantity;
            BorrowDate = borrowDate;
            DueDate = dueDate;
            ReturnDate = returnDate;
            Status = status;
        }
    }

    public partial class Form1 : Form
    {
        private BindingList<EquipmentBorrow> _masterList = new BindingList<EquipmentBorrow>();
        private BindingSource _bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            SetupCustomDataGridView();
            InitDefaults();
            UpdateOverdueStatus();
            ApplyFilter();
        }

        private void InitDefaults()
        {
            cboEquipment.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            cboFilterStatus.SelectedIndex = 0;
            dtpBorrowDate.Value = DateTime.Today;
            dtpDueDate.Value = DateTime.Today.AddDays(7);
            dtpReturnDate.Value = DateTime.Today;
        }

        private void SetupCustomDataGridView()
        {
            dgvSlips.Columns.Clear();
            dgvSlips.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SlipId", HeaderText = "Mã Phiếu", Width = 90 });
            dgvSlips.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentId", HeaderText = "Mã Sinh Viên", Width = 110 });
            dgvSlips.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentName", HeaderText = "Họ Tên SV", Width = 150 });
            dgvSlips.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Equipment", HeaderText = "Thiết Bị", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvSlips.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "SL", Width = 50 });
            dgvSlips.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BorrowDate",
                HeaderText = "Ngày Mượn",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvSlips.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DueDate",
                HeaderText = "Hạn Trả",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvSlips.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReturnDate",
                HeaderText = "Ngày Trả TT",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy", NullValue = "---" }
            });
            dgvSlips.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Trạng Thái", Width = 100 });

            dgvSlips.DataSource = _bindingSource;
        }

        private void UpdateOverdueStatus()
        {
            DateTime today = DateTime.Today;
            foreach (var item in _masterList)
            {
                if (item.Status != "Đã trả")
                {
                    if (item.DueDate.Date < today)
                    {
                        item.Status = "Quá hạn";
                    }
                    else
                    {
                        item.Status = "Đang mượn";
                    }
                }
            }
        }

        private void ApplyFilter()
        {
            UpdateOverdueStatus();

            string keyword = txtSearch.Text.Trim().ToLower();
            string selectedStatus = cboFilterStatus.SelectedItem?.ToString();

            var filtered = _masterList.Where(item =>
            {
                bool matchesSearch = string.IsNullOrEmpty(keyword) ||
                                     item.StudentId.ToLower().Contains(keyword) ||
                                     item.Equipment.ToLower().Contains(keyword);

                bool matchesStatus = selectedStatus == "Tất cả trạng thái" || item.Status == selectedStatus;

                return matchesSearch && matchesStatus;
            }).ToList();

            _bindingSource.DataSource = new BindingList<EquipmentBorrow>(filtered);

            int totalCount = _masterList.Count;
            int overdueCount = _masterList.Count(x => x.Status == "Quá hạn");

            lblStatusCount.Text = $"Đang hiển thị: {filtered.Count} / Tổng số phiếu: {totalCount}";
            lblOverdueCount.Text = $" | Số phiếu quá hạn: {overdueCount}";
        }

        private bool ValidateInputs(bool isNew)
        {
            errorProvider.Clear();
            bool isValid = true;

            string slipId = txtSlipId.Text.Trim();
            if (string.IsNullOrEmpty(slipId))
            {
                errorProvider.SetError(txtSlipId, "Mã phiếu không được để trống.");
                isValid = false;
            }
            else if (isNew && _masterList.Any(x => x.SlipId.Equals(slipId, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider.SetError(txtSlipId, "Mã phiếu đã tồn tại.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                errorProvider.SetError(txtStudentId, "Mã sinh viên không được để trống.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtStudentName.Text))
            {
                errorProvider.SetError(txtStudentName, "Họ tên sinh viên không được để trống.");
                isValid = false;
            }

            if (cboEquipment.SelectedItem == null || string.IsNullOrWhiteSpace(cboEquipment.SelectedItem.ToString()))
            {
                errorProvider.SetError(cboEquipment, "Vui lòng chọn thiết bị mượn.");
                isValid = false;
            }

            if (nudQuantity.Value <= 0)
            {
                errorProvider.SetError(nudQuantity, "Số lượng mượn phải lớn hơn 0.");
                isValid = false;
            }

            if (dtpDueDate.Value.Date < dtpBorrowDate.Value.Date)
            {
                errorProvider.SetError(dtpDueDate, "Hạn trả không được trước ngày mượn.");
                MessageBox.Show("Hạn trả không được nhỏ hơn ngày mượn!", "Lỗi ngày tháng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
            }

            if (chkReturned.Checked && dtpReturnDate.Value.Date < dtpBorrowDate.Value.Date)
            {
                errorProvider.SetError(dtpReturnDate, "Ngày trả thực tế không được trước ngày mượn.");
                MessageBox.Show("Ngày trả thực tế không được nhỏ hơn ngày mượn!", "Lỗi ngày tháng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
            }

            return isValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(isNew: true)) return;

            string initialStatus = "Đang mượn";
            DateTime? returnDate = null;

            if (chkReturned.Checked)
            {
                initialStatus = "Đã trả";
                returnDate = dtpReturnDate.Value.Date;
            }
            else if (dtpDueDate.Value.Date < DateTime.Today)
            {
                initialStatus = "Quá hạn";
            }

            EquipmentBorrow item = new EquipmentBorrow
            {
                SlipId = txtSlipId.Text.Trim(),
                StudentId = txtStudentId.Text.Trim(),
                StudentName = txtStudentName.Text.Trim(),
                Equipment = cboEquipment.SelectedItem.ToString(),
                Quantity = (int)nudQuantity.Value,
                BorrowDate = dtpBorrowDate.Value.Date,
                DueDate = dtpDueDate.Value.Date,
                ReturnDate = returnDate,
                Status = initialStatus
            };

            _masterList.Add(item);
            ApplyFilter();
            ClearInputFields();
            MessageBox.Show("Tạo phiếu mượn thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvSlips.CurrentRow?.DataBoundItem is EquipmentBorrow selectedItem)
            {
                if (!ValidateInputs(isNew: false)) return;

                selectedItem.StudentId = txtStudentId.Text.Trim();
                selectedItem.StudentName = txtStudentName.Text.Trim();
                selectedItem.Equipment = cboEquipment.SelectedItem.ToString();
                selectedItem.Quantity = (int)nudQuantity.Value;
                selectedItem.BorrowDate = dtpBorrowDate.Value.Date;
                selectedItem.DueDate = dtpDueDate.Value.Date;

                if (chkReturned.Checked)
                {
                    selectedItem.ReturnDate = dtpReturnDate.Value.Date;
                    selectedItem.Status = "Đã trả";
                }
                else
                {
                    selectedItem.ReturnDate = null;
                    selectedItem.Status = (selectedItem.DueDate.Date < DateTime.Today) ? "Quá hạn" : "Đang mượn";
                }

                _bindingSource.ResetBindings(false);
                ApplyFilter();
                MessageBox.Show("Cập nhật thông tin phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần cập nhật từ danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMarkReturned_Click(object sender, EventArgs e)
        {
            if (dgvSlips.CurrentRow?.DataBoundItem is EquipmentBorrow selectedItem)
            {
                if (selectedItem.Status == "Đã trả")
                {
                    MessageBox.Show("Phiếu này đã được đánh dấu là Đã trả trước đó.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                selectedItem.ReturnDate = DateTime.Today;
                selectedItem.Status = "Đã trả";

                _bindingSource.ResetBindings(false);
                ApplyFilter();

                chkReturned.Checked = true;
                dtpReturnDate.Value = DateTime.Today;

                MessageBox.Show($"Xác nhận trả thiết bị cho phiếu [{selectedItem.SlipId}] thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần xác nhận trả.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSlips.CurrentRow?.DataBoundItem is EquipmentBorrow selectedItem)
            {
                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa phiếu mượn [{selectedItem.SlipId}] của SV '{selectedItem.StudentName}' không?",
                    "Xác nhận xóa phiếu",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    _masterList.Remove(selectedItem);
                    ApplyFilter();
                    ClearInputFields();
                    MessageBox.Show("Đã xóa phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần xóa từ danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReset_Click(object sender, EventArgs e) => ClearInputFields();

        private void dgvSlips_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSlips.CurrentRow?.DataBoundItem is EquipmentBorrow selectedItem)
            {
                txtSlipId.Text = selectedItem.SlipId;
                txtSlipId.ReadOnly = true;
                txtStudentId.Text = selectedItem.StudentId;
                txtStudentName.Text = selectedItem.StudentName;
                cboEquipment.SelectedItem = selectedItem.Equipment;
                nudQuantity.Value = selectedItem.Quantity;
                dtpBorrowDate.Value = selectedItem.BorrowDate;
                dtpDueDate.Value = selectedItem.DueDate;

                if (selectedItem.ReturnDate.HasValue)
                {
                    chkReturned.Checked = true;
                    dtpReturnDate.Value = selectedItem.ReturnDate.Value;
                }
                else
                {
                    chkReturned.Checked = false;
                    dtpReturnDate.Value = DateTime.Today;
                }

                cboStatus.SelectedItem = selectedItem.Status;
                errorProvider.Clear();
            }
        }

        private void ClearInputFields()
        {
            txtSlipId.ReadOnly = false;
            txtSlipId.Clear();
            txtStudentId.Clear();
            txtStudentName.Clear();
            cboEquipment.SelectedIndex = 0;
            nudQuantity.Value = 1;
            dtpBorrowDate.Value = DateTime.Today;
            dtpDueDate.Value = DateTime.Today.AddDays(7);
            chkReturned.Checked = false;
            dtpReturnDate.Value = DateTime.Today;
            cboStatus.SelectedIndex = 0;
            dgvSlips.ClearSelection();
            errorProvider.Clear();
        }

        private void chkReturned_CheckedChanged(object sender, EventArgs e)
        {
            dtpReturnDate.Enabled = chkReturned.Checked;
            cboStatus.SelectedItem = chkReturned.Checked ? "Đã trả" : (dtpDueDate.Value.Date < DateTime.Today ? "Quá hạn" : "Đang mượn");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();
        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            var currentList = _bindingSource.DataSource as BindingList<EquipmentBorrow>;
            if (currentList == null || currentList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trong danh sách đang hiển thị để xuất CSV!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV File (*.csv)|*.csv";
                sfd.FileName = $"DanhSachMuonThietBi_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Mã Phiếu,Mã Sinh Viên,Họ Tên Sinh Viên,Thiết Bị,Số Lượng,Ngày Mượn,Hạn Trả,Ngày Trả Thực Tế,Trạng Thái");

                        foreach (var item in currentList)
                        {
                            string returnDateStr = item.ReturnDate.HasValue ? item.ReturnDate.Value.ToString("dd/MM/yyyy") : "";
                            string line = $"\"{item.SlipId}\",\"{item.StudentId}\",\"{item.StudentName}\",\"{item.Equipment}\",\"{item.Quantity}\",\"{item.BorrowDate:dd/MM/yyyy}\",\"{item.DueDate:dd/MM/yyyy}\",\"{returnDateStr}\",\"{item.Status}\"";
                            sb.AppendLine(line);
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Xuất danh sách phiếu mượn ra CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi khi xuất file CSV: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}