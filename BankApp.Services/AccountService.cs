using System;
using System.Collections.Generic;
using System.Linq;
using BankApp.Models;

namespace BankApp.Services
{
    public class AccountService
    {
        private readonly BankDbContext _context = new BankDbContext(); // Your DB context

        public Account CreateAccount(int userId, string accountNumber, decimal initialBalance = 0)
        {
            var account = new Account
            {
                AccountNumber = accountNumber,
                Balance = initialBalance,
                UserId = userId
            };

            _context.Accounts.Add(account);
            _context.SaveChanges();  // Save changes after adding the new account
            return account;
        }

        public List<Account> GetUserAccounts(int userId)
        {
            return _context.Accounts
                .Where(a => a.UserId == userId)
                .ToList();
        }

        public bool Deposit(int accountId, decimal amount)
        {
            var account = _context.Accounts.Find(accountId);
            if (account == null) return false;

            account.Balance += amount;

            _context.Transactions.Add(new Transaction
            {
                AccountId = accountId,
                Amount = amount,
                Date = System.DateTime.Now,
                Description = "Deposit"
            });

            _context.SaveChanges();  // Save changes after the deposit
            return true;
        }

        public bool Withdraw(int accountId, decimal amount)
        {
            var account = _context.Accounts.Find(accountId);
            if (account == null || account.Balance < amount) return false;

            account.Balance -= amount;

            _context.Transactions.Add(new Transaction
            {
                AccountId = accountId,
                Amount = -amount,
                Date = System.DateTime.Now,
                Description = "Withdrawal"
            });

            _context.SaveChanges();  // Save changes after the withdrawal
            return true;
        }

        public List<Transaction> GetUserTransactions(int userId)
        {
            return _context.Transactions
                .Where(t => t.Account.UserId == userId)
                .OrderByDescending(t => t.Date)
                .ToList();
        }

        public Account GetAccountByNumber(string accountNumber)
        {
            return _context.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }
        public bool Transfer(int senderId, int receiverId, decimal amount)
        {
            var sender = _context.Accounts.Find(senderId);
            var receiver = _context.Accounts.Find(receiverId);

            if (sender == null || receiver == null || sender.Balance < amount)
                return false;

            sender.Balance -= amount;
            receiver.Balance += amount;

            _context.Transactions.Add(new Transaction
            {
                AccountId = senderId,
                ReceiverId = receiverId,
                Amount = amount,
                Date = DateTime.Now,
                Description = "Transfer Sent"
            });

            _context.Transactions.Add(new Transaction
            {
                AccountId = receiverId,
                Amount = amount,
                Date = DateTime.Now,
                Description = "Transfer Received"
            });

            _context.SaveChanges();
            return true;
        }

    }
}
