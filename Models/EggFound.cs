namespace EggHuntApp.Models
{
    public class EggFound
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime FoundAt { get; set; } = DateTime.UtcNow;
    }
}
