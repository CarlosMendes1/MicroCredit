using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCredit.Domain.Entities
{
    public class User
    {
        public string Nome { get; set; }
        public string NIF { get; set; }
        public string Morada { get; set; }
        public decimal RendimentoMensal { get; set; }
    }
}
