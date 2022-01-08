namespace webapplication3.Data
   
{
using System.Collections.Generic;
    using ClassLibrary1;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class SqlRestaurantData : IRestaurantData
{
        private readonly RestaurantDbContext db;

        public SqlRestaurantData(RestaurantDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

    public int Commit()
    {
                return db.SaveChanges();
                
    }

    public Restaurant Delete(int id)
    {
            var restuarant = GetById(id);
            if(restuarant!=null)
            {
                db.Restaurants.Remove(restuarant);
            }
            return restuarant;
    }

    public Restaurant GetById(int id)
    {
            return db.Restaurants.Find(id);
    }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }

        

    public IEnumerable<Restaurant> GetRestaurantsByName(string name)
    {
            var query = from r in db.Restaurants
                        where r.name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.name
            select r;
            return query;

    }

    public Restaurant Update(Restaurant updatedRestaurant)
    {
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
    }
}
}
