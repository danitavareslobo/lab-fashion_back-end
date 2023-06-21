namespace LabFashion.Models
{
    public abstract class Pessoa
    {

        public const int NomeMaxLength = 100;
        public const int GeneroMaxLength = 10;
        public const int CpfCnpjMaxLength = 21;
        public const int TelefoneMaxLength = 15;


        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CpfCnpj { get; set; }
        public string Telefone { get; set; }
    }
}
