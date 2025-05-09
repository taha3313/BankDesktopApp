using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankApp.Models
{
    public class User
    {
        public User() { Accounts = new HashSet<Account>(); }


    [Key]
    public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}