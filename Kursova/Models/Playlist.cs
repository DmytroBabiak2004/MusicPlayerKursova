namespace Kursova.Models
{
    public class Playlist
    {
        public int PlaylistId { get; set; }  // Ідентифікатор плейлиста
        public string Name { get; set; }  // Назва плейлиста
        public int UserId { get; set; }  // Ідентифікатор користувача, який створив плейлист
        public List<Track> Tracks { get; set; }  // Список пісень у плейлисті
    }
}
