using CommunityToolkit.Mvvm.Input;
using Kursova.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

public class MusicPlayerViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Playlist> _playlists;
    private Playlist _selectedPlaylist;
    private Track _selectedTrack;
    private MusicPlayer _musicPlayer;

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
            _playlists = value;
            OnPropertyChanged(nameof(Playlists));
        }
    }

    public Playlist SelectedPlaylist
    {
        get => _selectedPlaylist;
        set
        {
            _selectedPlaylist = value;
            OnPropertyChanged(nameof(SelectedPlaylist));
        }
    }

    public Track SelectedTrack
    {
        get => _selectedTrack;
        set
        {
            _selectedTrack = value;
            OnPropertyChanged(nameof(SelectedTrack));
            UpdateCommands();
        }
    }

    public ICommand PlayTrackCommand { get; }
    public ICommand PauseTrackCommand { get; }
    public ICommand StopTrackCommand { get; }

    public MusicPlayerViewModel()
    {
        _musicPlayer = MusicPlayer.Instance;

        LoadPlaylists();

        PlayTrackCommand = new RelayCommand(PlayTrack, CanPlayTrack);
        PauseTrackCommand = new RelayCommand(PauseTrack, CanPauseOrStopTrack);
        StopTrackCommand = new RelayCommand(StopTrack, CanPauseOrStopTrack);
    }

    private void LoadPlaylists()
    {
        Playlists = new ObservableCollection<Playlist>
        {
            new Playlist
            {
                PlaylistId = 1,
                Name = "Скрябін",
                Tracks = new ObservableCollection<Track>
                {
                    new Track { TrackId = 1, Title = "Спи собі сама", FilePath = @"C:\Users\dimab\OneDrive\Desktop\Kursova\Kursova\Kursova\Music\Spy-sobi-sama.mp3" },
                    new Track { TrackId = 2, Title = "Сам собі країна", FilePath = @"C:\Users\dimab\OneDrive\Desktop\Kursova\Kursova\Kursova\Music\Sam-sobi-kraina.mp3" },
                    new Track { TrackId = 3, Title = "Іспанія", FilePath = @"C:\Users\dimab\OneDrive\Desktop\Kursova\Kursova\Kursova\Music\Ispaniya.mp3"},
                    new Track { TrackId = 4, Title = "Мам", FilePath =@"C:\Users\dimab\OneDrive\Desktop\Kursova\Kursova\Kursova\Music\Mam.mp3" },
                    new Track { TrackId = 5, Title = "Шампанські очі", FilePath = @"C:\Users\dimab\OneDrive\Desktop\Kursova\Kursova\Kursova\Music\Schampanski-ochi.mp3" },
                    new Track { TrackId = 6, Title = "Танець пінгвіна", FilePath = @"C:\Users\dimab\OneDrive\Desktop\Kursova\Kursova\Kursova\Music\Tanets-pingvina.mp3"}
                }
            },
            new Playlist
            {
                PlaylistId = 2,
                Name = "Pop Classics",
                Tracks = new ObservableCollection<Track>
                {
                    new Track { TrackId = 7, Title = "Синтезатор", FilePath = @"C:\Music\Synth.mp3" }
                }
            },
              new Playlist
            {
                PlaylistId = 3,
                Name = "Улюблені",
                Tracks = new ObservableCollection<Track>
                {
                    new Track { TrackId = 8, Title = "Синтезатор", FilePath = @"C:\Music\Synth.mp3" }
                }
            }
        };
    }

    private void PlayTrack()
    {
        if (SelectedTrack != null)
        {
            _musicPlayer.Play(SelectedTrack.FilePath);
            UpdateCommands();
        }
    }

    private void PauseTrack()
    {
        _musicPlayer.Pause();
        UpdateCommands();
    }

    private void StopTrack()
    {
        _musicPlayer.Stop();
        UpdateCommands();
    }

    private bool CanPlayTrack()
    {
        return SelectedTrack != null && !_musicPlayer.IsPlaying;
    }

    private bool CanPauseOrStopTrack()
    {
        return _musicPlayer.IsPlaying;
    }

    private void UpdateCommands()
    {
        ((RelayCommand)PlayTrackCommand).NotifyCanExecuteChanged();
        ((RelayCommand)PauseTrackCommand).NotifyCanExecuteChanged();
        ((RelayCommand)StopTrackCommand).NotifyCanExecuteChanged();
    }
}
