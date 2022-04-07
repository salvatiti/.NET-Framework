using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //para poder trabajar con dataAnnotations

namespace MVC.Models.ViewModels
{
    public class UserViewModel
    {
        [Required] //para que un campo sea oblitatorio
        [EmailAddress] //valida que sea un email
        [Display(Name ="Correo Electronico")] //el texto que queremos que salga
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string password { get; set; }

        [Display(Name = "Confirmar contraseña")]
        [Compare("password", ErrorMessage ="Las contraseñas no son iguales")] //para comparar con otro campo, Lo compara y si no son iguales lanza el mensaje.
        public string confirmPassword { get; set; }

        [Required]
        public int edad { get; set; }
    }


    public class EditUserViewModel
    {
        public int id { get; set; }

        [Required] //para que un campo sea oblitatorio
        [EmailAddress] //valida que sea un email
        [Display(Name = "Correo Electronico")] //el texto que queremos que salga
        public string email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string password { get; set; }

        [Display(Name = "Confirmar contraseña")]
        [Compare("password", ErrorMessage = "Las contraseñas no son iguales")] //para comparar con otro campo, Lo compara y si no son iguales lanza el mensaje.
        public string confirmPassword { get; set; }

        [Required]
        public int edad { get; set; }
    }
}