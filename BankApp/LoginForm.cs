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
using BankApp.Services;

namespace BankApp
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;
        public LoginForm()
        {
            InitializeComponent();
            _userService = new UserService();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text;
            var password = txtPassword.Text;

            var user = _userService.Login(email, password);

            if (user != null)
            {
                // Store user information in memory
                UserSession.CurrentUser = user;

                // Open the main form and pass the user information
                var mainForm = new DashboardForm();
                this.Hide(); // Hide login form
                mainForm.Show(); // Show main form
            }
            else
            {
                MessageBox.Show("Invalid credentials.");
            }
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }
    }
}
