using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using webapplication3.Data;
using ClassLibrary1;


namespace WebApplication3.Pages.RESTAURANT
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlhelper;

        [BindProperty]
        public Restaurant Restaurant { get ; set ; }

        public IEnumerable< SelectListItem >Cuisines{ get; set; }
        public EditModel(IRestaurantData restaurantData,IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlhelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlhelper.GetEnumSelectList<CuisineType>();
            if(restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
               
            }
            
            if(Restaurant==null)
            {
                return RedirectToPage("./NotFound");

            }
            return Page();

        }
        public IActionResult onPost(int? restaurantId)
        {
            if(!ModelState.IsValid)
            {
                Cuisines = htmlhelper.GetEnumSelectList<CuisineType>();

                return Page();

            }
            if(Restaurant.id>0)
            {
                restaurantData.Update(Restaurant);
            }
           else
            {
                restaurantData.Add(Restaurant);

            }
            restaurantData.Commit();
            TempData["Message"] = "Restaurant Saved !";
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.id });

        }


    }
}
