using Kursova.Models;
using System.ComponentModel;
using System.Windows.Input;


namespace Kursova.ViewModels
{
    public class UserProfileViewModel : INotifyPropertyChanged
    {
        private User _currentUser;

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        public ICommand SaveChangesCommand { get; }

        public UserProfileViewModel()
        {
            // Ініціалізуйте профіль користувача
            CurrentUser = new User
            {
                Username = "Ivan",
                FullName= "Petrenko",
                Email = "ivan.petrenko@example.com"
            };

            SaveChangesCommand = new RelayCommand<object>(
            execute: _ => SaveChanges(),
            canExecute: _ => true
            );

        }

        private void SaveChanges()
        {

            System.Diagnostics.Debug.WriteLine($"User {CurrentUser.Username} {CurrentUser.FullName} saved.");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
