using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using Kursova.Models;


namespace Kursova.ViewModels
{
    public class MusicPlayerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Playlist> _playlists;
        private ObservableCollection<Track> _availableTracks;
        private Playlist _selectedPlaylist;
        private Track _selectedTrack;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Playlist> Playlists
        {
            get => _playlists;
            set
            {
                if (_playlists != value)
                {
                    _playlists = value;
                    OnPropertyChanged(nameof(Playlists));
                }
            }
        }


        public ObservableCollection<Track> AvailableTracks
        {
            get => _availableTracks;
            set
            {
                if (_availableTracks != value)
                {
                    _availableTracks = value;
                    OnPropertyChanged(nameof(AvailableTracks));
                }
            }
        }

        public Playlist SelectedPlaylist
        {
            get => _selectedPlaylist;
            set
            {
                if (_selectedPlaylist != value)
                {
                    _selectedPlaylist = value;
                    OnPropertyChanged(nameof(SelectedPlaylist));
                }
            }
        }

        public Track SelectedTrack
        {
            get => _selectedTrack;
            set
            {
                if (_selectedTrack != value)
                {
                    _selectedTrack = value;
                    OnPropertyChanged(nameof(SelectedTrack));
                }
            }
        }

        public ICommand AddTrackCommand { get; }
        public ICommand RemoveTrackCommand { get; }

        public MusicPlayerViewModel()
        {
            LoadPlaylists();
            LoadAvailableTracks();

            AddTrackCommand = new RelayCommand<object>(AddTrackToPlaylist, CanAddTrackToPlaylist);
            RemoveTrackCommand = new RelayCommand<object>(RemoveTrackFromPlaylist, CanRemoveTrackFromPlaylist);
        }

        private void AddTrackToPlaylist(object parameter)
        {
            if (SelectedPlaylist != null && SelectedTrack != null)
            {
                SelectedPlaylist.Tracks.Add(SelectedTrack);
            }
        }

        private void LoadPlaylists()
        {
            Playlists = new ObservableCollection<Playlist>
    {

                new Playlist
{
    PlaylistId = 1,
    Name = "My Playlist",
    Tracks = new ObservableCollection<Track>
    {
        new Track { TrackId = 1, Title = "Ne tvoya viyna" },
        new Track { TrackId = 2, Title = "Kokhannia ne zupynyt' nikhto" },
        new Track { TrackId = 3, Title = "Moya Ukraina, moyi syny" },
        new Track { TrackId = 4, Title = "Ty mene lyuby, a ya tebe chekayu" },
        new Track { TrackId = 5, Title = "Shumyty zelene more" },
        new Track { TrackId = 6, Title = "De ty teper, moya lyubov'?" },
        new Track { TrackId = 7, Title = "Doroha, shcho vedyty do domu" },
        new Track { TrackId = 8, Title = "Bez tebe ya ne mozhu buty" },
        new Track { TrackId = 9, Title = "Tantsyuy, poky molodyy" },
        new Track { TrackId = 10, Title = "Nekhaj bude tak, yak ye" }
    }
},
new Playlist
{
    PlaylistId = 2,
    Name = "Favorites",
    Tracks = new ObservableCollection<Track>
    {
        new Track { TrackId = 11, Title = "Zory na nebi, a ya na zemli" },
        new Track { TrackId = 12, Title = "Proshchavay, moya ridna, proshchavay" },
        new Track { TrackId = 13, Title = "Ya tebe kokhayu, ale ne mozhu skazaty" },
        new Track { TrackId = 14, Title = "Letila z hory veselа pіsня" },
        new Track { TrackId = 15, Title = "Ne pokydaj mene, ya ne mozhu sam" },
        new Track { TrackId = 16, Title = "Sontse zahodyt', a ya vse shche chekayu" },
        new Track { TrackId = 17, Title = "Ya budu z toboyu, yak nastane nich" },
        new Track { TrackId = 18, Title = "Moya ridna zemlya, moyi korinnya" },
        new Track { TrackId = 19, Title = "Prosto zalyshaysya, my shche vse vypravymo" },
        new Track { TrackId = 20, Title = "Shchastya tvoye v moyikh rukakh" }
    }
}


    };

            Console.WriteLine($"Loaded {Playlists.Count} playlists."); // Перевірка.
        }



        private void LoadAvailableTracks()
        {
            AvailableTracks = new ObservableCollection<Track>
            {
                new Track { TrackId = 1, Title = "Track 1" },
                new Track { TrackId = 2, Title = "Track 2" },
                new Track { TrackId = 3, Title = "Track 3" }
            };
        }

        private bool CanAddTrackToPlaylist(object parameter)
        {
            return SelectedPlaylist != null && SelectedTrack != null && !SelectedPlaylist.Tracks.Contains(SelectedTrack);
        }

        private void RemoveTrackFromPlaylist(object parameter)
        {
            if (SelectedPlaylist != null && SelectedTrack != null && SelectedPlaylist.Tracks.Contains(SelectedTrack))
            {
                SelectedPlaylist.Tracks.Remove(SelectedTrack);
            }
        }

        private bool CanRemoveTrackFromPlaylist(object parameter)
        {
            return SelectedPlaylist != null && SelectedTrack != null && SelectedPlaylist.Tracks.Contains(SelectedTrack);
        }
    }
}
