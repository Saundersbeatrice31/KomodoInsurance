using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceDeveloper
{
    public class DeveloperRepo
    {
        //FakeDatabase
        private List<Developers> _listOfDevelopers = new List<Developers>();
        //Create
        public void AddDeveloperToList(Developers develop)
        {
            _listOfDevelopers.Add(develop);
        }
        //Read
        public List<Developers> GetDevelopersList()
        {
            return _listOfDevelopers;
        }
        //Update the content
        public bool UpdateExistingDevelopers(int uniqueId, Developers develop)
        {
            //find the developer
            Developers existingDeveloper = GetDeveloperByUniqueId(uniqueId);

            //Update the developer
            if (existingDeveloper != null)
            {
                existingDeveloper.DevName = develop.DevName;
                existingDeveloper.UniqueId = develop.UniqueId;
                existingDeveloper.PluralSightMember = develop.PluralSightMember;
                return true;
            }
            else
            {
                return false;
            }

        }
        //Delete
        public bool RemoveDeveloperFromList(int uniqueId)
        {
            Developers develop = GetDeveloperByUniqueId(uniqueId);

            if (develop == null)
            {
                return false;
            }
            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(develop);

            if (initialCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //helper Method
        public Developers GetDeveloperByUniqueId(int uniqueId)
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
    }
}
