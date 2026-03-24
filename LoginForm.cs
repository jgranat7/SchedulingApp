using SchedulingApp.Forms;
using System;
using System.IO;
using System.Windows.Forms;

namespace SchedulingApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // Optional: Add password validation if needed
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // TODO: Replace with real login validation logic using database
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Assume login success for now — replace this section with real authentication
            LogLogin(username);

            // TODO: In lab environment, check for appointments in next 15 minutes using the database
            // ShowAlertIfAppointmentUpcoming(username);

            // Open main menu
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
            this.Hide();
        }

        private void LogLogin(string username)
        {
            string logEntry = $"{DateTime.Now:u} - {username} logged in";
            string logFilePath = "Login_History.txt";

            try
            {
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing to login history file: " + ex.Message);
            }
        }
    }
}
