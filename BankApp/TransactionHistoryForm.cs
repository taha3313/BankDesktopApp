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
    public partial class TransactionHistoryForm : Form
    {

        private static AccountService _accountService= new AccountService();
        public TransactionHistoryForm()
        {
            InitializeComponent();
        }

        private void lvTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TransactionHistoryForm_Load(object sender, EventArgs e)
        {
            {
                if (UserSession.CurrentUser == null)
                {
                    MessageBox.Show("No user is logged in.");
                    this.Close();
                    return;
                }

                var transactions = _accountService.GetUserTransactions(UserSession.CurrentUser.UserId);

                if (transactions == null || transactions.Count == 0)
                {
                    MessageBox.Show("No transactions found.");
                    this.Close();
                    return;
                }

                lvTransactions.Items.Clear();
                foreach (var transaction in transactions)
                {
                    string date = transaction.Date.ToString("yyyy-MM-dd");
                    string description = transaction.Description;
                    string amount = transaction.Amount.ToString("C");
                    string receiver = "N/A"; 
                    if (transaction.ReceiverAccount != null)
                    {
                        receiver = transaction.ReceiverAccount.AccountNumber;
                    }
                    var item = new ListViewItem(new[] { date, description, amount, receiver });
                    lvTransactions.Items.Add(item);
                }
            }
        }
    }
    }
