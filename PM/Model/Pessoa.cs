using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Pessoa
    {
        public string cpf { get; set; }
        public string prenome { get; set; }
        public string sobrenome { get; set; }
        public string estado { get; set; }
        public string cidade { get; set; }
        public string pais { get; set; }
        public string rua { get; set; }
        public string cep { get; set; }
    }
}
