using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using webapplication3.Data;
using webapplication3;


namespace WebApplication3.Pages.RESTAURANT
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        
        [BindProperty(SupportsGet =true)]
       public string SearchTerm { get; set; }

        public ListModel ( IConfiguration config , IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData= restaurantData;
        }
        public void OnGet()
        {
           
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
