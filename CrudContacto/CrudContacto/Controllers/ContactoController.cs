using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration; //Para la conexion a la DB
using CrudContacto.Models; //Para poder referenciar la clase Contacto que esta en Model
using System.Data.SqlClient; //conexion SQL
using System.Data;

namespace CrudContacto.Controllers
{
    public class ContactoController : Controller
    {
        //cadena de conexion a la DB en Web.config -- connectionstring
        private static string conexionDB = ConfigurationManager.ConnectionStrings["cadena"].ToString();

        private static List<Contacto> listaContactos = new List<Contacto>();


        [HttpGet]
        public ActionResult Inicio()
        {
            listaContactos = new List<Contacto>(); //Elimina todo lo que tenga la lista y luego rellena
            using (SqlConnection conexion = new SqlConnection(conexionDB))
            {
                //ejecuta un comando especificando nuestra cadena de conexion (SQLCONNECTION)
                SqlCommand comando = new SqlCommand("select * from Contacto", conexion);
                comando.CommandType = CommandType.Text;
                conexion.Open();

                using (SqlDataReader dr = comando.ExecuteReader())//leer los resultados que esta ejecutando nuestro comando
                {
                    while (dr.Read())
                    {
                        Contacto nuevoContacto = new Contacto();
                        nuevoContacto.IdContacto = Convert.ToInt32(dr[0]);
                        nuevoContacto.Nombre = dr[1].ToString();
                        nuevoContacto.Apellido = dr[2].ToString();
                        nuevoContacto.Telefono = dr[3].ToString();
                        nuevoContacto.Email = dr[4].ToString();
                        listaContactos.Add(nuevoContacto);
                    }
                }
            }
            return View(listaContactos);
        }


        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Contacto contacto)
        {
            using (SqlConnection conexion = new SqlConnection(conexionDB))
            {
                //ejecuta un comando especificando nuestra cadena de conexion (SQLCONNECTION)
                SqlCommand comando = new SqlCommand("Registrar", conexion);
                comando.Parameters.AddWithValue("Nombre", contacto.Nombre);
                comando.Parameters.AddWithValue("Apellido", contacto.Apellido);
                comando.Parameters.AddWithValue("Telefono", contacto.Telefono);
                comando.Parameters.AddWithValue("Email", contacto.Email);
                comando.CommandType = CommandType.StoredProcedure; //Registrar es el procedimiento almacenado que hay en la DB
                conexion.Open();
                comando.ExecuteNonQuery(); //ejecutar el comando
               
            }
            return RedirectToAction("Inicio","Contacto");
        }

        public ActionResult Editar(int? idContacto) //el id puede ser nulo con ?
        {
            if(idContacto == null)
              return RedirectToAction("Inicio", "Contacto"); //Si el id es nulo redirige a la pagina de Inicio

            //si no es null me devuelve el contacto de mi listaContactos donde el idContacto de la lista es igual al idContacto que se le pase
            Contacto contacto = listaContactos.Where(c => c.IdContacto == idContacto).First();
            
            return View(contacto);
        }


        [HttpPost]
        public ActionResult Editar(Contacto contacto)
        {
            using (SqlConnection conexion = new SqlConnection(conexionDB))
            {
                //ejecuta un comando especificando nuestra cadena de conexion (SQLCONNECTION)
                SqlCommand comando = new SqlCommand("Editar", conexion);
                comando.Parameters.AddWithValue("idContacto", contacto.IdContacto);
                comando.Parameters.AddWithValue("Nombre", contacto.Nombre);
                comando.Parameters.AddWithValue("Apellido", contacto.Apellido);
                comando.Parameters.AddWithValue("Telefono", contacto.Telefono);
                comando.Parameters.AddWithValue("Email", contacto.Email);
                comando.CommandType = CommandType.StoredProcedure; //Registrar es el procedimiento almacenado que hay en la DB
                conexion.Open();
                comando.ExecuteNonQuery(); //ejecutar el comando

            }
            return RedirectToAction("Inicio", "Contacto");
        }

        public ActionResult Eliminar(int? idContacto) //el id puede ser nulo con ?
        {
            if (idContacto == null)
                return RedirectToAction("Inicio", "Contacto"); //Si el id es nulo redirige a la pagina de Inicio

            //si no es null me devuelve el contacto de mi listaContactos donde el idContacto de la lista es igual al idContacto que se le pase
            Contacto contacto = listaContactos.Where(c => c.IdContacto == idContacto).First();

            return View(contacto);
        }

        [HttpPost]
        public ActionResult Eliminar(String IdContacto)
        {
            using (SqlConnection conexion = new SqlConnection(conexionDB))
            {
                //ejecuta un comando especificando nuestra cadena de conexion (SQLCONNECTION)
                SqlCommand comando = new SqlCommand("Eliminar", conexion);
                comando.Parameters.AddWithValue("idContacto", IdContacto);
                comando.CommandType = CommandType.StoredProcedure; //Registrar es el procedimiento almacenado que hay en la DB
                conexion.Open();
                comando.ExecuteNonQuery(); //ejecutar el comando

            }
            return RedirectToAction("Inicio", "Contacto");
        }
    }
}