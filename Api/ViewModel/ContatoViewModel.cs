using System.ComponentModel.DataAnnotations;
using Domain;

namespace Api.ViewModel
{
    public class ContatoViewModel
    {
        public int Id { get; set; }
        public string Nome { get;  set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public bool Ativo { get;  set; }
    }
}
