namespace Kursova.Models
{
    public class Report
    {
        public int ReportId { get; set; }  
        public int CommentId { get; set; }  
        public int UserId { get; set; } 
        public string Reason { get; set; }  
        public DateTime DateCreated { get; set; }  
    }
}
