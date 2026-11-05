using System.Drawing;
using System.Windows.Forms;

namespace  Bai2_Lab_Equipment_Checkout
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
            this.lblOverdueCount = new System.Windows.Forms.ToolStripStatusLabel();

            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.tlpInput = new System.Windows.Forms.TableLayoutPanel();

            this.txtSlipId = new System.Windows.Forms.TextBox();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.cboEquipment = new System.Windows.Forms.ComboBox();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.dtpBorrowDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.chkReturned = new System.Windows.Forms.CheckBox();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.cboStatus = new System.Windows.Forms.ComboBox();

            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnMarkReturned = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();

            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.flpFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();

            this.dgvSlips = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.tlpInput.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.flpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlips)).BeginInit();
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
            this.lblStatusCount.Text = "Tổng số phiếu: 0";
            this.lblOverdueCount.Text = " | Quá hạn: 0";
            this.lblOverdueCount.ForeColor = Color.Red;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatusCount, this.lblOverdueCount });

            // Main Layout (3 dòng: Nhập liệu -> Bộ lọc -> Danh sách)
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.RowCount = 3;
            this.mainLayout.Padding = new System.Windows.Forms.Padding(10);
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            // GroupBox Input
            this.grpInput.Text = "Thông Tin Phiếu Mượn Thiết Bị";
            this.grpInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInput.AutoSize = true;

            // TableLayoutPanel Input (4 Cột)
            this.tlpInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpInput.AutoSize = true;
            this.tlpInput.ColumnCount = 4;
            this.tlpInput.RowCount = 5;
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

            this.txtSlipId.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtStudentId.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtStudentName.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.cboEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquipment.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.cboEquipment.Items.AddRange(new object[] { "Oscilloscope Tektronix", "Bộ thực hành Vi xử lý STM32", "Máy phát hàm Rigol", "Đồng hồ đo VOM Fluke", "Cảm biến Arduino Kit", "Máy tính xách tay Dell Lab" });

            this.nudQuantity.Minimum = 1;
            this.nudQuantity.Maximum = 100;
            this.nudQuantity.Value = 1;
            this.nudQuantity.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.dtpBorrowDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBorrowDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.chkReturned.Text = "Đã trả thực tế:";
            this.chkReturned.AutoSize = true;
            this.chkReturned.Anchor = AnchorStyles.Left;
            this.chkReturned.CheckedChanged += new System.EventHandler(this.chkReturned_CheckedChanged);

            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReturnDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.dtpReturnDate.Enabled = false;

            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.cboStatus.Items.AddRange(new object[] { "Đang mượn", "Đã trả", "Quá hạn" });
            this.cboStatus.Enabled = false; // Tự động cập nhật dựa theo ngày/tình trạng trả

            // Add controls to TableLayoutPanel Input
            this.tlpInput.Controls.Add(new Label { Text = "Mã phiếu:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 0);
            this.tlpInput.Controls.Add(this.txtSlipId, 1, 0);
            this.tlpInput.Controls.Add(new Label { Text = "Thiết bị:", Anchor = AnchorStyles.Left, AutoSize = true }, 2, 0);
            this.tlpInput.Controls.Add(this.cboEquipment, 3, 0);

            this.tlpInput.Controls.Add(new Label { Text = "Mã sinh viên:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 1);
            this.tlpInput.Controls.Add(this.txtStudentId, 1, 1);
            this.tlpInput.Controls.Add(new Label { Text = "Số lượng:", Anchor = AnchorStyles.Left, AutoSize = true }, 2, 1);
            this.tlpInput.Controls.Add(this.nudQuantity, 3, 1);

            this.tlpInput.Controls.Add(new Label { Text = "Họ tên sinh viên:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 2);
            this.tlpInput.Controls.Add(this.txtStudentName, 1, 2);
            this.tlpInput.Controls.Add(new Label { Text = "Ngày mượn:", Anchor = AnchorStyles.Left, AutoSize = true }, 2, 2);
            this.tlpInput.Controls.Add(this.dtpBorrowDate, 3, 2);

            this.tlpInput.Controls.Add(new Label { Text = "Hạn trả:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 3);
            this.tlpInput.Controls.Add(this.dtpDueDate, 1, 3);
            this.tlpInput.Controls.Add(new Label { Text = "Trạng thái:", Anchor = AnchorStyles.Left, AutoSize = true }, 2, 3);
            this.tlpInput.Controls.Add(this.cboStatus, 3, 3);

            this.tlpInput.Controls.Add(this.chkReturned, 0, 4);
            this.tlpInput.Controls.Add(this.dtpReturnDate, 1, 4);

            // FlowLayoutPanel Buttons
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.pnlButtons.AutoSize = true;
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);

            this.btnAdd.Text = "Tạo phiếu"; this.btnAdd.Size = new Size(110, 32);
            this.btnUpdate.Text = "Cập nhật"; this.btnUpdate.Size = new Size(100, 32);
            this.btnMarkReturned.Text = "Xác nhận trả"; this.btnMarkReturned.Size = new Size(120, 32);
            this.btnDelete.Text = "Xóa phiếu"; this.btnDelete.Size = new Size(100, 32);
            this.btnReset.Text = "Làm mới"; this.btnReset.Size = new Size(100, 32);

            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnMarkReturned.Click += new System.EventHandler(this.btnMarkReturned_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            this.pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAdd, this.btnUpdate, this.btnMarkReturned, this.btnDelete, this.btnReset
            });

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

            this.txtSearch.Width = 200;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterStatus.Width = 140;
            this.cboFilterStatus.Items.AddRange(new object[] { "Tất cả trạng thái", "Đang mượn", "Quá hạn", "Đã trả" });
            this.cboFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cboFilterStatus_SelectedIndexChanged);

            this.flpFilter.Controls.Add(new Label { Text = "Tìm (Mã SV/Thiết bị):", AutoSize = true, Margin = new Padding(0, 5, 0, 0) });
            this.flpFilter.Controls.Add(this.txtSearch);
            this.flpFilter.Controls.Add(new Label { Text = "Lọc trạng thái:", AutoSize = true, Margin = new Padding(15, 5, 0, 0) });
            this.flpFilter.Controls.Add(this.cboFilterStatus);
            this.grpFilter.Controls.Add(this.flpFilter);

            // DataGridView
            this.dgvSlips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSlips.AutoGenerateColumns = false;
            this.dgvSlips.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSlips.MultiSelect = false;
            this.dgvSlips.AllowUserToAddRows = false;
            this.dgvSlips.ReadOnly = true;
            this.dgvSlips.BackgroundColor = System.Drawing.Color.White;
            this.dgvSlips.SelectionChanged += new System.EventHandler(this.dgvSlips_SelectionChanged);

            // Assembly Layout
            this.mainLayout.Controls.Add(this.grpInput, 0, 0);
            this.mainLayout.Controls.Add(this.grpFilter, 0, 1);
            this.mainLayout.Controls.Add(this.dgvSlips, 0, 2);

            this.ClientSize = new System.Drawing.Size(1150, 720);
            this.MinimumSize = new System.Drawing.Size(1000, 620);
            this.Controls.Add(this.mainLayout);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Text = "Quản Lý Mượn Trả Thiết Bị Phòng Thực Hành (Lab Equipment Checkout)";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlips)).EndInit();
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
        private System.Windows.Forms.ToolStripStatusLabel lblOverdueCount;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.TableLayoutPanel tlpInput;
        private System.Windows.Forms.TextBox txtSlipId;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.ComboBox cboEquipment;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.DateTimePicker dtpBorrowDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.CheckBox chkReturned;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnMarkReturned;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.FlowLayoutPanel flpFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.DataGridView dgvSlips;
    }
}