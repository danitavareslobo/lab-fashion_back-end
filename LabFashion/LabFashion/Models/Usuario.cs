﻿namespace LabFashion.Properties.Models
{
    public class Usuario : Pessoa
    {
        public string Email { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public Status Status { get; set; }
    }
}
