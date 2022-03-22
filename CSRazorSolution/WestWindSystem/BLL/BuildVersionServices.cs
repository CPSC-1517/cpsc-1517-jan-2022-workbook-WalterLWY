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
    public class BuildVersionServices
    {
        #region Setup of the Context Connection Variable and Class Constructor

        // Variable to hold an instance of context class
        private readonly WestWindContext _context;

        // Constructor to create an instance of the required context class
        internal BuildVersionServices (WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion

        #region Services: Query

        // Create a method (services) that will retrieve the BuildVersion record
        // This will be called from the Web App (PageModel file), thus it needs to be public
        // This becomes part of the class library's (application library) public interface
        public BuildVersion GetBuildVersion()
        {
            // going to your context instance (class), use the property (DbSet) for 
            //  BuildVersion data
            // Using this property will retrieve your data from the database.
            // The query will get the first record from the database collection (records)
            //  and return it
            // If no data is returned from sql for the query, the returned value will be null

            BuildVersion info = _context.BuildVersions.FirstOrDefault();
            return info;
        }
        #endregion

    }
}
