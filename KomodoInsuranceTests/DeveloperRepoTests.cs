using KomodoInsuranceDeveloper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoInsuranceTests
{
    [TestClass]
    public class DeveloperRepoTests
    {
        private DeveloperRepo _repo;
        private Developers _developers;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new DeveloperRepo();
            _developers = new Developers("Mike Smith", 4562, true);

            _repo.AddDeveloperToList(_developers);
        }
        //ADD
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            //ARRANGE--Set up the playing field
            Developers develop = new Developers();
            develop.UniqueId = 4527;
            DeveloperRepo repository = new DeveloperRepo();

            //ACT--Running Code I want to test
            repository.AddDeveloperToList(develop);
            Developers developersFromDirectory = repository.GetDeveloperByUniqueId(4527);

            //Assert--Verifying Outcome
            Assert.IsNotNull(developersFromDirectory);
        }
        //Update
        [TestMethod]
        public void UpdateExistingDevelopers_ShouldReturnTrue()
        {
            //Arrange
            //TestInitiaze
            Developers newDeveloper = new Developers("Mike mith", 4562, true);
            //ACT
            bool updateResult = _repo.UpdateExistingDevelopers(4562, newDeveloper);
            //Assert
            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            //Arrange= TestInitialize
            //ACT
            bool deleteResult = _repo.RemoveDeveloperFromList(_developers.UniqueId);
            //Assert
            Assert.IsTrue(deleteResult);
        }

    }
}
