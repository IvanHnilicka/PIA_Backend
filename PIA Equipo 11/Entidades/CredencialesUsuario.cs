﻿using System.ComponentModel.DataAnnotations;

namespace PIA_Equipo_11.Entidades
{
    public class CredencialesUsuario
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
