using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceDeveloper
{
    public class DevTeamRepo
    {
        //FakeDatabase
        private List<Developers> _listOfDevelopers = new List<Developers>();
        private List<DevTeams> _listOfDeveloperTeams = new List<DevTeams>();

        //Create
        public void AddDeveloperTeams(DevTeams devTeam)
        {
            _listOfDeveloperTeams.Add(devTeam);
        }
        public void AddDeveloperToTeams(int teamid,Developers develop)
        {
            foreach (var item in _listOfDeveloperTeams)
            {
                if(item.TeamId == teamid)
                {
                    item.TeamMembers.Add(develop);
                }
            }
            //_listOfDevelopers.Add(develop);
        }
        //Read
        public List<DevTeams> GetDevelopersTeamsList()
        {
            return _listOfDeveloperTeams;
        }

        //Update the content
        //still going to pass it a dev team object
        public bool UpdateExistingDevelopersTeams(int uniqueId, DevTeams test)
        {
            //find the developer team
            //Developers develop,
            //Developers existingDeveloperTeam = GetDeveloperByTeamUniqueId(uniqueId);
            DevTeams getteamid = GetTeamById(uniqueId);

            if (getteamid != null)
            {
                getteamid.TeamName = test.TeamName;
                getteamid.TeamMembers = test.TeamMembers;
                return true;
            }
            return false;            
        }
        //Delete
        public bool RemoveDeveloperFromTeamsList(int uniqueId, int TeamId)
        {
            Developers develop = GetDeveloperByTeamUniqueId(uniqueId);
            DevTeams devTeams = GetTeamById(TeamId);

            if (develop == null)
            {
                return false;
            }
            int initialCount = devTeams.TeamMembers.Count;
            devTeams.TeamMembers.Remove(develop);
            

            if (initialCount > devTeams.TeamMembers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveDeveloperTeam(int uniqueTeamId)
        {
            DevTeams TeamToRemove = GetTeamById(uniqueTeamId);
            if (TeamToRemove == null)
            {
                return false;
            }
            int InitialCount = _listOfDeveloperTeams.Count;
            _listOfDeveloperTeams.Remove(TeamToRemove);
            if (InitialCount > _listOfDeveloperTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }
        //helper Method
        public Developers GetDeveloperByTeamUniqueId(int uniqueId)
        {
            foreach (Developers develop in _listOfDevelopers)
            {
                if (develop.UniqueId == uniqueId)
                {
                    return develop;
                }
            }
            return null;
        }

        public DevTeams GetTeamById(int uniqueId)
        {
            foreach (DevTeams develop in _listOfDeveloperTeams)
            {
                if (develop.TeamId == uniqueId)
                {
                    return develop;
                }
            }
            return null;
        }
    }
}
