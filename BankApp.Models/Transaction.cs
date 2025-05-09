using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public int AccountId { get; set; }  // Sender or original account

        public int? ReceiverId { get; set; }  // Null for deposits/withdrawals, set for transfers

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Description { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        [ForeignKey("ReceiverId")]
        public virtual Account ReceiverAccount { get; set; }

        public Transaction() { }
    }
}
