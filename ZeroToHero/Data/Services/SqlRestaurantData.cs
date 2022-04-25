using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroToHero.Data.Models;

namespace Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly ZeroToHeroDbContext db;

        public SqlRestaurantData(ZeroToHeroDbContext db)
        {
            this.db = db;
        }
        
        public void Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id); //Devuelve el primer restaurante que coincida con el id
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in db.Restaurants  //Devuelve todos los restaurantes de la base de datos
                   orderby r.Name
                   select r;
        }

        public void Update(Restaurant restaurant)
        {
            var entry = db.Entry(restaurant); //Hay un objeto que esta almacenado en la base de datos
            entry.State = EntityState.Modified; // Esto es para que se modifique el objeto que esta almacenado en la base de datos
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurant = db.Restaurants.Find(id); // Busca el restaurante que coincida con el id
            db.Restaurants.Remove(restaurant); // Elimina el restaurante
            db.SaveChanges();
        }
    }
}
