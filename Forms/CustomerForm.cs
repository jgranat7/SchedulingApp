using System;
using System.Windows.Forms;

namespace SchedulingApp.Forms
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            // This method will load customers from the database in the lab environment
            dgvCustomers.Rows.Clear();
            dgvCustomers.Columns.Clear();

            dgvCustomers.Columns.Add("customerId", "Customer ID");
            dgvCustomers.Columns.Add("customerName", "Name");
            dgvCustomers.Columns.Add("address", "Address");
            dgvCustomers.Columns.Add("phone", "Phone");

            // TODO: Load real customer data from DB here
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtCustomerName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("All fields must be filled out.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^[\d\-]+$"))
            {
                MessageBox.Show("Phone number must contain only digits and dashes.");
                return;
            }

            // TODO: Insert into database here
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to update.");
                return;
            }

            string name = txtCustomerName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("All fields must be filled out.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^[\d\-]+$"))
            {
                MessageBox.Show("Phone number must contain only digits and dashes.");
                return;
            }

            // TODO: Update record in the database here
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to delete.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                // TODO: Delete from database here
            }
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCustomers.SelectedRows[0];
                txtCustomerName.Text = row.Cells["customerName"].Value?.ToString() ?? "";
                txtAddress.Text = row.Cells["address"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["phone"].Value?.ToString() ?? "";
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                txtCustomerName.Text = row.Cells["customerName"].Value?.ToString() ?? "";
                txtAddress.Text = row.Cells["address"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["phone"].Value?.ToString() ?? "";
            }
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e) { }
        private void lblCustomerName_Click(object sender, EventArgs e) { }
    }
}
