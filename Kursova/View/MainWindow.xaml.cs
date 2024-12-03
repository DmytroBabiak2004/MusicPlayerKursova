using System.Windows;

namespace Kursova.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindow();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}
