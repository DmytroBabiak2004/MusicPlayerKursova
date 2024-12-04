using System.ComponentModel;
using System.Windows.Input;


namespace Kursova.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private object _currentView;

        public object CurrentView
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
            CurrentView = new MainWindow(); // Початкове вікно
        }

        private void Navigate(string viewName)
        {
            switch (viewName)
            {
                case "Home":
                    CurrentView = new MainWindow();
                    break;
                case "Music":
                    CurrentView = new MusicPlayerView();
                    break;
                case "Profile":
                    CurrentView = new UserProfileView();
                    break;
                case "Admin":
                    CurrentView = new AdminToolsView();
                    break;
                default:
                    CurrentView = new MainWindow();
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