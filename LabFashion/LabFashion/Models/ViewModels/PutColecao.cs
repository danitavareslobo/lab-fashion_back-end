using LabFashion.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LabFashion.Models.ViewModels
{
    public class PutColecao
    {
        [IgnoreDataMember]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome da Coleção é obrigatório.")]
        public string NomeColecao { get; set; }

        [Required(ErrorMessage = "O campo Id do Responsavel é obrigatório.")]
        public int IdResponsavel { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo Orçamento é obrigatório.")]
        public double Orcamento { get; set; }

        [Required(ErrorMessage = "O campo Ano de Lançamento é obrigatório.")]
        public DateTime AnoLancamento { get; set; }

        [Required(ErrorMessage = "O campo Estação é obrigatório.")]
        [EnumDataType(typeof(Estacao), ErrorMessage = "O campo Estação é inválido.")]
        public Estacao Estacao { get; set; }

        [Required(ErrorMessage = "O campo Estado no Sistema é obrigatório.")]
        [EnumDataType(typeof(EstadoSistema), ErrorMessage = "O campo Estado no Sistema é inválido.")]
        public EstadoSistema EstadoSistema { get; set; }
    }
}
