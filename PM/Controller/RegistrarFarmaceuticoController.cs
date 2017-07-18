using Model;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RegistrarFarmaceuticoController : _BaseController
    {
        public RegistrarFarmaceuticoController(string connectionString) : base(connectionString) { }

        public void RegistrarFarmaceutico(Farmaceutico novoFarmaceutico)
        {
            FarmaceuticoAccess da = new FarmaceuticoAccess(SqlConConnectionString);
            da.InsertFarmaceutico(novoFarmaceutico);
        }

        public bool verificaPessoa(Farmaceutico novoFarmaceutico)
        {
            PessoaAccess da = new PessoaAccess(SqlConConnectionString);
            return da.VerificaPessoa(novoFarmaceutico.cpf);
        }

        public bool verificaFarmaceutico(Farmaceutico novoFarmaceutico)
        {
            FarmaceuticoAccess da = new FarmaceuticoAccess(SqlConConnectionString);
            return da.VerificaFarmaceutico(novoFarmaceutico.cpf);
        }

        public void adicionaPessoa(Farmaceutico novoFarmaceutico)
        {
            PessoaAccess da = new PessoaAccess(SqlConConnectionString);
            da.InsertPessoa(novoFarmaceutico);
        }


    }
}
