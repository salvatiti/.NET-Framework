using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.TableViewModels
{
    public class UserTableViewModel
    {
        //Clase para mostrar la informacion
        public int id { get; set; }
        public string email { get; set; }
        public Nullable<int> edad { get; set; }
    }
}