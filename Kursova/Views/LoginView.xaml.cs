using System.Windows;
using System.Windows.Controls;
using Kursova.ViewModels;

namespace Kursova.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        // Обробник для кнопки "Увійти"
        private void OnLoginButtonClick(object sender, RoutedEventArgs e)
        {
            // Отримуємо логін і пароль з текстових полів
            var login = ((TextBox)FindName("LoginTextBox")).Text;
            var password = ((PasswordBox)FindName("PasswordBox")).Password;

            // Перевірка аутентифікації
            var viewModel = (LoginViewModel)this.DataContext;
            if (viewModel.Login(login, password))
            {
                MessageBox.Show("Вхід успішний!");
            }
            else
            {
                MessageBox.Show("Невірний логін або пароль.");
            }
        }
    }
}
