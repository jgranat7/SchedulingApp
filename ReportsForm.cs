using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SchedulingApp
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            cbReportType.SelectedIndex = 0; // Set default selection
            btnGenerate.Click += BtnGenerate_Click;
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            // Placeholder for any future load-time logic
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (cbReportType.SelectedItem == null)
            {
                MessageBox.Show("Please select a report type.");
                return;
            }

            string selectedReport = cbReportType.SelectedItem.ToString();

            if (selectedReport == "Appointments by Month")
            {
                GenerateAppointmentsByMonthReport();
            }

            // Later: Add logic for "Schedule by User" and "Custom Report"
        }

        private void GenerateAppointmentsByMonthReport()
        {
            dgvReportResults.Columns.Clear();
            dgvReportResults.Rows.Clear();

            // TODO: Replace with real database query to retrieve appointments
            // Each appointment should include a Date and Type field
            List<(string Type, DateTime Date)> appointments = new List<(string, DateTime)>();

            // Example only — replace with real query logic in Part B
            // appointments = GetAppointmentsFromDatabase();

            if (appointments.Count == 0)
            {
                MessageBox.Show("No appointment data available.");
                return;
            }

            var grouped = appointments
                .GroupBy(a => new { Month = a.Date.ToString("MMMM"), a.Type })
                .Select(g => new
                {
                    g.Key.Month,
                    g.Key.Type,
                    Count = g.Count()
                })
                .ToList();

            dgvReportResults.Columns.Add("Month", "Month");
            dgvReportResults.Columns.Add("Type", "Appointment Type");
            dgvReportResults.Columns.Add("Count", "Count");

            foreach (var item in grouped)
            {
                dgvReportResults.Rows.Add(item.Month, item.Type, item.Count);
            }
        }
    }
}
