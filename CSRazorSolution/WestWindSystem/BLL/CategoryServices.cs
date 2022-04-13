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
    public class CategoryServices
    {
        #region Setup of the Context Connection Variable and Class Constructor

        // Variable to hold an instance of context class
        private readonly WestWindContext _context;

        // Constructor to create an instance of the required context class
        internal CategoryServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion

        #region Query
        public List<Category> Category_List()
        {
            IEnumerable<Category> info = _context.Categories
                                        .OrderBy(x => x.CategoryName);
            return info.ToList();
        }
        #endregion

    }
}
