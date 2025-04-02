using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Contato
    {
        [Key]
        [Required]
        public int Id { get; private set; }
        [Required(ErrorMessage ="O campo nome é obrigatório")]
        public string Nome {  get; private set; }
        [Required(ErrorMessage ="O campo data de nascimento é obrigatório")]
        public DateTime DataNascimento { get; private set; }
        [Required(ErrorMessage ="O campo sexo é obrigatório")]
        public char Sexo { get; private set; }
        public bool Ativo { get; private set; }
        [NotMapped]
        public int Idade { get
            {
                DateTime hoje = DateTime.Today; 
                int idade = DateTime.Today.Year - DataNascimento.Year;
                if (DataNascimento.Date > hoje.AddYears(-idade)) idade--;

                return idade;
            } 
        }
        private Contato()
        {

        }
        public Contato(string nome, DateTime dataNascimento, char sexo, bool ativo = true)
        {
            if (nome == null) throw new ArgumentNullException("O campo nome é obrigatório");
            Nome = nome;

            if (sexo == null) throw new ArgumentNullException("O campo sexo é obrigatório");
            Sexo = sexo;

            if(dataNascimento == null) throw new ArgumentNullException("O campo data de nascimento é obrigatório");

            if (DataNascimento > DateTime.Today) throw new Exception("A data de nascimento não pode ser maior do que a data de hoje");
            DataNascimento = dataNascimento;

            if (Idade < 18) throw new Exception("A idade do contato deve ser maior de 18");

            Ativo = ativo;
        }

        public Contato MapeiaParaViewModel()
        {
            var contato = new Contato(Nome, DataNascimento, Sexo, Ativo);
            return contato;
        }

        public void ModificarContato(string nome, DateTime dataNascimento, char sexo, bool ativo)
        {
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Ativo = ativo;
        }
    }
}
