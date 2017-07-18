using Model;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RegistrarCuidadorInformalControler : _BaseController
    {
        public RegistrarCuidadorInformalControler(string connectionString) : base(connectionString) { }

        public void RegistrarCuidadorInformal(CuidadorInformal cuidador)
        {
            CuidadorInformalAccess da = new CuidadorInformalAccess(SqlConConnectionString);
            da.InsertCuidadorInformal(cuidador);
        }

        public bool verificaPessoa(CuidadorInformal cuidador)
        {
            PessoaAccess da = new PessoaAccess(SqlConConnectionString);
            return da.VerificaPessoa(cuidador.cpf);
        }

        public bool verificaCuidadorInformal(CuidadorInformal cuidador)
        {
            CuidadorInformalAccess da = new CuidadorInformalAccess(SqlConConnectionString);
            return da.VerificaCuidador(cuidador.cpf);
        }

        public void adicionaPessoa(CuidadorInformal cuidador)
        {
            PessoaAccess da = new PessoaAccess(SqlConConnectionString);
            da.InsertPessoa(cuidador);
        }


    }
}
