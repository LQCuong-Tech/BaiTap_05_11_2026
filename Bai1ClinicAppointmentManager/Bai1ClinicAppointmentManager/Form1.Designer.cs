using System.Drawing;
using System.Windows.Forms;

namespace Bai1ClinicAppointmentManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatusCount = new System.Windows.Forms.ToolStripStatusLabel();

            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.tlpInput = new System.Windows.Forms.TableLayoutPanel();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();

            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();

            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.flpFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.chkEnableDateFilter = new System.Windows.Forms.CheckBox();
            this.dtpFilterDate = new System.Windows.Forms.DateTimePicker();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();

            this.dgvAppointments = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.tlpInput.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.flpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();

            // ErrorProvider
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

            // MenuStrip
            this.menuExportCsv.Text = "Xuất danh sách ra CSV";
            this.menuExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);
            this.menuFile.Text = "Hệ thống";
            this.menuFile.DropDownItems.Add(this.menuExportCsv);
            this.menuStrip.Items.Add(this.menuFile);

            // StatusStrip
            this.lblStatusCount.Text = "Tổng số lịch hẹn: 0";
            this.statusStrip.Items.Add(this.lblStatusCount);

            // Main Layout
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.RowCount = 3;
            this.mainLayout.Padding = new System.Windows.Forms.Padding(10);
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            // GroupBox Input
            this.grpInput.Text = "Thông Tin Lịch Hẹn";
            this.grpInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInput.AutoSize = true;

            // TableLayoutPanel Input
            this.tlpInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpInput.AutoSize = true;
            this.tlpInput.ColumnCount = 4;
            this.tlpInput.RowCount = 4;
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

            this.txtId.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.cboDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoctor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.cboDoctor.Items.AddRange(new object[] { "BS. Nguyễn Văn A", "BS. Trần Thị B", "BS. Lê Hoàng C", "BS. Phạm Minh D" });

            this.txtReason.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtReason.Multiline = true;
            this.txtReason.Height = 40;

            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.cboStatus.Items.AddRange(new object[] { "Chờ khám", "Đang khám", "Hoàn tất", "Đã hủy" });

            this.tlpInput.Controls.Add(new Label { Text = "Mã lịch hẹn:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 0);
            this.tlpInput.Controls.Add(this.txtId, 1, 0);
            this.tlpInput.Controls.Add(new Label { Text = "Bác sĩ:", Anchor = AnchorStyles.Left, AutoSize = true }, 2, 0);
            this.tlpInput.Controls.Add(this.cboDoctor, 3, 0);

            this.tlpInput.Controls.Add(new Label { Text = "Họ tên bệnh nhân:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 1);
            this.tlpInput.Controls.Add(this.txtName, 1, 1);
            this.tlpInput.Controls.Add(new Label { Text = "Ngày giờ hẹn:", Anchor = AnchorStyles.Left, AutoSize = true }, 2, 1);
            this.tlpInput.Controls.Add(this.dtpDate, 3, 1);

            this.tlpInput.Controls.Add(new Label { Text = "Số điện thoại:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 2);
            tlpInput.Controls.Add(this.txtPhone, 1, 2);
            this.tlpInput.Controls.Add(new Label { Text = "Trạng thái:", Anchor = AnchorStyles.Left, AutoSize = true }, 2, 2);
            this.tlpInput.Controls.Add(this.cboStatus, 3, 2);

            this.tlpInput.Controls.Add(new Label { Text = "Lý do khám:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 3);
            this.tlpInput.Controls.Add(this.txtReason, 1, 3);
            this.tlpInput.SetColumnSpan(this.txtReason, 3);

            // FlowLayoutPanel Buttons
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.pnlButtons.AutoSize = true;
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);

            this.btnAdd.Text = "Thêm mới"; this.btnAdd.Size = new Size(100, 32);
            this.btnUpdate.Text = "Cập nhật"; this.btnUpdate.Size = new Size(100, 32);
            this.btnDelete.Text = "Xóa"; this.btnDelete.Size = new Size(100, 32);
            this.btnReset.Text = "Làm mới"; this.btnReset.Size = new Size(100, 32);

            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            this.pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] { this.btnAdd, this.btnUpdate, this.btnDelete, this.btnReset });

            Panel pnlInputWrapper = new Panel { Dock = DockStyle.Fill, AutoSize = true };
            pnlInputWrapper.Controls.Add(this.tlpInput);
            pnlInputWrapper.Controls.Add(this.pnlButtons);
            this.grpInput.Controls.Add(pnlInputWrapper);

            // GroupBox Filter
            this.grpFilter.Text = "Tìm Kiếm & Bộ Lọc";
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilter.AutoSize = true;

            this.flpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpFilter.AutoSize = true;
            this.flpFilter.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;

            this.txtSearch.Width = 180;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.chkEnableDateFilter.Text = "Lọc ngày:";
            this.chkEnableDateFilter.AutoSize = true;
            this.chkEnableDateFilter.CheckedChanged += new System.EventHandler(this.chkEnableDateFilter_CheckedChanged);

            this.dtpFilterDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterDate.Width = 120;
            this.dtpFilterDate.Enabled = false;
            this.dtpFilterDate.ValueChanged += new System.EventHandler(this.dtpFilterDate_ValueChanged);

            this.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterStatus.Width = 130;
            this.cboFilterStatus.Items.AddRange(new object[] { "Tất cả trạng thái", "Chờ khám", "Đang khám", "Hoàn tất", "Đã hủy" });
            this.cboFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cboFilterStatus_SelectedIndexChanged);

            this.flpFilter.Controls.Add(new Label { Text = "Tìm (Tên/SĐT):", AutoSize = true, Margin = new Padding(0, 5, 0, 0) });
            this.flpFilter.Controls.Add(this.txtSearch);
            this.flpFilter.Controls.Add(this.chkEnableDateFilter);
            this.flpFilter.Controls.Add(this.dtpFilterDate);
            this.flpFilter.Controls.Add(new Label { Text = "Trạng thái:", AutoSize = true, Margin = new Padding(10, 5, 0, 0) });
            this.flpFilter.Controls.Add(this.cboFilterStatus);
            this.grpFilter.Controls.Add(this.flpFilter);

            // DataGridView
            this.dgvAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAppointments.AutoGenerateColumns = false;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.MultiSelect = false;
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppointments.SelectionChanged += new System.EventHandler(this.dgvAppointments_SelectionChanged);

            // Assembly Layout
            this.mainLayout.Controls.Add(this.grpInput, 0, 0);
            this.mainLayout.Controls.Add(this.grpFilter, 0, 1);
            this.mainLayout.Controls.Add(this.dgvAppointments, 0, 2);

            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.mainLayout);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Text = "Quản Lý Lịch Hẹn Phòng Khám";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.tlpInput.ResumeLayout(false);
            this.tlpInput.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.flpFilter.ResumeLayout(false);
            this.flpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuExportCsv;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusCount;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.TableLayoutPanel tlpInput;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.FlowLayoutPanel flpFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox chkEnableDateFilter;
        private System.Windows.Forms.DateTimePicker dtpFilterDate;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.DataGridView dgvAppointments;
    }
}