using KomodoInsuranceDeveloper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoInsuranceTests
{
    [TestClass]
    public class DevTeamRepoTests
    {
        private DevTeamRepo _repo;
        private DevTeams _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new DevTeamRepo();
            _content = new DevTeams("Awesome", 45678);
            //_repo.AddDeveloperToTeams(_content);
            _repo.AddDeveloperTeams(_content);
        }
        //Add
        [TestMethod]
        public void AddToTeam_ShouldGetNotNull()
        {
            //Arrange
            DevTeams content = new DevTeams();
            content.TeamId = 4444;
            content.TeamName = "Fantastic";
            DevTeamRepo repository = new DevTeamRepo();
            //ACT
            repository.AddDeveloperTeams(content);
            var count = repository.GetDevelopersTeamsList().Count;

            Developers newdev = new Developers();
            newdev.DevName = "Testing";
            newdev.UniqueId = 5;
            newdev.PluralSightMember = true;

            repository.AddDeveloperToTeams(4444,newdev);

            //connot implecitly convert = type mismatch
            //int != string
            //Devteams != developers
            Developers developerFromDirectory = repository.GetDeveloperByTeamUniqueId(4444);
            var ok = repository.GetTeamById(4444);
            
            //Assert
            Assert.IsNotNull(ok.TeamMembers);
        }
        //Update
        [TestMethod]
        public void UpdateExistingTeam_ShouldReturnTrue()
        {
            //Arrange
            //TestInitialiaze
            DevTeams newTeam = new DevTeams("Awesomes", 45678);
            //ACT
            bool updateResult = _repo.UpdateExistingDevelopersTeams(45678, newTeam);
            //Assert
            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void RemoveTeams_ShouldReturnTrue()
        {
            //Arrange
            //Act
            bool removeResult = _repo.RemoveDeveloperFromTeamsList(_content.TeamId);
            //Assert
            Assert.IsTrue(removeResult);

        }
    }
}
