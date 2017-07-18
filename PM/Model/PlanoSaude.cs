using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PlanoSaude
    {
        public string cpf { get; set; }
        public int codPlano { get; set; }
        public DateTime dataContratacao { get; set; }
        public string nomeOperadora { get; set; }
        public float valorAtualizado { get; set; }
        public DateTime carencia { get; set; }//arrumar aqui
        public DateTime dataReajuste { get; set; } // arrumar aqui
        public string tipoPlano { get; set; }
        public float valorMensal { get; set; }
        public string nome { get; set; }
    }
}
