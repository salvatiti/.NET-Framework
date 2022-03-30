using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudContacto.Models
{
    public class Contacto
    {
        //clase que hace referencia a nuestra tabla en la DB, con todos los campos que tenemos en dicha tabla
        public int IdContacto { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}