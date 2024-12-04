using System.ComponentModel;
using System.Windows.Controls; // Для UserControl
using System.Windows.Input;

namespace Kursova.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private UserControl _currentView;

        public UserControl CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public ICommand NavigateCommand { get; }

        public MainWindowViewModel()
        {
            NavigateCommand = new RelayCommand<string>(Navigate);
            CurrentView = new HomeView();
        }

        private void Navigate(string viewName)
        {
            switch (viewName)
            {
                case "Home":
                    CurrentView = new HomeView();
                    break;
                case "AdminTools":
                    CurrentView = new AdminToolsView();
                    break;
                case "Login":
                    CurrentView = new LoginView();
                    break;
                case "MusicPlayer":
                    CurrentView = new MusicPlayerView();
                    break;
                case "UserProfile":
                    CurrentView = new UserProfileView();
                    break;
                default:
                    CurrentView = new HomeView();
                    break;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
