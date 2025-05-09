using BankApp.Forms;
using BankApp.Models;
using BankApp.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApp.Forms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var db = new BankDbContext())
                if (!db.Users.Any()) 
            { var user = new User { FullName = "Taha Chelly", Email = "tahachelly@gmail.com", PasswordHash = "0000" }; 
                var account = new Account { AccountNumber = "ACC001", Balance = 1000, User = user }; 
                db.Users.Add(user); db.Accounts.Add(account); db.SaveChanges(); } 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            {
                Database.SetInitializer(new CreateDatabaseIfNotExists<BankDbContext>()); using (var context = new BankDbContext()) { context.Database.Initialize(force: true); }
            }
                Application.Run(new LoginForm());
        }
    }
}
