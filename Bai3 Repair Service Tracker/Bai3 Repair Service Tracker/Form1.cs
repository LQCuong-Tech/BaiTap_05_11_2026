using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Bai3_Repair_Service_Tracker
{
    public class RepairOrder
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string DeviceType { get; set; }
        public string IssueDescription { get; set; }
        public DateTime ReceivedDate { get; set; }
        public decimal EstimatedCost { get; set; }
        public string Status { get; set; }
        public string ImagePath { get; set; }

        public RepairOrder() { }

        public RepairOrder(string orderId, string customerName, string phoneNumber, string deviceType, string issueDescription, DateTime receivedDate, decimal estimatedCost, string status, string imagePath)
        {
            OrderId = orderId;
            CustomerName = customerName;
            PhoneNumber = phoneNumber;
            DeviceType = deviceType;
            IssueDescription = issueDescription;
            ReceivedDate = receivedDate;
            EstimatedCost = estimatedCost;
            Status = status;
            ImagePath = imagePath;
        }
    }

    public partial class Form1 : Form
    {
        private BindingList<RepairOrder> _masterList = new BindingList<RepairOrder>();
        private BindingSource _bindingSource = new BindingSource();
        private string _selectedImagePath = string.Empty;

        public Form1()
        {
            InitializeComponent();
            SetupCustomDataGridView();
            InitDefaults();
            ApplyFilter();
        }

        private void InitDefaults()
        {
            cboDeviceType.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            cboFilterStatus.SelectedIndex = 0;
            dtpReceivedDate.Value = DateTime.Today;
        }

        private void SetupCustomDataGridView()
        {
            dgvOrders.Columns.Clear();
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "OrderId", HeaderText = "Mã Đơn", Width = 90 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CustomerName", HeaderText = "Tên Khách Hàng", Width = 150 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PhoneNumber", HeaderText = "Số Điện Thoại", Width = 110 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DeviceType", HeaderText = "Loại Thiết Bị", Width = 120 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReceivedDate",
                HeaderText = "Ngày Nhận",
                Width = 95,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EstimatedCost",
                HeaderText = "Chi Phí Dự Kiến",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IssueDescription", HeaderText = "Mô Tả Lỗi", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Trạng Thái", Width = 110 });

            dgvOrders.DataSource = _bindingSource;
        }

        private void ApplyFilter()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            string selectedStatus = cboFilterStatus.SelectedItem?.ToString();

            var filtered = _masterList.Where(order =>
            {
                bool matchesSearch = string.IsNullOrEmpty(keyword) ||
                                     order.OrderId.ToLower().Contains(keyword) ||
                                     order.CustomerName.ToLower().Contains(keyword) ||
                                     order.PhoneNumber.Contains(keyword);

                bool matchesStatus = selectedStatus == "Tất cả trạng thái" || order.Status == selectedStatus;

                return matchesSearch && matchesStatus;
            }).ToList();

            _bindingSource.DataSource = new BindingList<RepairOrder>(filtered);

            decimal pendingTotalCost = _masterList
                .Where(o => o.Status != "Hoàn tất" && o.Status != "Đã hủy")
                .Sum(o => o.EstimatedCost);

            lblStatusCount.Text = $"Đang hiển thị: {filtered.Count} / Tổng số đơn: {_masterList.Count}";
            lblPendingCost.Text = $" | Chi phí đơn chưa hoàn tất: {pendingTotalCost:N0} VNĐ";
        }

        private bool ValidateInputs(bool isNew)
        {
            errorProvider.Clear();
            bool isValid = true;

            string id = txtOrderId.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                errorProvider.SetError(txtOrderId, "Mã đơn không được để trống.");
                isValid = false;
            }
            else if (isNew && _masterList.Any(o => o.OrderId.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider.SetError(txtOrderId, "Mã đơn dịch vụ đã tồn tại.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                errorProvider.SetError(txtCustomerName, "Tên khách hàng không được để trống.");
                isValid = false;
            }

            string phone = txtPhone.Text.Trim();
            if (string.IsNullOrEmpty(phone))
            {
                errorProvider.SetError(txtPhone, "Số điện thoại không được để trống.");
                isValid = false;
            }
            else if (!Regex.IsMatch(phone, @"^0\d{9}$"))
            {
                errorProvider.SetError(txtPhone, "Số điện thoại không hợp lệ (gồm 10 chữ số bắt đầu bằng 0).");
                isValid = false;
            }

            if (!decimal.TryParse(txtEstimatedCost.Text.Trim(), out decimal cost) || cost < 0)
            {
                errorProvider.SetError(txtEstimatedCost, "Chi phí phải là số không âm.");
                MessageBox.Show("Chi phí dự kiến không được là số âm!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEstimatedCost.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIssueDescription.Text))
            {
                errorProvider.SetError(txtIssueDescription, "Mô tả lỗi bắt buộc phải nhập.");
                MessageBox.Show("Vui lòng nhập mô tả lỗi cho thiết bị!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIssueDescription.Focus();
                return false;
            }

            return isValid;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "File Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Chọn ảnh thiết bị sửa chữa";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = ofd.FileName;
                    LoadDeviceImage(_selectedImagePath);
                }
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            _selectedImagePath = string.Empty;
            picDevice.ImageLocation = null;
            picDevice.Image = null;
        }

        private void LoadDeviceImage(string path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                picDevice.ImageLocation = path;
            }
            else
            {
                picDevice.ImageLocation = null;
                picDevice.Image = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(isNew: true)) return;

            decimal.TryParse(txtEstimatedCost.Text.Trim(), out decimal cost);

            RepairOrder order = new RepairOrder
            {
                OrderId = txtOrderId.Text.Trim(),
                CustomerName = txtCustomerName.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                DeviceType = cboDeviceType.SelectedItem.ToString(),
                ReceivedDate = dtpReceivedDate.Value.Date,
                EstimatedCost = cost,
                Status = cboStatus.SelectedItem.ToString(),
                IssueDescription = txtIssueDescription.Text.Trim(),
                ImagePath = _selectedImagePath
            };

            _masterList.Add(order);
            ApplyFilter();
            ClearInputFields();
            MessageBox.Show("Thêm đơn đăng ký sửa chữa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow?.DataBoundItem is RepairOrder selectedOrder)
            {
                if (!ValidateInputs(isNew: false)) return;

                decimal.TryParse(txtEstimatedCost.Text.Trim(), out decimal cost);

                selectedOrder.CustomerName = txtCustomerName.Text.Trim();
                selectedOrder.PhoneNumber = txtPhone.Text.Trim();
                selectedOrder.DeviceType = cboDeviceType.SelectedItem.ToString();
                selectedOrder.ReceivedDate = dtpReceivedDate.Value.Date;
                selectedOrder.EstimatedCost = cost;
                selectedOrder.Status = cboStatus.SelectedItem.ToString();
                selectedOrder.IssueDescription = txtIssueDescription.Text.Trim();
                selectedOrder.ImagePath = _selectedImagePath;

                _bindingSource.ResetBindings(false);
                ApplyFilter();
                MessageBox.Show("Cập nhật thông tin đơn sửa chữa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn sửa chữa cần cập nhật từ danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow?.DataBoundItem is RepairOrder selectedOrder)
            {
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa đơn sửa chữa [{selectedOrder.OrderId}] của KH '{selectedOrder.CustomerName}'?",
                    "Xác nhận xóa đơn",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _masterList.Remove(selectedOrder);
                    ApplyFilter();
                    ClearInputFields();
                    MessageBox.Show("Đã xóa đơn sửa chữa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn sửa chữa cần xóa từ danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReset_Click(object sender, EventArgs e) => ClearInputFields();

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow?.DataBoundItem is RepairOrder selectedOrder)
            {
                txtOrderId.Text = selectedOrder.OrderId;
                txtOrderId.ReadOnly = true;
                txtCustomerName.Text = selectedOrder.CustomerName;
                txtPhone.Text = selectedOrder.PhoneNumber;
                cboDeviceType.SelectedItem = selectedOrder.DeviceType;
                dtpReceivedDate.Value = selectedOrder.ReceivedDate;
                txtEstimatedCost.Text = selectedOrder.EstimatedCost.ToString("G0");
                cboStatus.SelectedItem = selectedOrder.Status;
                txtIssueDescription.Text = selectedOrder.IssueDescription;

                _selectedImagePath = selectedOrder.ImagePath;
                LoadDeviceImage(_selectedImagePath);

                errorProvider.Clear();
            }
        }

        private void ClearInputFields()
        {
            txtOrderId.ReadOnly = false;
            txtOrderId.Clear();
            txtCustomerName.Clear();
            txtPhone.Clear();
            cboDeviceType.SelectedIndex = 0;
            dtpReceivedDate.Value = DateTime.Today;
            txtEstimatedCost.Text = "0";
            cboStatus.SelectedIndex = 0;
            txtIssueDescription.Clear();
            _selectedImagePath = string.Empty;
            picDevice.ImageLocation = null;
            picDevice.Image = null;

            dgvOrders.ClearSelection();
            errorProvider.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();
        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            var currentList = _bindingSource.DataSource as BindingList<RepairOrder>;
            if (currentList == null || currentList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu đơn hàng để xuất CSV!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV File (*.csv)|*.csv";
                sfd.FileName = $"DanhSachSuaChua_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Mã Đơn,Tên Khách Hàng,Số Điện Thoại,Loại Thiết Bị,Ngày Tiếp Nhận,Chi Phí Dự Kiến,Mô Tả Lỗi,Trạng Thái,Đường Dẫn Ảnh");

                        foreach (var order in currentList)
                        {
                            string line = $"\"{order.OrderId}\",\"{order.CustomerName}\",\"{order.PhoneNumber}\",\"{order.DeviceType}\",\"{order.ReceivedDate:dd/MM/yyyy}\",\"{order.EstimatedCost}\",\"{order.IssueDescription.Replace("\"", "\"\"")}\",\"{order.Status}\",\"{order.ImagePath}\"";
                            sb.AppendLine(line);
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Xuất danh sách đơn sửa chữa ra CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi xuất file CSV: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}