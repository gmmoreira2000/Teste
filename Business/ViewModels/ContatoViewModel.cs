using System.ComponentModel.DataAnnotations;

namespace Business.ViewModels
{
    public class ContatoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public bool Ativo { get; set; }
    }
}
