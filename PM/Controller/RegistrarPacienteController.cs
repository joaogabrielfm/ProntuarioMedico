using Model;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RegistrarPacienteController : _BaseController
    {
        public RegistrarPacienteController(string connectionString) : base(connectionString) { }

        public void RegistrarPaciente(Paciente paciente)
        {
            PacienteAccess da = new PacienteAccess(SqlConConnectionString);
            da.InsertPaciente(paciente);
        }

        public bool verificaPessoa(Paciente paciente)
        {
            PessoaAccess da = new PessoaAccess(SqlConConnectionString);
            return da.VerificaPessoa(paciente.cpf);
        }

        public bool verificaPaciente(Paciente paciente)
        {
            PacienteAccess da = new PacienteAccess(SqlConConnectionString);
            return da.VerificaPaciente(paciente.cpf);
        }

        public void adicionaPessoa(Paciente paciente)
        {
            PessoaAccess da = new PessoaAccess(SqlConConnectionString);
            da.InsertPessoa(paciente);
        }


    }
}
