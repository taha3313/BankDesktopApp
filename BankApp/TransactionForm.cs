using BankApp.Models;
using BankApp.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BankApp
{
    public partial class TransactionForm : Form
    {
        static AccountService _accountService = new AccountService();

        public TransactionForm()
        {
            InitializeComponent();
        }



        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string selectedAccountNumber = comboAccounts.SelectedItem?.ToString();
            string type = comboType.SelectedItem?.ToString();

            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Enter a valid amount.");
                return;
            }

            if (string.IsNullOrEmpty(selectedAccountNumber) || string.IsNullOrEmpty(type))
            {
                MessageBox.Show("Select an account and transaction type.");
                return;
            }

            var account = _accountService.GetUserAccounts(UserSession.CurrentUser.UserId)
                                        .FirstOrDefault(a => a.AccountNumber == selectedAccountNumber);

            if (account == null)
            {
                MessageBox.Show("Account not found.");
                return;
            }

            if (type == "Withdrawal")
            {
                if (account.Balance < amount)
                {
                    MessageBox.Show("Insufficient funds.");
                    return;
                }
                _accountService.Withdraw(account.AccountId, amount);
                MessageBox.Show($"Withdrawal of {amount:C} successful for account '{account.AccountNumber}'.");
            }
            else if (type == "Deposit")
            {
                _accountService.Deposit(account.AccountId, amount);
                MessageBox.Show($"Deposit of {amount:C} successful for account '{account.AccountNumber}'.");
            }
            else if (type == "Transfer")
            {
                if (account.Balance < amount)
                {
                    MessageBox.Show("Insufficient funds.");
                    return;
                }

                string receiverNumber = txtReceiverAccount.Text.Trim();
                if (string.IsNullOrEmpty(receiverNumber))
                {
                    MessageBox.Show("Enter receiver's account number.");
                    return;
                }

                var receiver = _accountService.GetAccountByNumber(receiverNumber);
                if (receiver == null)
                {
                    MessageBox.Show("Receiver account not found.");
                    return;
                }

                if (!_accountService.Transfer(account.AccountId, receiver.AccountId, amount))
                {
                    MessageBox.Show("Transfer failed.");
                    return;
                }

                MessageBox.Show($"Transfer of {amount:C} to '{receiver.AccountNumber}' successful.");
                txtReceiverAccount.Clear();
            }

            txtAmount.Clear();
        }


        private void TransactionForm_Load(object sender, EventArgs e)
        {
            if (UserSession.CurrentUser == null)
            {
                MessageBox.Show("No user is logged in.");
                this.Close();
                return;
            }

            var accounts = _accountService.GetUserAccounts(UserSession.CurrentUser.UserId);

            if (accounts == null || accounts.Count == 0)
            {
                MessageBox.Show("You don't have any accounts yet. Please create one first.");
                var createAccountForm = new CreateAccountForm();
                createAccountForm.FormClosed += (s, args) => this.Close();
                createAccountForm.Show();
                this.Close();
                return;
            }

            comboAccounts.Items.Clear();
            foreach (var account in accounts)
            {
                comboAccounts.Items.Add(account.AccountNumber);
            }

            if (comboAccounts.Items.Count > 0)
            {
                comboAccounts.SelectedIndex = 0;
            }

            comboType.Items.Clear();
            comboType.Items.Add("Deposit");
            comboType.Items.Add("Withdrawal");
            comboType.Items.Add("Transfer"); // NEW
            comboType.SelectedIndex = 0;

            // Create and hide receiver field
            lblReceiverAccount = new Label
            {
                Text = "Receiver Account #",
                Location = new System.Drawing.Point(30, 130),
                Size = new System.Drawing.Size(120, 20),
                Visible = false
            };


            // Toggle visibility based on selected type
            comboType.SelectedIndexChanged += (s, args) =>
            {
                bool isTransfer = comboType.SelectedItem.ToString() == "Transfer";
                lblReceiverAccount.Visible = isTransfer;
                txtReceiverAccount.Visible = isTransfer;
            };
        }

    }
}
