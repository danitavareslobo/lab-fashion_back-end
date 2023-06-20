using LabFashion.Models.Enums;

namespace LabFashion.Models.ViewModels
{
    public class PostUsuario
    {
        public string NomeCommpleto { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CpfCnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public Status Status { get; set; }
    }
}
