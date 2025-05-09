using System.Collections.Generic;
using System.Linq;
using BankApp.Models;

namespace BankApp.Services
{
    public class TransactionService
    {
        private readonly BankDbContext _context = new BankDbContext();


    public List<Transaction> GetTransactionsForAccount(int accountId)
        {
            return _context.Transactions
                .Where(t => t.AccountId == accountId)
                .OrderByDescending(t => t.Date)
                .ToList();
        }


    }
}