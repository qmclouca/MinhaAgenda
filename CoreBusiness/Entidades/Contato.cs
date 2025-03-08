using SQLite;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness.Entidades
{
    public class Contato
    {
        public Contato()
        {
            
        }

        public Contato(string nome, string? fone, string? email, string endereco)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Fone = fone;
            Email = email;
            Endereco = endereco;
        }

        public Contato(Guid id, string nome, string? fone, string? email, string endereco)
        {
            Id = id;
            Nome = nome;
            Fone = fone;
            Email = email;
            Endereco = endereco;
        }

        [Required]
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        public string? Fone { get; set; } = string.Empty;
        [Required]
        public string? Email { get; set; } = string.Empty;
        public string? Endereco { get; set; } = string.Empty;
    }
}
