using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseHabilidadeRepository
    {
        List<ClassesHabilidade> Listar();

        ClassesHabilidade BuscarPorId(int id);

        void Cadastrar(ClassesHabilidade novaCHabilidade);

        void Atualizar(int id, ClassesHabilidade cHablidadeAtualizada);

        void Deletar(int id);
    }
}
