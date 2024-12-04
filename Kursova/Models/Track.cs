namespace Kursova.Models
{
    public class Track
    {
        public int TrackId { get; set; }  // Ідентифікатор пісні
        public string Title { get; set; }  // Назва пісні
        public string Artist { get; set; }  // Виконавець
        public string Album { get; set; }  // Альбом
        public string Genre { get; set; }  // Жанр
        public TimeSpan Duration { get; set; }  // Тривалість пісні
    }
}
