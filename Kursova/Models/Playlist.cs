using System.Collections.ObjectModel;

namespace Kursova.Models
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Track> Tracks { get; set; } = new ObservableCollection<Track>();
    }

}
