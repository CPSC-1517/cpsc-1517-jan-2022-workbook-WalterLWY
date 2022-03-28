using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class TerritoryServices
    {
        #region Setup of the Context Connection Variable and Class Constructor

        // Variable to hold an instance of context class
        private readonly WestWindContext _context;

        // Constructor to create an instance of the required context class
        internal TerritoryServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion

        #region Queries

        // Query by a string
        public List<Territory> GetByPartialDesciption(string partialdescription)
        {
            IEnumerable<Territory> info = _context.Territories
                                        .Where(x => x.TerritoryDescription.Contains(partialdescription))
                                        .OrderBy(x => x.TerritoryDescription);
            return info.ToList();
        }

        // Query by a number
        public List<Territory> GetByRegion(int regionid)
        {
            IEnumerable<Territory> info = _context.Territories
                                        .Where(x => x.RegionID == regionid)
                                        .OrderBy(x => x.TerritoryDescription);
            return info.ToList();
        }
        #endregion
    }
}
