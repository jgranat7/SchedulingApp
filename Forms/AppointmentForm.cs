using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace SchedulingApp.Forms
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCustomer.SelectedItem == null || string.IsNullOrWhiteSpace(txtType.Text))
                {
                    MessageBox.Show("Please select a customer and enter the appointment type.");
                    return;
                }

                DateTime date = dtpDate.Value.Date;
                DateTime start = dtpStartTime.Value;
                DateTime end = dtpEndTime.Value;

                DateTime startDateTime = new DateTime(date.Year, date.Month, date.Day, start.Hour, start.Minute, 0);
                DateTime endDateTime = new DateTime(date.Year, date.Month, date.Day, end.Hour, end.Minute, 0);

                if (endDateTime <= startDateTime)
                {
                    MessageBox.Show("End time must be after start time.");
                    return;
                }

                if (!IsWithinBusinessHours(startDateTime, endDateTime))
                {
                    MessageBox.Show("Appointments must be between 9:00 AM and 5:00 PM EST, Monday through Friday.");
                    return;
                }

                if (HasOverlappingAppointment(startDateTime, endDateTime))
                {
                    MessageBox.Show("This appointment overlaps with an existing one.");
                    return;
                }

                // Later: Insert appointment into database here

                txtType.Clear();
                cbCustomer.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the appointment:\n" + ex.Message);
            }
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            // Later: Load customers from database and bind to cbCustomer

            // Format time pickers to show only hours and minutes (no seconds)
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.CustomFormat = "hh:mm tt";
            dtpStartTime.ShowUpDown = true;

            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.CustomFormat = "hh:mm tt";
            dtpEndTime.ShowUpDown = true;

            // Later: Load appointments from database and bind to dgvAppointments
        }

        private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Later: Populate form fields from selected row if using a database-bound grid
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAppointments.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an appointment to update.");
                    return;
                }

                if (cbCustomer.SelectedItem == null || string.IsNullOrWhiteSpace(txtType.Text))
                {
                    MessageBox.Show("Please select a customer and enter the appointment type.");
                    return;
                }

                DateTime date = dtpDate.Value.Date;
                DateTime start = dtpStartTime.Value;
                DateTime end = dtpEndTime.Value;

                DateTime startDateTime = new DateTime(date.Year, date.Month, date.Day, start.Hour, start.Minute, 0);
                DateTime endDateTime = new DateTime(date.Year, date.Month, date.Day, end.Hour, end.Minute, 0);

                if (endDateTime <= startDateTime)
                {
                    MessageBox.Show("End time must be after start time.");
                    return;
                }

                if (!IsWithinBusinessHours(startDateTime, endDateTime))
                {
                    MessageBox.Show("Appointments must be between 9:00 AM and 5:00 PM EST, Monday through Friday.");
                    return;
                }

                if (HasOverlappingAppointment(startDateTime, endDateTime, dgvAppointments.SelectedRows[0].Index))
                {
                    MessageBox.Show("This appointment overlaps with an existing one.");
                    return;
                }

                // Later: Update appointment in the database here

                MessageBox.Show("Appointment updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the appointment:\n" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to delete.");
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete the selected appointment?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                // Later: Delete appointment from the database here

                MessageBox.Show("Appointment deleted.");
            }
        }

        private bool IsWithinBusinessHours(DateTime start, DateTime end)
        {
            TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            DateTime startEST = TimeZoneInfo.ConvertTime(start, estZone);
            DateTime endEST = TimeZoneInfo.ConvertTime(end, estZone);

            TimeSpan open = new TimeSpan(9, 0, 0);
            TimeSpan close = new TimeSpan(17, 0, 0);

            if (startEST.DayOfWeek == DayOfWeek.Saturday || startEST.DayOfWeek == DayOfWeek.Sunday)
                return false;

            return startEST.TimeOfDay >= open && endEST.TimeOfDay <= close;
        }

        private bool HasOverlappingAppointment(DateTime start, DateTime end, int excludeRowIndex = -1)
        {
            // Placeholder: Replace with actual database check once integrated
            return false;
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            dtpDate.Value = e.Start.Date;
        }
    }
}
