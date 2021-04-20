using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface ILoginRepository
    {
        UsuarioDomain Logar(string email, string senha);

        string BuscarPermissao(int id);
    }
}
