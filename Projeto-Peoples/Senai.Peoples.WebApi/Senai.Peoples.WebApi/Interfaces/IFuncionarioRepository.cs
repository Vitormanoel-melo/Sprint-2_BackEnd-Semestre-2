using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> Listar();

        FuncionarioDomain BuscarPorId(int id);

        void Deletar(int id);

        void AtualizarIdCorpo(FuncionarioDomain novoFuncionario);

        void Cadastrar(FuncionarioDomain novoFuncionario);

        FuncionarioDomain BuscarPorNome(string nome);

        List<FuncionarioDomain> ListarPorOrdem(string ordem);

        List<object> ListarNomesCompletos(List<FuncionarioDomain> listaFunc);
    }
}
