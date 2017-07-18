using System;
using Model;
using DatabaseAccess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    class RegistrarHorarioMedicamentoController : _BaseController
    {
        public RegistrarHorarioMedicamentoController(string connectionString) : base(connectionString){ }

        public bool registrarHorarioMedicamento()
        {
            HorarioMedicamentoAccess horario = new HorarioMedicamentoAccess(SqlConConnectionString);
            return true;
        }

        public void adicionaHorarioMedicamento(HorarioMedicamento horario)
        {
            MedicamentoAccess newMedicamento = new MedicamentoAccess(SqlConConnectionString);
            newMedicamento.InsertMedicamento(horario);
        }
    }
}
