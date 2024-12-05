namespace Kursova.Models
{
    public class Track
    {
        public int TrackId { get; set; }  
        public string Title { get; set; } 
        public string Artist { get; set; } 
        public string Album { get; set; }          
        public string Genre { get; set; }  
        public TimeSpan Duration { get; set; } 
    }
}
