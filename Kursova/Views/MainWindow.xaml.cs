using Kursova.ViewModels;
using System.Windows;

namespace Kursova
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            DataContext = new MainWindowViewModel();
        }
    }
}
