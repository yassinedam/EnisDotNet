using ENISdotNet.Models;

namespace ENISdotNet.ViewModels
{
    public class UserViewModel
    {
        public User? user { get; set; }
        public List<Section>? sections { get; set; }
        public List<DemandePFE>? demandes { get; set; }
        public List<Paper>? papers { get; set; }

        public UserViewModel() { }
        public UserViewModel(User user, List<Section> sections, List<DemandePFE> demandes, List<Paper> papers)
        {
            this.user = user;
            this.sections = sections;
            this.demandes = demandes;
            this.papers = papers;

        }

    }
}
