using System.Linq;
using BankApp.Models;

namespace BankApp.Services
{
    public class UserService
    {
        private readonly BankDbContext _context = new BankDbContext();


        public User Register(string fullName, string email, string password)
        {
            var existing = _context.Users.FirstOrDefault(u => u.Email == email);
            if (existing != null) return null;

            var user = new User
            {
                FullName = fullName,
                Email = email,
                PasswordHash = password // Note: Hashing should be added for production
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Login(string email, string password)
        {
            return _context.Users
                .FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
        }

        public User GetById(int userId)
        {
            return _context.Users.Find(userId);
        }
    }
}