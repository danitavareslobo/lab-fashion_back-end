using LabFashion.Models.Enums;

using System.ComponentModel.DataAnnotations;

namespace LabFashion.Models.ViewModels
{
    public class PostUsuario
    {
        [Required(ErrorMessage = "O campo Nome Completo é obrigatório.")]
        public string NomeCommpleto { get; set; }

        [Required(ErrorMessage = "O campo Gênero é obrigatório.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo CPF/CNPJ é obrigatório.")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Tipo de Usuário é obrigatório.")]
        public TipoUsuario TipoUsuario { get; set; }

        [Required(ErrorMessage = "O campo Status é obrigatório.")]
        public Status Status { get; set; }
    }
}
