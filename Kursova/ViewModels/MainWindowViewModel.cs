using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kursova.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IViewFactory _viewFactory;
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

        public MainWindowViewModel()  // Дефолтний конструктор
        {
            _viewFactory = new ViewFactory(); // Ініціалізація вручну
            NavigateCommand = new RelayCommand<string>(Navigate);
            CurrentView = _viewFactory.CreateView("Home");
        }

        public MainWindowViewModel(IViewFactory viewFactory)  // Конструктор з параметром
        {
            _viewFactory = viewFactory;
            NavigateCommand = new RelayCommand<string>(Navigate);
            CurrentView = _viewFactory.CreateView("Home");
        }

        private void Navigate(string viewName)
        {
            CurrentView = _viewFactory.CreateView(viewName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
