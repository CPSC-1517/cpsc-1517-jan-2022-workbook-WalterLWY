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
    public class SupplierServices
    {
        #region Setup of the Context Connection Variable and Class Constructor

        // Variable to hold an instance of context class
        private readonly WestWindContext _context;

        // Constructor to create an instance of the required context class
        internal SupplierServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion

        #region Query
        public List<Supplier> Category_List()
        {
            IEnumerable<Supplier> info = _context.Suppliers
                                        .OrderBy(x => x.CompanyName);
            return info.ToList();
        }
        #endregion

    }
}
