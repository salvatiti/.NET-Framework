using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //abrir conexion a DB
            using (EjemploEntityFrameworkEntities db = new EjemploEntityFrameworkEntities())
            {
                var lista = db.Persona; //asignamos a la variable lista la tabla Persona

                //INSERT
                /* //Se crea una nueva instancia de persona
                 Persona oPersona = new Persona();
                 oPersona.nombre = "Pepe";
                 oPersona.edad = "11";
                 oPersona.idSexo = 1;
                 
                 //Se agrega a la DB
                 db.Persona.Add(oPersona);
                 //Y para que se haga efectivo el cambio, hay que aplicar SaveChanges(), si no ese nuevo valor se queda en el limbo
                 db.SaveChanges();*/

                //UPDATE
                // Persona oPersona = db.Persona.Find(1); si solo queremos buscar por id, se puede poner el Find()
                Persona oPersona = db.Persona.Where(p => p.id == 1).First(); //Para buscar por otro campo diferente seria con Where()
                oPersona.nombre = "Antonia";
                db.Entry(oPersona).State = System.Data.Entity.EntityState.Modified; //Para decirle al Entity Framework que este objeto tuvo cambios
                db.SaveChanges();

                //DELETE
                oPersona = db.Persona.Where(p => p.id == 4).First();
                db.Persona.Remove(oPersona);
                //db.Entry(oPersona).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();


                foreach (var persona in lista)
                {
                    Console.WriteLine(persona.nombre);
                }
               
            }
            Console.Read();
        }
    }
}
