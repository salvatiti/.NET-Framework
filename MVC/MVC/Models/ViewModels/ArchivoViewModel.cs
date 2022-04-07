﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModels
{
    public class ArchivoViewModel
    {
        [Required]
        [DisplayName("Mi Archivo1")]
        public HttpPostedFileBase Archivo1 { get; set; }

        [Required]
        [DisplayName("Mi Archivo2")]
        public HttpPostedFileBase Archivo2 { get; set; }

        [Required]
        [DisplayName("Mi Cadena")]
        public string Cadena { get; set; }
    }
}