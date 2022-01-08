using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1
{
    public class Restaurant 
    {
        public int id { get; set; }
        
        [Required,StringLength(80)]
        
        public string name { get; set; }

        [Required,StringLength(255)]
        public string location { get; set; }

        
        public CuisineType Cuisine { get; set; }

    }

}
