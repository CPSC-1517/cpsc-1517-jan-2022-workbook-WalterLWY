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
        // This partial search query has been alter to allow for paging of its results 
        // If paging is NOT required, the query should have a single string parameter: partialdesciption
        public List<Territory> GetByPartialDesciption(string partialdescription,
                                                        int pagenumber,
                                                        int pagesize,
                                                        out int totalcount)
        {
            IEnumerable<Territory> info = _context.Territories
                                        .Where(x => x.TerritoryDescription.Contains(partialdescription))
                                        .OrderBy(x => x.TerritoryDescription);
            
            // Using the paging parameters to obtain only the necessary rows that 
            //  will be shown by the Paginator

            // Determine the total collection size of our query
            totalcount = info.Count();
            
            // Determine the number of rows to skip
            //  This skipped count reflects the rows of the previous pages
            //  remember the pagenumber is a natural number (1,2,3...)
            //  This needs to be treated as an index (natural number - 1)
            //  The number of rows to skip is index * pagesize
            int skipRows = (pagenumber - 1) * pagesize;
            
            // return only the required number of rows
            // This will be done using the filters belonging to Linq
            // use the filter .Skip(n) to skip over n rows from the beginning of a collection
            // use the filter .Take(n) to take the next n rows from a collection
            return info.Skip(skipRows).Take(pagesize).ToList();

            // This is the return statement that would be used IF no paging is being implemented
            //return info.ToList();
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
