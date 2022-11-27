namespace ENISdotNet.Models
{
    public class Departement
    {
        public int DepartementId { get; set; }
        public string? spacialitée { get; set; }
        public IList<Section>? sections { get; set;}

    }
}
