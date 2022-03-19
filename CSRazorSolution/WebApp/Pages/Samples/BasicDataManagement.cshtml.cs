using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicDataManagementModel : PageModel
    {
        // create bound properties that can be directly tied to a control on the form
        // bound properties have the data automatically transferred from the control 
        //  into the property
        [BindProperty]
        public int Num { get; set; } // this is tied to the control use the asp-for

        [BindProperty]
        public string FavouriteCourse { get; set; }

        [BindProperty]
        public string Comments { get; set; }

        // Annotation TempData is required IF your are processing multiple requests (ONPOST)
        //      followed by (OnGet) retain data within the property        
        // [TempData]
        public string Feedback { get; set; }


        public void OnGet()
        {
            // execute for a Get request
            // the first time the page is requested an automatic Get request is sent
            // execellent "event" to use to do any initialization to your web page display
            //  as the page is shown for the first time
        }

        public void OnPost()
        {
            // process the OnPost request of the form (method="post")
            // the returnedtype can be void or IActionResult
            // OnPost request is the request from a <button> that has NOT indicated a
            //  specifc process Post using the asp-page-handler
            // logic that you wish to accomplish should be isolated to the actions
            //  desired for the button
            Feedback = $"Number {Num}, Course: {FavouriteCourse}, Comments: {Comments}";
        }

        public void OnPostA()
        {
            // process the OnPost request of the form (method="post")
            // this method is called due to the helper-tag on the form button
            // the "string" used on the helper-tag asp-page-handler="string" is 
            //  add to the OnPost method name 
            Feedback = $"Button A was pressed";
        }

        public void OnPostB()
        {
            // process the OnPost request of the form (method="post")
            // this method is called due to the helper-tag on the form button
            // the "string" used on the helper-tag asp-page-handler="string" is 
            //  add to the OnPost method name 
            Feedback = $"Button B was pressed";
        }

    }
}
