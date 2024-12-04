namespace Kursova.Models
{
    public class User
    {
        public int UserId { get; set; }  // Ідентифікатор користувача
        public string Username { get; set; }  // Логін
        public string Password { get; set; }  // Пароль
        public string Email { get; set; }  // Електронна пошта
        public string FullName { get; set; }  // Повне ім'я
        public DateTime DateOfBirth { get; set; }  // Дата народження
    }
}
