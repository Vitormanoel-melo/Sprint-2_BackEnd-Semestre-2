using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class ClasseHabilidadeRepository : IClasseHabilidadeRepository
    {
        public void Atualizar(int id, ClassesHabilidade cHablidadeAtualizada)
        {
            throw new NotImplementedException();
        }

        public ClassesHabilidade BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ClassesHabilidade novaCHabilidade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<ClassesHabilidade> Listar()
        {
            throw new NotImplementedException();
        }

    }
}
