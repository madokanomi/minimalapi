using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.DTOS;
using minimal_api.Dominio.Entidades;
using MinimalApi.Dominio.DTOS;

namespace minimal_api.Dominio.Interfaces
{
    public interface iAdministradorServico
    {
      Administrador? Login(LoginDTO loginDTO);
       Administrador? Incluir(Administrador administrador);
       List<Administrador> Todos(int? pagina);

       Administrador? BuscaPorId(int id);
    }
}