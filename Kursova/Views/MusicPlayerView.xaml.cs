using System.Windows.Controls;


namespace Kursova
{
    public partial class MusicPlayerView : UserControl
    {
        public MusicPlayerView()
        {
            InitializeComponent();
            DataContext = new MusicPlayerViewModel();
        }
    }
}
