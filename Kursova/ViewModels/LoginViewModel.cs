using System;

namespace Kursova.ViewModels
{
    public class LoginViewModel
    {
        // Простий приклад для перевірки логіну та пароля
        public bool Login(string login, string password)
        {
            // Перевірка за умовами
            if (login == "admin" && password == "1234")
            {
                return true;
            }
            return false;
        }
    }
}
