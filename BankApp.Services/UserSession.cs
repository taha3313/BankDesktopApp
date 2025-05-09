using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public class UserSession
    {
        // Static property to hold the current user
        public static User CurrentUser { get; set; }
    }
}

