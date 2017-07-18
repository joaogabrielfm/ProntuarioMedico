using Model;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RegistrarMedicoController : _BaseController
    {
        public RegistrarMedicoController(string connectionString) : base(connectionString) { }

        public void RegistrarMedico(Medico novoMedico)
        {
            MedicoAccess da = new MedicoAccess(SqlConConnectionString);
            da.InsertMedico(novoMedico);
        }

        public bool verificaPessoa(Medico novoMedico)
        {
            PessoaAccess da = new PessoaAccess(SqlConConnectionString);
            return da.VerificaPessoa(novoMedico.cpf);
        }

        public bool verificaMedico(Medico novoMedico)
        {
            MedicoAccess da = new MedicoAccess(SqlConConnectionString);
            return da.VerificaMedico(novoMedico.cpf);
        }

        public void adicionaPessoa(Medico novoMedico)
        {
            PessoaAccess da = new PessoaAccess(SqlConConnectionString);
            da.InsertPessoa(novoMedico);
        }


    }
}
