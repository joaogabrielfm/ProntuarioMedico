using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PlanoSaude
    {
        public int CodPlano { get; set; }
        public DateTime Data_contratacao { get; set; }
        public string Nome_operadora { get; set; }
        public float Valor_atualizado { get; set; }
        public DateTime Carencia { get; set; }
        public DateTime Data_reajuste { get; set; }
        public string Tipo_plano { get; set; }
        public float Valor_mensal { get; set; }
        public string Nome { get; set; }
    }
}
