using System;
using System.Windows.Forms;
using BankApp.Services; // Assuming your services are in this namespace
using BankApp.Models;   // Assuming your models are in this namespace

namespace BankApp
{
    public partial class CreateAccountForm : Form
    {
        private readonly AccountService _accountService;

        // Constructor: accept the logged-in user and initialize AccountService
        public CreateAccountForm()
        {
            InitializeComponent();
            _accountService = new AccountService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string accountName = txtAccountName.Text;
            decimal balance;

            // Validate balance input
            if (decimal.TryParse(txtInitialBalance.Text, out balance))
            {
                // Call the AccountService to create the account
                var account = _accountService.CreateAccount(UserSession.CurrentUser.UserId, accountName, balance);

                if (account != null)
                {
                    MessageBox.Show($"Account '{accountName}' created successfully with a balance of ${balance}.");
                    this.Close(); // Close the form after successful creation
                }
                else
                {
                    MessageBox.Show("Error creating account.");
                }
            }
            else
            {
                MessageBox.Show("Invalid balance amount.");
            }
        }

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {
            if (UserSession.CurrentUser != null)
            {
                txtUserId.Text = UserSession.CurrentUser.UserId.ToString();
                txtUserId.ReadOnly = true; // Optional: make it non-editable
            }
            
        }
    }
}
