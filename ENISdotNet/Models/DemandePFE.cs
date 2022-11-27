namespace ENISdotNet.Models
{
    public class DemandePFE
    {
        public int Id { get; set; }
        public string? date { get; set; }
        public string? description { get; set; }
        public string? Status { get; set; }
        public string? demanded_at { get; set; }
        public string? approved_at   { get; set; }
        public int UserId { get; set; }
        public User? user { get; set; }

    }
}
