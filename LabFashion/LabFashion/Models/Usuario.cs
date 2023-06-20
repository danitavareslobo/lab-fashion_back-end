using LabFashion.Models.Enums;

namespace LabFashion.Models
{
    public class Usuario : Pessoa
    {
        public const int EmailMaxLength = 100;


        public string Email { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public Status Status { get; set; }
    }
}
