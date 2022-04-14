using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;       //this is where the services were coded
using WestWindSystem.Entities;  //this is where the entity definition is coded
using WebApp.Pages.Helpers;           //this is where the Paginator is coded
#endregion


namespace WebApp.Pages.Samples
{
    public class ProductCRUDModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly ProductServices _productServices;
        private readonly CategoryServices _categoryServices;
        private readonly SupplierServices _supplierServices;


        public ProductCRUDModel(ILogger<IndexModel> logger,
            ProductServices productservices,
            CategoryServices categoryservices,
            SupplierServices supplierservices)
        {
            _logger = logger;
            _productServices = productservices;
            _categoryServices = categoryservices;
            _supplierServices = supplierservices;

        }
        #endregion

        #region Feedback and Error Messages

        [TempData]
        public string Feedback { get; set; }

        public bool HasFeedback => !string.IsNullOrWhiteSpace(Feedback);

        public string ErrorMessage { get; set; }

        public bool HasError => !string.IsNullOrWhiteSpace(ErrorMessage);

        #endregion


        [BindProperty(SupportsGet = true)]
        public int? productid { get; set; }

        [BindProperty]
        public Product ProductInfo { get; set; }

        // adding a =new() to the List<T> declaration ensures that your have AT MINIMUM 
        //  a list instance WHICH will be empty until you fill it.
        [BindProperty]
        public List<Category> CategoryList { get; set; } = new();

        [BindProperty]
        public List<Supplier> SupplierList { get; set; } = new();

        public void OnGet()
        {
            // The OnGet executes the first time the page is generated
            // then on each GET request issued by the page (such as on RedirectToPage() PRG)
            
            
            PopulateLists();
            if (productid.HasValue && productid > 0)
            {
                ProductInfo = _productServices.Product_GetById(productid.Value);
            }

        }
        public void PopulateLists()
        {
            CategoryList = _categoryServices.Category_List();
            SupplierList = _supplierServices.Supplier_List();
        }

        public IActionResult OnPostClear()
        {
            Feedback = "";
            //searcharg = null;
            ModelState.Clear();
            return RedirectToPage(new { productid = (int?)null });
        }

        public IActionResult OnPostSearch()
        {
            return RedirectToPage("/Samples/CategoryProducts");
        }

        public IActionResult OnPostNew()
        {
            // Forces client side validation to re-execute
            if (ModelState.IsValid)
            {
                // The Try/Catch error handling is used to catch errors
                //  generated by the execution of the BLL services
                try
                {
                    // Any BindProperty will have the current control contents
                    //  in the property
                    // If you expect to receive a value from the BLL service
                    //  you can capture the value in a local variable 
                    // In our example, I am expecting the new product id to 
                    //  be returned from the BLL services
                    int newproductid = _productServices.Product_AddProduct(ProductInfo);
                    // Always give feedback to the client user
                    Feedback = $"Product id ({newproductid}) has been added to the system";
                    // return needed due to IActionResult
                    return RedirectToPage(new { productId = newproductid });
                }
                catch (ArgumentNullException ex)
                {
                    ErrorMessage = GetInnerException(ex).Message;
                    // Reload ANY lists that are being used on your form
                    // Example: a list (Collection) for a drop down control
                    PopulateLists();
                    // Stay on the "same" page
                    // The idaa is not to "Leave" the current request
                    // This is required because you are using IActionResult as 
                    //  a return datatype for this method
                    return Page();
                }
                catch (Exception ex)
                {
                    ErrorMessage = GetInnerException(ex).Message;
                    // Reload ANY lists that are being used on your form
                    // Example: a list (Collection) for a drop down control
                    PopulateLists();
                    // Stay on the "same" page
                    // The idaa is not to "Leave" the current request
                    // This is required because you are using IActionResult as 
                    //  a return datatype for this method
                    return Page();
                }
            }
            else
            {
                // If you are using ModelState AND are in need of re-populating lists 
                // (for select or group of radiobuttons, etc)
                // You will need to re-obtain the lists.
                PopulateLists();
            }
            return Page();
        }

        public IActionResult OnPostUpdate()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int rowaffected = _productServices.Product_UpdateProduct(ProductInfo);
                    if (rowaffected > 0)
                    {
                        Feedback = $"Product id ({rowaffected}) has been updated to the system";
                    }
                    else
                    {
                        Feedback = "No Product was affected. Refresh search and try again.";
                    }
                    return RedirectToPage(new { productId = productid });
                }
                catch (ArgumentNullException ex)
                {
                    ErrorMessage = GetInnerException(ex).Message;
                    PopulateLists();
                    return Page();
                }
                catch (Exception ex)
                {
                    ErrorMessage = GetInnerException(ex).Message;
                    PopulateLists();
                    return Page();
                }
            }
            else
            {
                // If you are using ModelState AND are in need of re-populating lists 
                // (for select or group of radiobuttons, etc)
                // You will need to re-obtain the lists.
                PopulateLists();
            }
            return Page();
        }

        public IActionResult OnPostDelete()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // This is a logical delete (really an update)
                    int rowaffected = _productServices.Product_DeleteProduct(ProductInfo);
                    if (rowaffected > 0)
                    {
                        Feedback = $"Product id ({rowaffected}) has been discontinued to the system";
                    }
                    else
                    {
                        Feedback = "No Product was affected. Refresh search and try again.";
                    }
                    return RedirectToPage(new { productId = productid });
                }
                catch (ArgumentNullException ex)
                {
                    ErrorMessage = GetInnerException(ex).Message;
                    PopulateLists();
                    return Page();
                }
                catch (Exception ex)
                {
                    ErrorMessage = GetInnerException(ex).Message;
                    PopulateLists();
                    return Page();
                }
            }
            else
            {
                // If you are using ModelState AND are in need of re-populating lists 
                // (for select or group of radiobuttons, etc)
                // You will need to re-obtain the lists.
                PopulateLists();
            }
            return Page();
        }

        private Exception GetInnerException(Exception ex)
        {
            // Drill down to the REAL ERROR message
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }
    }
}