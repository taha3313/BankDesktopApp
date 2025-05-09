using System;
using System.Windows.Forms;
using BankApp.Services; // Assuming your services are in this namespace
using BankApp.Models;   // Assuming your models are in this namespace

namespace BankApp
{
    public partial class RegisterForm : Form
    {
        private readonly UserService _userService;

        public RegisterForm()
        {
            InitializeComponent();
            _userService = new UserService(); // Initialize UserService
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Get the user input from the form fields
            var fullName = txtName.Text;
            var email = txtEmail.Text;
            var password = txtPassword.Text;
            var confirmPassword = txtConfirmPassword.Text;

            // Validate if the password and confirm password match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            // Call the UserService to register the user
            var user = _userService.Register(fullName, email, password);

            if (user != null)
            {
                // Registration successful
                MessageBox.Show("User registered successfully!");

                // Navigate to the login form
                var loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
            else
            {
                // Registration failed (email already exists)
                MessageBox.Show("A user with this email already exists.");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
