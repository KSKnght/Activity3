using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.DTOs;

namespace WindowsFormsApp1.winforms
{
    public partial class AllOrdersReportForm : Form
    {
        public AllOrdersReportForm()
        {
            InitializeComponent();
        }

        private void AllOrdersReportForm_Load(object sender, EventArgs e)
        {
            LoadAllOrdersReport();
        }

        private void LoadAllOrdersReport()
        {
            try
            {
                string reportPath = System.IO.Path.Combine(Application.StartupPath, "Reports", "AllOrdersReport.rdlc");
                
                // Debug: Check if file exists
                if (!System.IO.File.Exists(reportPath))
                {
                    MessageBox.Show($"Report file not found at: {reportPath}\n\nMake sure the Reports folder with RDLC files is in:\n{Application.StartupPath}", 
                        "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DatabaseHelper dbHelper = new DatabaseHelper();
                List<OrderDTO> ordersData = dbHelper.GetAllOrdersForReportDTO();

                if (ordersData.Count == 0)
                {
                    MessageBox.Show("No orders found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Calculate grand total
                decimal grandTotal = 0;
                foreach (OrderDTO order in ordersData)
                {
                    grandTotal += order.TotalAmount;
                }

                // IMPORTANT: Set report path FIRST before binding data
                reportViewer1.LocalReport.ReportPath = reportPath;
                
                // Clear and bind data sources
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("AllOrdersDataSet", ordersData));
                
                // Set parameters AFTER report is loaded but BEFORE refresh
                ReportParameter[] parameters = new ReportParameter[1];
                parameters[0] = new ReportParameter("GrandTotal", grandTotal.ToString("C2"));
                reportViewer1.LocalReport.SetParameters(parameters);

                // Finally refresh the report
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders report: {ex.Message}\n\nStack Trace: {ex.StackTrace}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllOrdersReport();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files|*.pdf|Excel Files|*.xlsx";
                saveFileDialog.DefaultExt = ".pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string deviceInfo = "<DeviceInfo><OutputFormat>PDF</OutputFormat></DeviceInfo>";
                    string mimeType, encoding, fileNameExtension;
                    string[] streams;
                    Warning[] warnings;

                    byte[] renderedBytes = reportViewer1.LocalReport.Render(
                        "PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        fs.Write(renderedBytes, 0, renderedBytes.Length);
                    }

                    MessageBox.Show("Report exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
