using System.Windows;
using System.Windows.Controls;
using Kursova.Models;
using Kursova.ViewModels;

namespace Kursova.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
          
            var dbContext = new ApplicationDbContext();

            this.DataContext = new LoginViewModel(dbContext);
        }

        private void OnLoginButtonClick(object sender, RoutedEventArgs e)
        {
            var login = ((TextBox)FindName("LoginTextBox")).Text;
            var password = ((PasswordBox)FindName("PasswordBox")).Password;

            if (this.DataContext is LoginViewModel viewModel)
            {
                
                if (viewModel.Login(login, password))
                {
                    MessageBox.Show("Вхід успішний!");
                }
                else
                {
                    MessageBox.Show("Невірний логін або пароль.");
                }
            }
            else
            {
                MessageBox.Show("Модель даних не знайдена або неправильний тип.");
            }
        }
    }
}
