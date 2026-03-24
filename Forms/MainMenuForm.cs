using System;
using System.Windows.Forms;

namespace SchedulingApp.Forms
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            var customerForm = new CustomerForm();
            customerForm.ShowDialog(); // Keeps UI flow consistent
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            var appointmentForm = new AppointmentForm();
            appointmentForm.ShowDialog(); // Keeps control until form closes
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var reportsForm = new ReportsForm();
            reportsForm.ShowDialog();
        }
    }
}
