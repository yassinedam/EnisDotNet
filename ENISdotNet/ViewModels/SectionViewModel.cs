using ENISdotNet.Models;

namespace ENISdotNet.ViewModels
{
    public class SectionViewModel
    {
        public Section? section { get; set; }
        public List<Departement>? departements { get; set; }
        public SectionViewModel() { }
        public SectionViewModel(Section section, List<Departement> departements)
        {
            this.section = section;
            this.departements = departements;
        }
        
        }
}
