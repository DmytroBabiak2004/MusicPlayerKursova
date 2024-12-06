using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Kursova.Models;

namespace Kursova.ViewModels
{
    public class TrackEditorViewModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Track _track;

        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public string Duration { get; set; }

        public ICommand SaveCommand { get; }

        public TrackEditorViewModel(ApplicationDbContext dbContext, Track track)
        {
            _dbContext = dbContext;
            _track = track;

            Title = _track.Title;
            Artist = _track.Artist;
            Album = _track.Album;
            Genre = _track.Genre;
            Duration = _track.Duration.ToString(@"hh\:mm\:ss");

            SaveCommand = new RelayCommand<object>(SaveTrack);
        }

        private void SaveTrack(object parameter)
        {
            if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Artist) || string.IsNullOrEmpty(Album) || string.IsNullOrEmpty(Genre) || string.IsNullOrEmpty(Duration))
            {
                MessageBox.Show("Всі поля мають бути заповнені.");
                return;
            }

            if (!TimeSpan.TryParse(Duration, out var duration))
            {
                MessageBox.Show("Невірний формат тривалості.");
                return;
            }

            _track.Title = Title;
            _track.Artist = Artist;
            _track.Album = Album;
            _track.Genre = Genre;
            _track.Duration = duration;

            if (_track.TrackId == 0)
            {
                _dbContext.Tracks.Add(_track);
            }
            else
            {
                _dbContext.Tracks.Update(_track);
            }

            _dbContext.SaveChanges();
        }
    }
}
