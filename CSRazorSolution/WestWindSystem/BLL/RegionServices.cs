#nullable disable
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
    public class RegionServices
    {
        #region Setup of the Context Connection Variable and Class Constructor

        // Variable to hold an instance of context class
        private readonly WestWindContext _context;

        // Constructor to create an instance of the required context class
        internal RegionServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion

        #region Quaries
        // This query will have a parameter which will receive an argument value from 
        //  the web page
        // This query will return a single instance of the entity Region (sql table Region)
        //  which matches the incoming argument value
        public Region Region_GetbyID(int regionID)
        {
            Region info = _context.Regions
                            .Where(acollectionrow => acollectionrow.RegionID == regionID)
                            .FirstOrDefault();
            return info;
        }

        // Get all the records of the spl Region table
        // Return as a List<T>
        public List<Region> Region_List()
        {
            // Linq querys use two generic collection types
            //  IQueryable this is a data collection returned from sql
            //  IEnumerable this is a data collection in local memory
            // You can convert either of these collections to a List<T> using .ToList()
            IEnumerable<Region> info = _context.Regions
                                        .OrderBy(x => x.RegionDescription);
            return info.ToList();

            // OR 

            // One could convert the returned data collection to a List<T> by 
            //  placing the conversion method directly on your query
/*            
            IEnumerable<Region> info = _context.Regions
                                        .OrderBy(x => x.RegionDescription)
                                        .ToList();
            return info;
*/

        }

        #endregion

    }
}
