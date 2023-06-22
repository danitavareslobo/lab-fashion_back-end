using LabFashion.Models.Enums;

namespace LabFashion.Models
{
    public class Modelo
    {
        public const int NomeModeloMaxLength = 100;

        public int Id { get; set; }
        public string NomeModelo { get; set; }
        public int IdColecaoRelacionada { get; set; }
        
        public Tipo Tipo { get; set; }
        public Layout Layout { get; set; }
    }
}
