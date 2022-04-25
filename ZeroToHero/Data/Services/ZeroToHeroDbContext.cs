using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroToHero.Data.Models;

namespace Data.Services
{
    public class ZeroToHeroDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; } //Restaurants es la tabla que va a crear, con los atributos que tenga la clase Restaurant
    }
}
