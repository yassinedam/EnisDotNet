namespace ENISdotNet.Models
{
    public class Section
    {
        public int SectionId { get; set; }
        public string? sectionName { get; set; }

        public string? Grade { get; set; }
        public string? schoolYear { get; set; }
        public int DepartementId { get; set; }
        public Departement? Departement { get; set; }
        public IList<User>? Users { get; set; }

    }
}
