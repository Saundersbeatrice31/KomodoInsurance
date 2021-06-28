using KomodoInsuranceDeveloper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoInsuranceTests
{
    [TestClass]
    public class DeveloperTests
    {
        [TestMethod]
        public void SetDevName_ShouldSetCorrectString()
        {
            //Arrange
            Developers develop = new Developers();
            //ACT
            develop.DevName = "Mike Smith";
            string expected = "Mike Smith";
            string actual = develop.DevName;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetUniqueID_ShouldSetCorrectInt()
        {
            //Arrange
            Developers newId = new Developers();
            //ACT
            newId.UniqueId = 4256;
            int expected = 4256;
            int actual = newId.UniqueId;
            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void SetPluralSight_ShouldSetCorrectBool()
        {
            //Arrange
            Developers plural = new Developers();
            //ACT
            plural.PluralSightMember = true;
            bool expected = true;
            bool actual = plural.PluralSightMember;
            //ASSERT
            Assert.AreEqual(expected, actual);

        }
    }
}

