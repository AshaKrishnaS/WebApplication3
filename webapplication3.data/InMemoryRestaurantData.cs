using System.Collections.Generic;
using ClassLibrary1;
using System.Linq;

namespace webapplication3.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { id = 1, name = "Scott's Pizza", location = "Maryland", Cuisine = CuisineType.Italian },
               new Restaurant { id = 2, name = "A Pizza", location = "M", Cuisine = CuisineType.Mexican },
                  new Restaurant { id = 3, name = "b", location = "b", Cuisine = CuisineType.Italian },
                 new Restaurant { id = 4, name = "c", location = "c", Cuisine = CuisineType.Italian }
            };
        }
        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.id == id);
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.id = restaurants.Max(r => r.id) + 1;
            return newRestaurant;
        }
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.id == updatedRestaurant.id);
                if(restaurant!=null)
            {
                restaurant.name = updatedRestaurant.name;
                restaurant.location = updatedRestaurant.location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;

            }
            return restaurant;
        }
        public int Commit()
        {
            return 0;

        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name=null)
        {
            return  from res in restaurants
                    where string.IsNullOrEmpty(name ) || res.name.StartsWith(name) orderby res.name 
                   select res;
            //return restaurants.Where(w => w.name == "b").OrderByDescending(o => o.name);


        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.id == id);
            if(restaurant!=null)
            {
                restaurants.Remove(restaurant);

            }
            return null;
        }
        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}
