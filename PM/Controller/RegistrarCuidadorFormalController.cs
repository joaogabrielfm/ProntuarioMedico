using Model;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RegistrarCuidadorFormalControler : _BaseController
    {
        public RegistrarCuidadorFormalControler(string connectionString) : base(connectionString) { }

        public void RegistrarCuidadorFormal(CuidadorFormal cuidador)
        {
            CuidadorFormalAccess da = new CuidadorFormalAccess(SqlConConnectionString);
            da.InsertCuidadorFormal(cuidador);
        }

        public bool verificaPessoa(CuidadorFormal cuidador)
        {
            PessoaAccess da = new PessoaAccess(SqlConConnectionString);
            return da.VerificaPessoa(cuidador.cpf);
        }

        public bool verificaCuidadorFormal(CuidadorFormal cuidador)
        {
            CuidadorFormalAccess da = new CuidadorFormalAccess(SqlConConnectionString);
            return da.VerificaCuidador(cuidador.cpf);
        }

        public void adicionaPessoa(CuidadorFormal cuidador)
        {
            PessoaAccess da = new PessoaAccess(SqlConConnectionString);
            da.InsertPessoa(cuidador);
        }


    }
}
