using System.Windows;
using Kursova.Models;  // Ваші моделі
using Microsoft.EntityFrameworkCore;

namespace Kursova
{
    public partial class TrackEditorWindow : Window
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Track _track;

        public TrackEditorWindow(ApplicationDbContext dbContext, int? trackId = null)
        {
            InitializeComponent();
            _dbContext = dbContext;

            if (trackId != null)
            {
                _track = _dbContext.Tracks.Find(trackId)!;  // Завантажуємо існуючий трек
                LoadTrackData();  // Завантажуємо дані в поля
            }
            else
            {
                _track = new Track();  // Створюємо новий трек
            }
        }

        private void LoadTrackData()
        {
            TitleTextBox.Text = _track.Title;
            ArtistTextBox.Text = _track.Artist;
            AlbumTextBox.Text = _track.Album;
            GenreTextBox.Text = _track.Genre;
            DurationTextBox.Text = _track.Duration.ToString(@"hh\:mm\:ss");  // Конвертуємо TimeSpan в строку
        }

        private async void OnSaveClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text) ||
                string.IsNullOrWhiteSpace(ArtistTextBox.Text) ||
                string.IsNullOrWhiteSpace(AlbumTextBox.Text) ||
                string.IsNullOrWhiteSpace(GenreTextBox.Text) ||
                string.IsNullOrWhiteSpace(DurationTextBox.Text))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            _track.Title = TitleTextBox.Text;
            _track.Artist = ArtistTextBox.Text;
            _track.Album = AlbumTextBox.Text;
            _track.Genre = GenreTextBox.Text;

            if (TimeSpan.TryParse(DurationTextBox.Text, out TimeSpan duration))
            {
                _track.Duration = duration;
            }
            else
            {
                MessageBox.Show("Invalid time format.");
                return;
            }

            if (_track.TrackId == 0)
            {
                _dbContext.Tracks.Add(_track);
            }

            try
            {
                await _dbContext.SaveChangesAsync(); // Асинхронне збереження
                DialogResult = true;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? "Error saving data.");
                DialogResult = false;
            }
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
