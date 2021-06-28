using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceDeveloper
{
    //Plain old C# Object -- POCO
    public class Developers
    {
        //Properties
        public string DevName { get; set; }
        public int UniqueId { get; set; }
        public bool PluralSightMember { get; set; }

        //Constructors
        public Developers() { }
        public Developers(string devName, int uniqueId, bool pluralSight)
        {
            DevName = devName;
            UniqueId = uniqueId;
            PluralSightMember = pluralSight;
        }

    }
}
