namespace LabFashion.Properties.Models
{
    public abstract class Pessoa
    {
        public int Id { get; set; }
        public string NomeCommpleto { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CpfCnpj { get; set; }
        public string Telefone { get; set; }
    }
}
