namespace Kursova.Models
{
    public class Report
    {
        public int ReportId { get; set; }  // Ідентифікатор звіту
        public int CommentId { get; set; }  // Ідентифікатор коментаря, який був повідомлений
        public int UserId { get; set; }  // Ідентифікатор користувача, який подав звіт
        public string Reason { get; set; }  // Причина звіту
        public DateTime DateCreated { get; set; }  // Дата подачі звіту
    }
}
