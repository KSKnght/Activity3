namespace WindowsFormsApp1.winforms
{
    partial class ReceiptReportForm
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

        private void InitializeComponent()
        {
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // reportViewer1
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 40);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(800, 560);
            this.reportViewer1.TabIndex = 0;

            // pnlButtons
            this.pnlButtons.Controls.Add(this.btnPrint);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Height = 40;

            // btnPrint
            this.btnPrint.Location = new System.Drawing.Point(10, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 25);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            // btnClose
            this.btnClose.Location = new System.Drawing.Point(100, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ReceiptReportForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pnlButtons);
            this.Name = "ReceiptReportForm";
            this.Text = "Transaction Receipt";
            this.Load += new System.EventHandler(this.ReceiptReportForm_Load);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
    }
}