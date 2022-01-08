using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1;


namespace webapplication3.Data
{
     public class RestaurantDbContext : DbContext
    { 
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options):base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }

}
