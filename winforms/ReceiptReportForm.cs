using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1.winforms
{
    public partial class ReceiptReportForm : Form
    {
        private int _orderId;
        private string _cashierName;

        public ReceiptReportForm(int orderId, string cashierName = "")
        {
            InitializeComponent();
            _orderId = orderId;
            _cashierName = cashierName;
        }

        private void ReceiptReportForm_Load(object sender, EventArgs e)
        {
            LoadReceiptReport();
        }

        private void LoadReceiptReport()
        {
            try
            {
                string reportPath = System.IO.Path.Combine(Application.StartupPath, "Reports", "ReceiptReport.rdlc");
                
                if (!System.IO.File.Exists(reportPath))
                {
                    MessageBox.Show($"Report file not found at: {reportPath}", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                DatabaseHelper dbHelper = new DatabaseHelper();
                Order order = dbHelper.GetOrderWithItems(_orderId);

                Console.WriteLine($"Loaded order with ID: {_orderId}, TotalAmount: {order?.TotalAmount}, Items count: {order?.OrderItems?.Count}");

                if (order == null)
                {
                    MessageBox.Show("Order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Create DataTables for order and order items
                DataTable orderTable = new DataTable("Order");
                orderTable.Columns.Add("OrderId", typeof(int));
                orderTable.Columns.Add("TotalAmount", typeof(decimal));
                orderTable.Columns.Add("AmountTendered", typeof(decimal));
                orderTable.Columns.Add("Change", typeof(decimal));
                orderTable.Columns.Add("TransactionDate", typeof(string));
                orderTable.Columns.Add("CashierName", typeof(string));

                DataRow orderRow = orderTable.NewRow();
                orderRow["OrderId"] = order.Id;
                orderRow["TotalAmount"] = order.TotalAmount;
                orderRow["AmountTendered"] = order.AmountTendered;
                orderRow["Change"] = order.Change;
                orderRow["TransactionDate"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                orderRow["CashierName"] = _cashierName;
                orderTable.Rows.Add(orderRow);

                // Create order items DataTable
                DataTable orderItemsTable = new DataTable("OrderItem");
                orderItemsTable.Columns.Add("ProductName", typeof(string));
                orderItemsTable.Columns.Add("Quantity", typeof(int));
                orderItemsTable.Columns.Add("UnitPrice", typeof(decimal));
                orderItemsTable.Columns.Add("TotalPrice", typeof(decimal));

                foreach (var item in order.OrderItems)
                {
                    DataRow itemRow = orderItemsTable.NewRow();
                    itemRow["ProductName"] = !string.IsNullOrEmpty(item.ProductName) ? item.ProductName : "N/A";
                    itemRow["Quantity"] = item.Quantity;
                    itemRow["UnitPrice"] = item.UnitPrice;
                    itemRow["TotalPrice"] = item.Quantity * item.UnitPrice;
                    orderItemsTable.Rows.Add(itemRow);
                }

                // IMPORTANT: Set report path FIRST
                reportViewer1.LocalReport.ReportPath = reportPath;
                
                // Set report parameters - pass User parameter
                reportViewer1.LocalReport.SetParameters(new ReportParameter("User", _cashierName));
                
                // Then bind data sources
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("OrderDataSet", orderTable));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("OrderItemDataSet", orderItemsTable));
                
                // Finally refresh
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading receipt report: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            reportViewer1.PrintDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
