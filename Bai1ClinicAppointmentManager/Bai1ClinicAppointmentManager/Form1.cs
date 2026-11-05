using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Bai1ClinicAppointmentManager
{
    // 1. Lớp dữ liệu được gộp chung tại đây
    public class Appointment
    {
        public string AppointmentId { get; set; }
        public string PatientName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Doctor { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }

        public Appointment() { }

        public Appointment(string id, string name, string phone, DateTime date, string doctor, string reason, string status)
        {
            AppointmentId = id;
            PatientName = name;
            PhoneNumber = phone;
            AppointmentDate = date;
            Doctor = doctor;
            Reason = reason;
            Status = status;
        }
    }

    // 2. Class Form1 xử lý giao diện & nghiệp vụ
    public partial class Form1 : Form
    {
        private BindingList<Appointment> _masterList = new BindingList<Appointment>();
        private BindingSource _bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            SetupCustomDataGridView();
            InitDefaults();
            ApplyFilter();
        }

        private void InitDefaults()
        {
            cboDoctor.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            cboFilterStatus.SelectedIndex = 0;
        }

        private void SetupCustomDataGridView()
        {
            dgvAppointments.Columns.Clear();
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AppointmentId", HeaderText = "Mã Lịch Hẹn", Width = 110 });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientName", HeaderText = "Họ Tên Bệnh Nhân", Width = 180 });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PhoneNumber", HeaderText = "Số Điện Thoại", Width = 120 });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AppointmentDate",
                HeaderText = "Ngày Giờ Hẹn",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Doctor", HeaderText = "Bác Sĩ", Width = 150 });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Reason", HeaderText = "Lý Do Khám", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Trạng Thái", Width = 110 });

            dgvAppointments.DataSource = _bindingSource;
        }

        private void ApplyFilter()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            bool useDateFilter = chkEnableDateFilter.Checked;
            DateTime filterDate = dtpFilterDate.Value.Date;
            string selectedStatus = cboFilterStatus.SelectedItem?.ToString();

            var filtered = _masterList.Where(app =>
            {
                bool matchesSearch = string.IsNullOrEmpty(keyword) ||
                                     app.PatientName.ToLower().Contains(keyword) ||
                                     app.PhoneNumber.Contains(keyword);

                bool matchesDate = !useDateFilter || app.AppointmentDate.Date == filterDate;
                bool matchesStatus = selectedStatus == "Tất cả trạng thái" || app.Status == selectedStatus;

                return matchesSearch && matchesDate && matchesStatus;
            }).ToList();

            _bindingSource.DataSource = new BindingList<Appointment>(filtered);
            lblStatusCount.Text = $"Số lịch hẹn: {filtered.Count} / Tổng: {_masterList.Count}";
        }

        private bool ValidateInputs(bool isNew)
        {
            errorProvider.Clear();
            bool isValid = true;

            string id = txtId.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                errorProvider.SetError(txtId, "Mã lịch hẹn không được để trống.");
                isValid = false;
            }
            else if (isNew && _masterList.Any(a => a.AppointmentId.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider.SetError(txtId, "Mã lịch hẹn đã tồn tại.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Họ tên bệnh nhân không được để trống.");
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
                errorProvider.SetError(txtPhone, "Số điện thoại không hợp lệ (Phải có 10 chữ số và bắt đầu bằng 0).");
                isValid = false;
            }

            if (dtpDate.Value < DateTime.Now.AddMinutes(-5))
            {
                errorProvider.SetError(dtpDate, "Ngày giờ hẹn không được nằm trong quá khứ.");
                MessageBox.Show("Ngày giờ hẹn không được nằm trong quá khứ!",
                                "Thông báo lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                errorProvider.SetError(txtReason, "Lý do khám không được để trống.");
                isValid = false;
            }

            return isValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(isNew: true)) return;

            Appointment app = new Appointment
            {
                AppointmentId = txtId.Text.Trim(),
                PatientName = txtName.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                AppointmentDate = dtpDate.Value,
                Doctor = cboDoctor.SelectedItem.ToString(),
                Reason = txtReason.Text.Trim(),
                Status = cboStatus.SelectedItem.ToString()
            };

            _masterList.Add(app);
            ApplyFilter();
            ClearInputFields();
            MessageBox.Show("Thêm lịch hẹn mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow?.DataBoundItem is Appointment selectedApp)
            {
                if (!ValidateInputs(isNew: false)) return;

                selectedApp.PatientName = txtName.Text.Trim();
                selectedApp.PhoneNumber = txtPhone.Text.Trim();
                selectedApp.AppointmentDate = dtpDate.Value;
                selectedApp.Doctor = cboDoctor.SelectedItem.ToString();
                selectedApp.Reason = txtReason.Text.Trim();
                selectedApp.Status = cboStatus.SelectedItem.ToString();

                _bindingSource.ResetBindings(false);
                ApplyFilter();
                MessageBox.Show("Cập nhật lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lịch hẹn từ danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow?.DataBoundItem is Appointment selectedApp)
            {
                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa lịch hẹn [{selectedApp.AppointmentId}]?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    _masterList.Remove(selectedApp);
                    ApplyFilter();
                    ClearInputFields();
                    MessageBox.Show("Đã xóa lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lịch hẹn cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReset_Click(object sender, EventArgs e) => ClearInputFields();

        private void dgvAppointments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow?.DataBoundItem is Appointment selectedApp)
            {
                txtId.Text = selectedApp.AppointmentId;
                txtId.ReadOnly = true;
                txtName.Text = selectedApp.PatientName;
                txtPhone.Text = selectedApp.PhoneNumber;
                dtpDate.Value = selectedApp.AppointmentDate > DateTime.Now ? selectedApp.AppointmentDate : DateTime.Now;
                cboDoctor.SelectedItem = selectedApp.Doctor;
                txtReason.Text = selectedApp.Reason;
                cboStatus.SelectedItem = selectedApp.Status;
                errorProvider.Clear();
            }
        }

        private void ClearInputFields()
        {
            txtId.ReadOnly = false;
            txtId.Clear();
            txtName.Clear();
            txtPhone.Clear();
            dtpDate.Value = DateTime.Now.AddHours(1);
            cboDoctor.SelectedIndex = 0;
            txtReason.Clear();
            cboStatus.SelectedIndex = 0;
            dgvAppointments.ClearSelection();
            errorProvider.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();
        private void chkEnableDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            dtpFilterDate.Enabled = chkEnableDateFilter.Checked;
            ApplyFilter();
        }
        private void dtpFilterDate_ValueChanged(object sender, EventArgs e) => ApplyFilter();
        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            var currentList = _bindingSource.DataSource as BindingList<Appointment>;
            if (currentList == null || currentList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất file CSV!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV File (*.csv)|*.csv";
                sfd.FileName = $"DanhSachLichHen_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Mã Lịch Hẹn,Họ Tên Bệnh Nhân,Số Điện Thoại,Ngày Giờ Hẹn,Bác Sĩ,Lý Do Khám,Trạng Thái");

                        foreach (var app in currentList)
                        {
                            string line = $"\"{app.AppointmentId}\",\"{app.PatientName}\",\"{app.PhoneNumber}\",\"{app.AppointmentDate:dd/MM/yyyy HH:mm}\",\"{app.Doctor}\",\"{app.Reason.Replace("\"", "\"\"")}\",\"{app.Status}\"";
                            sb.AppendLine(line);
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Xuất file CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}