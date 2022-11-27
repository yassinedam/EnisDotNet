using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENISdotNet.Models;

public class User
{
    public int UserId { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string Name
    {
        get
        {
            return firstName + " " + lastName;
        }
    }
    public int phoneNumber { get; set; }
    public string? role { get; set; }
    public string? password { get; set; }
    public int SectionId { get; set; }
    public Section? section { get; set; }
    public IList<DemandePFE>? demandes { get; set; }
    public IList<Paper>? papers { get; set; }




}
