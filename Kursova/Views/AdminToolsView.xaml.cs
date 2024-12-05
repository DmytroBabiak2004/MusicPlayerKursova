using System.Windows.Controls;
using Kursova.ViewModels;

namespace Kursova
{
    public partial class AdminToolsView : UserControl
    {
        public AdminToolsView()
        {
            InitializeComponent();
            DataContext = new AdminToolsViewModel();
        }
    }
}