using System;
using System.Linq;
using Kursova.Models;  // Тут має бути ваш контекст БД

namespace Kursova.ViewModels
{
    public class LoginViewModel
    {
       private readonly ApplicationDbContext _dbContext;

        public LoginViewModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Login(string login, string password)
        {
           var user = _dbContext.Users.FirstOrDefault(u => u.Username == login);

            if (user != null)
            {
                if (user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
