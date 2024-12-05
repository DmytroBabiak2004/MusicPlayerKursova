using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Kursova.Models;

namespace Kursova.ViewModels
{
    internal class AdminToolsViewModel
    {
        private readonly ApplicationDbContext _dbContext;

        public ObservableCollection<Track> Tracks { get; set; }

        public ICommand AddTrackCommand { get; }
        public ICommand EditTrackCommand { get; }
        public ICommand DeleteTrackCommand { get; }

        public AdminToolsViewModel()
        {
            _dbContext = new ApplicationDbContext();

            AddTrackCommand = new RelayCommand(AddTrack);
            EditTrackCommand = new RelayCommand(EditTrack);
            DeleteTrackCommand = new RelayCommand(DeleteTrack);

            LoadTracks();
        }

        private void LoadTracks()
        {
            Tracks = new ObservableCollection<Track>(_dbContext.Tracks.ToList());
        }

        private void AddTrack()
        {
            var editor = new TrackEditorWindow(_dbContext);
            editor.ShowDialog();
            LoadTracks();
        }

        private void EditTrack()
        {
            var selectedTrack = Tracks.FirstOrDefault();
            if (selectedTrack != null)
            {
                var editor = new TrackEditorWindow(_dbContext, selectedTrack.TrackId); 
                editor.ShowDialog();
                LoadTracks();
            }
        }

        private void DeleteTrack()
        {
            var selectedTrack = Tracks.FirstOrDefault();
            if (selectedTrack != null)
            {
                _dbContext.Tracks.Remove(selectedTrack);
                _dbContext.SaveChanges();
                LoadTracks();
            }
        }
    }
}
