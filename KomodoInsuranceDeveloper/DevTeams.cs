using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceDeveloper
{
    //Plain Old C# Object
    public class DevTeams
    {
        //Properties
        public string TeamName { get; set; }
        public int TeamId { get; set; }
        public List<Developers> TeamMembers { get; set; } = new List<Developers>();

        //Constructors
        public DevTeams() { }
        public DevTeams(string teamName, int teamId)
        {
            TeamName = teamName;
            TeamId = teamId;
        }
    }
}
