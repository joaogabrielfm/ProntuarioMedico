using Model;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RegistrarLaboratoristaController : _BaseController
    {
        public RegistrarLaboratoristaController(string connectionString) : base(connectionString) { }

        public void RegistrarLaboratorista(Laboratorista novoLaboratorista)
        {
            LaboratoristaAccess da = new LaboratoristaAccess(SqlConConnectionString);
            da.InsertLaboratorista(novoLaboratorista);
        }

        public bool verificaPessoa(Laboratorista novoLaboratorista)
        {
            PessoaAccess da = new PessoaAccess(SqlConConnectionString);
            return da.VerificaPessoa(novoLaboratorista.cpf);
        }

        public bool verificaLaboratorista(Laboratorista novoLaboratorista)
        {
            LaboratoristaAccess da = new LaboratoristaAccess(SqlConConnectionString);
            return da.VerificaLaboratorista(novoLaboratorista.cpf);
        }

        public void adicionaPessoa(Laboratorista novoLaboratorista)
        {
            PessoaAccess da = new PessoaAccess(SqlConConnectionString);
            da.InsertPessoa(novoLaboratorista);
        }


    }
}
