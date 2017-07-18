using System;
using Model;
using DatabaseAccess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RegistrarMedicamentoController : _BaseController
    {
        public RegistrarMedicamentoController(string connectionString) : base(connectionString){ }

        public bool registrarMedicamento()
        {
            MedicamentoAccess medicamento = new MedicamentoAccess(SqlConConnectionString);
            return true;
        }

        public void adicionaMedicamento(Medicamento medicamento)
        {
            MedicamentoAccess newMedicamento = new MedicamentoAccess(SqlConConnectionString);
            newMedicamento.InsertMedicamento(medicamento);
        }
    }
}
