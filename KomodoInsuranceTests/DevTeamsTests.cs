using KomodoInsuranceDeveloper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoInsuranceTests
{
    [TestClass]
    public class DevTeamsTests
    {
        [TestMethod]
        public void SetDevTeamName_ShouldSetCorrectString()
        {
            //Arrange
            DevTeams  develops = new DevTeams();
            //ACT
            develops.TeamName= "Awesome";
            string expected = "Awesome";
            string actual = develops.TeamName;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetUniqueTeamID_ShouldSetCorrectInt()
        {
            //Arrange
            DevTeams newId = new DevTeams();
            //ACT
            newId.TeamId = 42676;
            int expected = 42676;
            int actual = newId.TeamId;
            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void SetTeamMemberToTeam_ShouldSetCorrectlist()
        {
            //Arrange
            DevTeams listDevs = new DevTeams();
            Developers newDev = new Developers();
            DeveloperRepo test = new DeveloperRepo();
            DevTeamRepo testing = new DevTeamRepo();
            //new developers
            newDev.DevName = "test";
            newDev.UniqueId = 1;
            newDev.PluralSightMember = false;
            //add the developer
            test.AddDeveloperToList(newDev);
            //ACT
            //creating team
            listDevs.TeamId = 4444;
            listDevs.TeamName = "Testing";
            //create the team
            testing.AddDeveloperTeams(listDevs);
            //add the dev to the team
            testing.AddDeveloperToTeams(listDevs.TeamId, newDev);

            //listDevs.TeamMembers = new DevTeams;
            //string expected = listDevs;
            var lists = testing.GetTeamById(4444);
            var actual = lists.TeamMembers.Count;
            //Assert
            Assert.AreEqual(1, actual);

        }

    }
}

