using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking; // for entity entry
#endregion

namespace WestWindSystem.BLL
{
    public class ProductServices
    {
        #region Setup of the Context Connection Variable and Class Constructor

        // Variable to hold an instance of context class
        private readonly WestWindContext _context;

        // Constructor to create an instance of the required context class
        internal ProductServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion

        #region Queries
        // Filter search returning all products of the requested category (CategoryID)
        public List<Product> Product_CategoryProduct(int categoryid)
        {
            IEnumerable<Product> info = _context.Products.
                                Where(x => x.CategoryID == categoryid)
                                .OrderBy(x => x.CategoryID);
            return info.ToList();
        }

        // For the CRUD you are maintaining a SINGLE row on the database
        // this row will be obtained by the pKey value of the row
        public Product Product_GetById(int productid)
        {
            // Where is matching on the primary key field
            // Linq is by default expecting to return 0, 1 or more rows 
            //  When your receive variable (product) expects ONLY a SINGLE
            //  instance of the class (Product), you will "Tell" Linq
            //  to return the "first" instance found OR a "Default" value
            //  of the variable data type (is a class thus it will be null
            //      for the object instance) 

            Product product = _context.Products
                                .Where (x => x.ProductID == productid)
                                .FirstOrDefault();
            return product;
        }
        #endregion

        #region Add, Update, Delete
        // Adding a record to your database may require you to 
        //  verify the data does not already exist on the database
        // This can be done using a Linq query and a given set of 
        //  verification field. 
        // Example: for this product insertion we will verify 
        //  that there is no product record on the database with 
        //  the same product name and quantity per unit from the 
        //  same supplier. If so, throw an Exception.

        // One MUSt know whether the table has a identity pKey or not
        // If the table pKey is NOT an identity then you MUST ensure 
        //  that the incoming instance of the row HAS a pKey value
        // If the table pKey is an identity then the database will 
        //  generate that value and make it assessable to you AFTER
        //  the data has been committed. 

        // Product pKey is an identity attribute
        // This method optionally sends the new identity value back to the 
        //  web page (PageModel call statement)

        public int Product_AddProduct(Product item)
        {
            // This is an optional sample of validation of incoming data
            Product exists = _context.Products
                            .Where(x => x.ProductName.Equals(item.ProductName) &&
                                        x.QuantityPerUnit.Equals(item.QuantityPerUnit) &&
                                        x.SupplierID == item.SupplierID)
                            .FirstOrDefault();
            if (exists != null)
            {
                throw new Exception($"{item.ProductName} with a size of {item.QuantityPerUnit}" +
                    $"from the selected supplier is already on file");
            }
            
            // stage the data in local memory to be submitted to the database for 
            //  storage
            // a) What DbSet
            // b) the action
            // c) Indicate the data involved.

            // IMPORTANT:   the data is in LOCAL memory, it has NOT!!! yet been sent 
            //              to the database. 
            //              THEREFORE, at this time, there is NO!!! primary key value (except)
            //              for the system default (numeric -> 0) 
            _context.Products.Add(item);

            // commit the LOCAL data to the database
            _context.SaveChanges();
            
            // After the commit, your pKey value will NOW be available to you
            return item.ProductID;
        }

        // Update
        // Update can also have design considerations for validation
        // Update may request that you check the record of interest is still 
        //  on the database

        public int Product_UpdateProduct(Product item)
        {
            // For an update, you must have the pKey value on your instance
            //  if not, it will not work

            // This technique returns an instance (object)
/*            Product exists = _context.Products
                            .Where (x => x.ProductID.Equals(item.ProductID))
                            .FirstOrDefault();
*/
            // This technique does the search BUT returns only a boolean of success
            bool exists = _context.Products.Any(x => x.ProductID == item.ProductID);

            // DEPENDING on which technique you use, your error text will be differece
            //  ONE: if (exists == null) {...}
            if (!exists)
            {
                throw new Exception($"{item.ProductName} with a size of {item.QuantityPerUnit}" +
                    $"from the selected supplier is NOT on file");
            }

            // Stage the update
            EntityEntry<Product> updating = _context.Entry(item);
            // Flag the entity to be modified
            updating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            // During the commit, SaveChanges() return the number of rows affected
            return _context.SaveChanges();
        }

        public int Product_DeleteProduct(Product item)
        {
            // For an delete, you must have the pKey value on your instance
            //  if not, it probably will not work as expected

            // This technique returns an instance (object)
            /*            Product exists = _context.Products
                                        .Where (x => x.ProductID.Equals(item.ProductID))
                                        .FirstOrDefault();
            */
            // This technique does the search BUT returns only a boolean of success
            bool exists = _context.Products.Any(x => x.ProductID == item.ProductID);

            // DEPENDING on which technique you use, your error text will be differece
            //  ONE: if (exists == null) {...}
            if (!exists)
            {
                throw new Exception($"{item.ProductName} with a size of {item.QuantityPerUnit}" +
                    $"from the selected supplier is NOT on file");
            }

            // Removing a record from your database maybe a 
            // a) Physical act 
            // OR
            // b) Logical act

            // a) if you wish the record to be "physically be removed from the database 
            //      you will use the staging of .Deleted
            //    if the record being removed from the database is a "parent" record, 
            //      (refereneced in a foreign key), the delete WILL FAIL in a relational 
            //      database if there are existing "children" or the record 
            //    sql "parent records cannot be deleted if children exist"
            //    the decision to automatically remove "children" is a system design decision

            // Stage the Physical Delete
            // EntityEntry<Product> deleting = _context.Entry(item);
            // Flag the entity to be deleted
            // deleting.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            // b) Logical delete
            //    This is where you do not or cannot phyically remove a record from 
            //    the database. 
            //    The decision is based on existing best practice business rules OR
            //    set by government regulations
            //    This type of delete is done so the "flagged" data is NOT used in
            //    daily processing

            //  this type of delete will actually be an update the attribute (property)
            //   of the record
            //  Look for attributes such as Active, Discontinued, a special date ReleaseDate

            // Product is a logical delete (Discontinued = true;)

            // Stage the Logical Delete
            item.Discontinued = true;
            EntityEntry<Product> updating = _context.Entry(item);
            // Flag the entity to be deleted
            updating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            // During the commit, SaveChanges() return the number of rows affected
            return _context.SaveChanges();
        }

        #endregion

    }
}
