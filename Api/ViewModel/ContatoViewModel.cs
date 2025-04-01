using System.ComponentModel.DataAnnotations;
using Domain;

namespace Api.ViewModel
{
    public class ContatoViewModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get;  set; }
        [Required(ErrorMessage = "O campo data de nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "O campo sexo é obrigatório")]
        public char Sexo { get; set; }
        public bool Ativo { get;  set; }
        public Contato MapeiaParaEntidade()
        {
            var contato = new Contato(Nome, DataNascimento, Sexo, Ativo);
            return contato;
        }
    }
}
