namespace Kursova.Models
{
    public class Comment
    {
        public int CommentId { get; set; }  // Ідентифікатор коментаря
        public string Content { get; set; }  // Текст коментаря
        public int UserId { get; set; }  // Ідентифікатор користувача, який написав коментар
        public int TrackId { get; set; }  // Ідентифікатор пісні, до якої залишено коментар
        public DateTime DateCreated { get; set; }  // Дата створення коментаря
    }
}
