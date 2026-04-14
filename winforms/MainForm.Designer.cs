namespace WindowsFormsApp1.winforms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pHeader = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fpTabs = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.pContent = new System.Windows.Forms.Panel();
            this.pnlTransaction = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNewTransaction = new System.Windows.Forms.Button();
            this.btnAddTransaction = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.ProductPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlUserProducts = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.tabProducts = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabUsers = new System.Windows.Forms.Panel();
            this.flowLayoutPanelUsers = new System.Windows.Forms.FlowLayoutPanel();
            this.panelActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.pnlReports = new System.Windows.Forms.Panel();
            this.lblReportsTitle = new System.Windows.Forms.Label();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.pHeader.SuspendLayout();
            this.fpTabs.SuspendLayout();
            this.pContent.SuspendLayout();
            this.pnlTransaction.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.pnlUserProducts.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.tabProducts.SuspendLayout();
            this.tabUsers.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.pnlReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.lblUsername);
            this.pHeader.Controls.Add(this.btnLogOut);
            this.pHeader.Controls.Add(this.label1);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Padding = new System.Windows.Forms.Padding(9);
            this.pHeader.Size = new System.Drawing.Size(1023, 60);
            this.pHeader.TabIndex = 0;
            // 
            // lblUsername
            // 
            this.lblUsername.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUsername.Location = new System.Drawing.Point(723, 9);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Padding = new System.Windows.Forms.Padding(10);
            this.lblUsername.Size = new System.Drawing.Size(177, 42);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "User";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnLogOut.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLogOut.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogOut.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogOut.Location = new System.Drawing.Point(900, 9);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Padding = new System.Windows.Forms.Padding(9);
            this.btnLogOut.Size = new System.Drawing.Size(114, 42);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "StarBuko";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fpTabs
            // 
            this.fpTabs.Controls.Add(this.btnTransaction);
            this.fpTabs.Controls.Add(this.btnUsers);
            this.fpTabs.Controls.Add(this.btnProducts);
            this.fpTabs.Controls.Add(this.btnReports);
            this.fpTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.fpTabs.Location = new System.Drawing.Point(0, 60);
            this.fpTabs.Name = "fpTabs";
            this.fpTabs.Padding = new System.Windows.Forms.Padding(5);
            this.fpTabs.Size = new System.Drawing.Size(1023, 53);
            this.fpTabs.TabIndex = 1;
            // 
            // btnTransaction
            // 
            this.btnTransaction.AutoSize = true;
            this.btnTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.btnTransaction.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTransaction.FlatAppearance.BorderSize = 0;
            this.btnTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnTransaction.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTransaction.Location = new System.Drawing.Point(8, 8);
            this.btnTransaction.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(114, 43);
            this.btnTransaction.TabIndex = 1;
            this.btnTransaction.Text = "Transaction";
            this.btnTransaction.UseVisualStyleBackColor = false;
            // 
            // btnUsers
            // 
            this.btnUsers.AutoSize = true;
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.btnUsers.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnUsers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUsers.Location = new System.Drawing.Point(122, 8);
            this.btnUsers.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(114, 43);
            this.btnUsers.TabIndex = 2;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = false;
            // 
            // btnProducts
            // 
            this.btnProducts.AutoSize = true;
            this.btnProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.btnProducts.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnProducts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnProducts.Location = new System.Drawing.Point(236, 8);
            this.btnProducts.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(114, 43);
            this.btnProducts.TabIndex = 3;
            this.btnProducts.Text = "Products";
            this.btnProducts.UseVisualStyleBackColor = false;
            // 
            // btnReports
            // 
            this.btnReports.AutoSize = true;
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReports.Location = new System.Drawing.Point(350, 8);
            this.btnReports.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(114, 43);
            this.btnReports.TabIndex = 4;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            // 
            // pContent
            // 
            this.pContent.Controls.Add(this.pnlTransaction);
            this.pContent.Controls.Add(this.pnlUserProducts);
            this.pContent.Controls.Add(this.pnlReports);
            this.pContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pContent.Location = new System.Drawing.Point(0, 113);
            this.pContent.Name = "pContent";
            this.pContent.Padding = new System.Windows.Forms.Padding(5);
            this.pContent.Size = new System.Drawing.Size(1023, 526);
            this.pContent.TabIndex = 2;
            // 
            // pnlTransaction
            // 
            this.pnlTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            this.pnlTransaction.Controls.Add(this.panel1);
            this.pnlTransaction.Controls.Add(this.panelLeft);
            this.pnlTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTransaction.Location = new System.Drawing.Point(5, 5);
            this.pnlTransaction.Name = "pnlTransaction";
            this.pnlTransaction.Size = new System.Drawing.Size(1013, 516);
            this.pnlTransaction.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(509, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 516);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            this.panel3.Controls.Add(this.dgvOrders);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(20);
            this.panel3.Size = new System.Drawing.Size(504, 516);
            this.panel3.TabIndex = 1;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToResizeColumns = false;
            this.dgvOrders.AllowUserToResizeRows = false;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            this.dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("JetBrainsMono NF Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.Qty,
            this.Price,
            this.TotalPrice});
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.EnableHeadersVisualStyles = false;
            this.dgvOrders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            this.dgvOrders.Location = new System.Drawing.Point(20, 68);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("JetBrainsMono NF", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgvOrders.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvOrders.RowTemplate.ReadOnly = true;
            this.dgvOrders.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvOrders.Size = new System.Drawing.Size(464, 328);
            this.dgvOrders.TabIndex = 0;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("JetBrainsMono NF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Orange;
            this.ProductName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Qty
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Orange;
            this.Qty.DefaultCellStyle = dataGridViewCellStyle3;
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Qty.Width = 45;
            // 
            // Price
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Orange;
            this.Price.DefaultCellStyle = dataGridViewCellStyle4;
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TotalPrice
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Orange;
            this.TotalPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.TotalPrice.HeaderText = "Total";
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            this.TotalPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(20, 20);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.panel4.Size = new System.Drawing.Size(464, 48);
            this.panel4.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnNewTransaction, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAddTransaction, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(464, 41);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnNewTransaction
            // 
            this.btnNewTransaction.AutoSize = true;
            this.btnNewTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.btnNewTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewTransaction.FlatAppearance.BorderSize = 0;
            this.btnNewTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewTransaction.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNewTransaction.Location = new System.Drawing.Point(232, 0);
            this.btnNewTransaction.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewTransaction.Name = "btnNewTransaction";
            this.btnNewTransaction.Padding = new System.Windows.Forms.Padding(5);
            this.btnNewTransaction.Size = new System.Drawing.Size(232, 41);
            this.btnNewTransaction.TabIndex = 1;
            this.btnNewTransaction.Text = "New Transaction";
            this.btnNewTransaction.UseVisualStyleBackColor = false;
            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.AutoSize = true;
            this.btnAddTransaction.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAddTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddTransaction.FlatAppearance.BorderSize = 0;
            this.btnAddTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTransaction.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddTransaction.Location = new System.Drawing.Point(0, 0);
            this.btnAddTransaction.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Padding = new System.Windows.Forms.Padding(5);
            this.btnAddTransaction.Size = new System.Drawing.Size(232, 41);
            this.btnAddTransaction.TabIndex = 2;
            this.btnAddTransaction.Text = "Add Transaction";
            this.btnAddTransaction.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 396);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(464, 100);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Amount";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 33);
            this.label3.TabIndex = 1;
            this.label3.Text = "Amount Tendered";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(3, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 34);
            this.label4.TabIndex = 2;
            this.label4.Text = "Change";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(235, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(226, 32);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkOrange;
            this.label6.Location = new System.Drawing.Point(235, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 34);
            this.label6.TabIndex = 5;
            this.label6.Text = "$0.00";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(235, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 33);
            this.label5.TabIndex = 4;
            this.label5.Text = "$0.00";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            this.panelLeft.Controls.Add(this.ProductPanel);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(5);
            this.panelLeft.Size = new System.Drawing.Size(509, 516);
            this.panelLeft.TabIndex = 0;
            // 
            // ProductPanel
            // 
            this.ProductPanel.AutoScroll = true;
            this.ProductPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductPanel.Location = new System.Drawing.Point(5, 5);
            this.ProductPanel.Name = "ProductPanel";
            this.ProductPanel.Size = new System.Drawing.Size(499, 506);
            this.ProductPanel.TabIndex = 0;
            // 
            // pnlUserProducts
            // 
            this.pnlUserProducts.Controls.Add(this.panelContent);
            this.pnlUserProducts.Controls.Add(this.panelActions);
            this.pnlUserProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserProducts.Location = new System.Drawing.Point(5, 5);
            this.pnlUserProducts.Name = "pnlUserProducts";
            this.pnlUserProducts.Size = new System.Drawing.Size(1013, 516);
            this.pnlUserProducts.TabIndex = 6;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.tabProducts);
            this.panelContent.Controls.Add(this.tabUsers);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1013, 456);
            this.panelContent.TabIndex = 3;
            // 
            // tabProducts
            // 
            this.tabProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            this.tabProducts.Controls.Add(this.flowLayoutPanel1);
            this.tabProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProducts.Location = new System.Drawing.Point(0, 0);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(5);
            this.tabProducts.Size = new System.Drawing.Size(1013, 456);
            this.tabProducts.TabIndex = 1;
            this.tabProducts.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1003, 446);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tabUsers
            // 
            this.tabUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            this.tabUsers.Controls.Add(this.flowLayoutPanelUsers);
            this.tabUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUsers.Location = new System.Drawing.Point(0, 0);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(5);
            this.tabUsers.Size = new System.Drawing.Size(1013, 456);
            this.tabUsers.TabIndex = 0;
            // 
            // flowLayoutPanelUsers
            // 
            this.flowLayoutPanelUsers.AutoScroll = true;
            this.flowLayoutPanelUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            this.flowLayoutPanelUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelUsers.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanelUsers.Name = "flowLayoutPanelUsers";
            this.flowLayoutPanelUsers.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanelUsers.Size = new System.Drawing.Size(1003, 446);
            this.flowLayoutPanelUsers.TabIndex = 0;
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            this.panelActions.Controls.Add(this.btnAddUser);
            this.panelActions.Controls.Add(this.btnAddProduct);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActions.Location = new System.Drawing.Point(0, 456);
            this.panelActions.Name = "panelActions";
            this.panelActions.Padding = new System.Windows.Forms.Padding(10);
            this.panelActions.Size = new System.Drawing.Size(1013, 60);
            this.panelActions.TabIndex = 4;
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.btnAddUser.FlatAppearance.BorderSize = 0;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddUser.Location = new System.Drawing.Point(13, 13);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(120, 35);
            this.btnAddUser.TabIndex = 0;
            this.btnAddUser.Text = "+ Add User";
            this.btnAddUser.UseVisualStyleBackColor = false;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.btnAddProduct.FlatAppearance.BorderSize = 0;
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddProduct.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddProduct.Location = new System.Drawing.Point(139, 13);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(140, 35);
            this.btnAddProduct.TabIndex = 1;
            this.btnAddProduct.Text = "+ Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Visible = false;
            // 
            // pnlReports
            // 
            this.pnlReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            this.pnlReports.Controls.Add(this.lblReportsTitle);
            this.pnlReports.Controls.Add(this.btnGenerateReport);
            this.pnlReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReports.Location = new System.Drawing.Point(5, 5);
            this.pnlReports.Name = "pnlReports";
            this.pnlReports.Size = new System.Drawing.Size(1013, 516);
            this.pnlReports.TabIndex = 8;
            this.pnlReports.Visible = false;
            // 
            // lblReportsTitle
            // 
            this.lblReportsTitle.AutoSize = true;
            this.lblReportsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblReportsTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblReportsTitle.Location = new System.Drawing.Point(20, 20);
            this.lblReportsTitle.Name = "lblReportsTitle";
            this.lblReportsTitle.Size = new System.Drawing.Size(200, 26);
            this.lblReportsTitle.TabIndex = 0;
            this.lblReportsTitle.Text = "Generate Reports";
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.btnGenerateReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnGenerateReport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGenerateReport.Location = new System.Drawing.Point(20, 70);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(250, 50);
            this.btnGenerateReport.TabIndex = 0;
            this.btnGenerateReport.Text = "All Orders Report";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.BtnGenerateReport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(53)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(1023, 639);
            this.Controls.Add(this.pContent);
            this.Controls.Add(this.fpTabs);
            this.Controls.Add(this.pHeader);
            this.Name = "MainForm";
            this.Text = "MainFormcs";
            this.pHeader.ResumeLayout(false);
            this.fpTabs.ResumeLayout(false);
            this.fpTabs.PerformLayout();
            this.pContent.ResumeLayout(false);
            this.pnlTransaction.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.pnlUserProducts.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.tabProducts.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            this.panelActions.ResumeLayout(false);
            this.pnlReports.ResumeLayout(false);
            this.pnlReports.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel fpTabs;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel pContent;
        private System.Windows.Forms.Panel pnlUserProducts;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel tabProducts;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel tabUsers;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelUsers;
        private System.Windows.Forms.FlowLayoutPanel panelActions;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Panel pnlTransaction;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnNewTransaction;
        private System.Windows.Forms.Button btnAddTransaction;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.FlowLayoutPanel ProductPanel;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Panel pnlReports;
        private System.Windows.Forms.Label lblReportsTitle;
        private System.Windows.Forms.Button btnGenerateReport;
    }
}