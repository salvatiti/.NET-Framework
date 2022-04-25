using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroToHero.Data.Models;

namespace Data.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll(); //Metodo para obtener todos los restaurantes(InMemoryRestaurantData)
        Restaurant Get(int id); //Metodo para obtener un restaurante(InMemoryRestaurantData)
        void Add(Restaurant newRestaurant); //Metodo para agregar un restaurante(InMemoryRestaurantData)
        void Update(Restaurant restaurant); //Metodo para actualizar un restaurante(InMemoryRestaurantData)
        void Delete(int id); //Metodo para eliminar un restaurante(InMemoryRestaurantData)
    }
}
