using System.Drawing;
using System.Windows.Forms;

namespace Bai3_Repair_Service_Tracker
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
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatusCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPendingCost = new System.Windows.Forms.ToolStripStatusLabel();

            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.tlpInputWrapper = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFields = new System.Windows.Forms.TableLayoutPanel();

            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.cboDeviceType = new System.Windows.Forms.ComboBox();
            this.dtpReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.txtEstimatedCost = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtIssueDescription = new System.Windows.Forms.TextBox();

            this.pnlImage = new System.Windows.Forms.Panel();
            this.picDevice = new System.Windows.Forms.PictureBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.btnRemoveImage = new System.Windows.Forms.Button();

            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();

            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.flpFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();

            this.dgvOrders = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.tlpInputWrapper.SuspendLayout();
            this.tlpFields.SuspendLayout();
            this.pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDevice)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.flpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();

            // ErrorProvider
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

            // MenuStrip
            this.menuExportCsv.Text = "Xuất danh sách ra CSV";
            this.menuExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);
            this.menuExit.Text = "Thoát ứng dụng";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            this.menuFile.Text = "Hệ thống";
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuExportCsv, new System.Windows.Forms.ToolStripSeparator(), this.menuExit });
            this.menuStrip.Items.Add(this.menuFile);

            // StatusStrip
            this.lblStatusCount.Text = "Số đơn: 0";
            this.lblPendingCost.Text = " | Tổng chi phí chưa hoàn tất: 0 VNĐ";
            this.lblPendingCost.ForeColor = Color.DarkBlue;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatusCount, this.lblPendingCost });

            // Main Layout
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.RowCount = 3;
            this.mainLayout.Padding = new System.Windows.Forms.Padding(10);
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            // GroupBox Input
            this.grpInput.Text = "Thông Tin Đơn Đăng Ký Sửa Chữa";
            this.grpInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInput.AutoSize = true;

            // TableLayoutPanel Input Wrapper (Chia 2 bên: Trái là Fields, Phải là PictureBox)
            this.tlpInputWrapper.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpInputWrapper.AutoSize = true;
            this.tlpInputWrapper.ColumnCount = 2;
            this.tlpInputWrapper.RowCount = 1;
            this.tlpInputWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpInputWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));

            // TableLayoutPanel Fields
            this.tlpFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFields.AutoSize = true;
            this.tlpFields.ColumnCount = 4;
            this.tlpFields.RowCount = 5;
            this.tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

            this.txtOrderId.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtCustomerName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.cboDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeviceType.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.cboDeviceType.Items.AddRange(new object[] { "Điện thoại", "Laptop", "Máy tính bảng", "Máy tính để bàn (PC)", "Thiết bị khác" });

            this.dtpReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReceivedDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.txtEstimatedCost.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtEstimatedCost.Text = "0";

            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.cboStatus.Items.AddRange(new object[] { "Mới tiếp nhận", "Đang sửa", "Chờ linh kiện", "Hoàn tất", "Đã hủy" });

            this.txtIssueDescription.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtIssueDescription.Multiline = true;
            this.txtIssueDescription.Height = 45;

            // Add Controls into tlpFields
            this.tlpFields.Controls.Add(new Label { Text = "Mã đơn:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 0);
            this.tlpFields.Controls.Add(this.txtOrderId, 1, 0);
            this.tlpFields.Controls.Add(new Label { Text = "Loại thiết bị:", Anchor = AnchorStyles.Left, AutoSize = true }, 2, 0);
            this.tlpFields.Controls.Add(this.cboDeviceType, 3, 0);

            this.tlpFields.Controls.Add(new Label { Text = "Khách hàng:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 1);
            this.tlpFields.Controls.Add(this.txtCustomerName, 1, 1);
            this.tlpFields.Controls.Add(new Label { Text = "Ngày tiếp nhận:", Anchor = AnchorStyles.Left, AutoSize = true }, 2, 1);
            this.tlpFields.Controls.Add(this.dtpReceivedDate, 3, 1);

            this.tlpFields.Controls.Add(new Label { Text = "Số điện thoại:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 2);
            this.tlpFields.Controls.Add(this.txtPhone, 1, 2);
            this.tlpFields.Controls.Add(new Label { Text = "Chi phí dự kiến:", Anchor = AnchorStyles.Left, AutoSize = true }, 2, 2);
            this.tlpFields.Controls.Add(this.txtEstimatedCost, 3, 2);

            this.tlpFields.Controls.Add(new Label { Text = "Trạng thái:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 3);
            this.tlpFields.Controls.Add(this.cboStatus, 1, 3);

            this.tlpFields.Controls.Add(new Label { Text = "Mô tả lỗi:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 4);
            this.tlpFields.Controls.Add(this.txtIssueDescription, 1, 4);
            this.tlpFields.SetColumnSpan(this.txtIssueDescription, 3);

            // Panel Image & PictureBox
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImage.Padding = new System.Windows.Forms.Padding(5);

            this.picDevice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDevice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; // Đúng tỷ lệ không méo
            this.picDevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.picDevice.Height = 110;

            this.btnBrowseImage.Text = "Chọn ảnh";
            this.btnBrowseImage.Size = new Size(80, 28);
            this.btnBrowseImage.Location = new Point(5, 120);
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);

            this.btnRemoveImage.Text = "Xóa ảnh";
            this.btnRemoveImage.Size = new Size(75, 28);
            this.btnRemoveImage.Location = new Point(90, 120);
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);

            this.pnlImage.Controls.Add(this.picDevice);
            this.pnlImage.Controls.Add(this.btnBrowseImage);
            this.pnlImage.Controls.Add(this.btnRemoveImage);

            this.tlpInputWrapper.Controls.Add(this.tlpFields, 0, 0);
            this.tlpInputWrapper.Controls.Add(this.pnlImage, 1, 0);

            // FlowLayoutPanel Buttons
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.pnlButtons.AutoSize = true;
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);

            this.btnAdd.Text = "Thêm đơn"; this.btnAdd.Size = new Size(100, 32);
            this.btnUpdate.Text = "Cập nhật"; this.btnUpdate.Size = new Size(100, 32);
            this.btnDelete.Text = "Xóa đơn"; this.btnDelete.Size = new Size(100, 32);
            this.btnReset.Text = "Làm mới"; this.btnReset.Size = new Size(100, 32);

            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            this.pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAdd, this.btnUpdate, this.btnDelete, this.btnReset
            });

            Panel pnlInput = new Panel { Dock = DockStyle.Fill, AutoSize = true };
            pnlInput.Controls.Add(this.tlpInputWrapper);
            pnlInput.Controls.Add(this.pnlButtons);
            this.grpInput.Controls.Add(pnlInput);

            // GroupBox Filter
            this.grpFilter.Text = "Tìm Kiếm & Bộ Lọc";
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilter.AutoSize = true;

            this.flpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpFilter.AutoSize = true;
            this.flpFilter.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;

            this.txtSearch.Width = 220;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterStatus.Width = 140;
            this.cboFilterStatus.Items.AddRange(new object[] { "Tất cả trạng thái", "Mới tiếp nhận", "Đang sửa", "Chờ linh kiện", "Hoàn tất", "Đã hủy" });
            this.cboFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cboFilterStatus_SelectedIndexChanged);

            this.flpFilter.Controls.Add(new Label { Text = "Tìm (Mã/Tên KH/SĐT):", AutoSize = true, Margin = new Padding(0, 5, 0, 0) });
            this.flpFilter.Controls.Add(this.txtSearch);
            this.flpFilter.Controls.Add(new Label { Text = "Trạng thái:", AutoSize = true, Margin = new Padding(15, 5, 0, 0) });
            this.flpFilter.Controls.Add(this.cboFilterStatus);
            this.grpFilter.Controls.Add(this.flpFilter);

            // DataGridView
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.AutoGenerateColumns = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);

            // Assembly Layout
            this.mainLayout.Controls.Add(this.grpInput, 0, 0);
            this.mainLayout.Controls.Add(this.grpFilter, 0, 1);
            this.mainLayout.Controls.Add(this.dgvOrders, 0, 2);

            this.ClientSize = new System.Drawing.Size(1150, 720);
            this.MinimumSize = new System.Drawing.Size(1000, 620);
            this.Controls.Add(this.mainLayout);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Text = "Quản Lý Đơn Đăng Ký Dịch Vụ Sửa Chữa (Repair Service Tracker)";
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
            this.tlpInputWrapper.ResumeLayout(false);
            this.tlpInputWrapper.PerformLayout();
            this.tlpFields.ResumeLayout(false);
            this.tlpFields.PerformLayout();
            this.pnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDevice)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.flpFilter.ResumeLayout(false);
            this.flpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuExportCsv;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusCount;
        private System.Windows.Forms.ToolStripStatusLabel lblPendingCost;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.TableLayoutPanel tlpInputWrapper;
        private System.Windows.Forms.TableLayoutPanel tlpFields;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.ComboBox cboDeviceType;
        private System.Windows.Forms.DateTimePicker dtpReceivedDate;
        private System.Windows.Forms.TextBox txtEstimatedCost;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.TextBox txtIssueDescription;
        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.PictureBox picDevice;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Button btnRemoveImage;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.FlowLayoutPanel flpFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.DataGridView dgvOrders;
    }
}