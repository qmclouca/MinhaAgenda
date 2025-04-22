using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Entidades
{
    public class Observacoes
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int ContatoId { get; set; }
        public string? Descricao { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;

    }
}
