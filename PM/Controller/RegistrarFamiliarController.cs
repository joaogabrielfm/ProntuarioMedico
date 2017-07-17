using Model;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RegistrarFamiliarController : _BaseController
    {
        public RegistrarFamiliarController(string connectionString) : base(connectionString) { }

        public void RegistrarFamiliar(Familiar familiar)
        {
            FamiliarAccess da = new FamiliarAccess(SqlConConnectionString);
            da.InsertFamiliar(familiar);
        }

        public bool verificaPessoa(Familiar familiar)
        {
            PessoaAccess da = new PessoaAccess(SqlConConnectionString);
            return da.VerificaPessoa(familiar.cpf);
        }

        public bool verificaFamiliar(Familiar familiar)
        {
            FamiliarAccess da = new FamiliarAccess(SqlConConnectionString);
            return da.verificaFamiliar(familiar.cpf);
        }

        public void adicionaPessoa(Familiar familiar)
        {
            PessoaAccess da = new PessoaAccess(SqlConConnectionString);
            da.InsertPessoa(familiar);
        }
    }
}
