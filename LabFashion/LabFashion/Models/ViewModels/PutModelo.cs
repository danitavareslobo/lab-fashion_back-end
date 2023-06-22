using LabFashion.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LabFashion.Models.ViewModels
{
    public class PutModelo
    {
        [IgnoreDataMember]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome do Modelo é obrigatório.")]
        public string NomeModelo { get; set; }

        [Required(ErrorMessage = "O campo Id da Coleção Relacionada é obrigatório.")]
        public int IdColecaoRelacionada { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
        public Tipo Tipo { get; set; }

        [Required(ErrorMessage = "O campo Layout é obrigatório.")]
        public Layout Layout { get; set; }
    }
}
