using BankApp.Models;
using BankApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApp
{
    public partial class DashboardForm : Form
    {
        private static AccountService _accountService= new AccountService();

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            var createAccountForm = new CreateAccountForm();
            createAccountForm.Show();
        }

        private void btnTransactionHistory_Click(object sender, EventArgs e)
        {
            var historyForm = new TransactionHistoryForm();
            historyForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            var transactionForm = new TransactionForm();
            transactionForm.Show();
        }

        private void btnTransactionHistory_Click_1(object sender, EventArgs e)
        {
            var transactionHistoryForm = new TransactionHistoryForm();
            transactionHistoryForm.Show();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            UserSession.CurrentUser = null;
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void DashboardForm_Load(object sender, EventArgs e)
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
                return;
            }

            // Calculate the sum of balances
            decimal totalBalance = accounts.Sum(account => account.Balance);

            // Display the total balance in a TextBox (assuming txtTotalBalance is the TextBox control)
            txtTotalBalance.Text = totalBalance.ToString("C"); // "C" for Currency formathere
        }
        }
    }

