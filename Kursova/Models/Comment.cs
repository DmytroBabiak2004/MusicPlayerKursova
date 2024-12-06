namespace Kursova.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; } 
        public int TrackId { get; set; } 
        public DateTime DateCreated { get; set; }
    }
}
