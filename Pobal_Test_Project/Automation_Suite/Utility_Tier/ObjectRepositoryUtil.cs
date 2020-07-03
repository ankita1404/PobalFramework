using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Suite.Utility_Tier
{
    class ObjectRepositoryUtil
    {
        public struct objPropertyValue
        {

            public string REFName;
            public string Identifier;
            public string Property;
        }

        public class objectRepositoryDictionary : Dictionary<string, objPropertyValue>
        {
            public void Add(string REFName, string Identifier, string Property)
            {
                objPropertyValue val;
                val.REFName = REFName;
                val.Identifier = Identifier;
                val.Property = Property;
                this.Add(REFName, val);
            }
        }
    }
}
