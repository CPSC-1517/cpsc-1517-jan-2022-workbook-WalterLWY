using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;       // this is where the services were coded
using WestWindSystem.Entities;  // this is where the entity definition is coded
using WebApp.Pages.Helpers;     // this is where the Paginator is coded
#endregion

namespace WebApp.Pages.Samples
{
    public class PartialFilterSearchModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly TerritoryServices _territoryServices;
        private readonly RegionServices _regionServices;

        public PartialFilterSearchModel(ILogger<IndexModel> logger, 
            TerritoryServices territoryservices,
            RegionServices regionServices)
        {
            _logger = logger;
            _territoryServices = territoryservices;
            _regionServices = regionServices;

        }
        #endregion

        [TempData]
        public string Feedback { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searcharg { get; set; }

        public List<Territory> TerritoryInfo { get; set; }

        [BindProperty]
        public List<Region> RegionList { get; set; } = new();

        #region Paginator
        // My desired page size 
        private const int PAGE_SIZE = 5;
        // Be able to hold an instance of the Paginator
        public Paginator Pager { get; set; }
        #endregion

        public void OnGet(int? currentPage)
        {
            // Using a Paginator with your query

            // OnGet will have a parameter (Request query string) that receives the
            //  current page number. On the initial load of the page, this value
            //  will be null.

            // Obtain the data list for the Region dropdownlist (select tag)
            RegionList = _regionServices.Region_List();

            if (!string.IsNullOrWhiteSpace(searcharg))
            {
                // Setting up for using the Paginator only needs to be done if 
                //  a query is executing

                // Determine the current page number
                int pagenumber = currentPage.HasValue ? currentPage.Value : 1;

                // Setup the current state of the paginator (sizing)
                PageState current = new(pagenumber, PAGE_SIZE);

                // Temporary local integer to hold the results of the query's total collection size
                //  this will be need by the Paginator during the paginator's execution
                int totalcount;

                // We need to pass paging data into our query so that efficiencies in the 
                //  system will ONLY return the amount of records to actually be display
                //  on the browser page

                TerritoryInfo = _territoryServices.GetByPartialDesciption(searcharg,
                                    pagenumber, PAGE_SIZE, out totalcount);

                // Create the needed Paginator intance
                Pager = new Paginator(totalcount, current);
            }

        }

        public IActionResult OnPostFetch()
        {
            if (string.IsNullOrWhiteSpace(searcharg))
            {
                Feedback = "Required: Search Argument is empty";
            }
            return RedirectToPage(new { searcharg = searcharg });
        }

        public IActionResult OnPostClear()
        {
            Feedback = "";
            // seracharg = null;
            ModelState.Clear();
            return RedirectToPage(new { searcharg = (string?)null });
        }

        public IActionResult OnPostNew()
        {
            return RedirectToPage("/Samples/ReceivingPage");
        }


    }
}
