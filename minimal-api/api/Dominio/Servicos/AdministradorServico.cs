using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.DTOS;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Interfaces;
using MinimalApi.Dominio.DTOS;
using MinimalApi.Infraestrutura.Db;

namespace minimal_api.Servicos
{
    public class AdministradorServico : iAdministradorServico
    {
        private readonly Dbcontexto _contexto;
        public AdministradorServico(Dbcontexto contexto){
            _contexto = contexto;
        }

        public Administrador? BuscaPorId(int id)
        {
            return _contexto.Administradores.Where(v => v.Id == id).FirstOrDefault();
        }

        public Administrador? Incluir(Administrador administrador)
        {
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();
            return administrador;
        }

        public Administrador? Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
            return adm;
        }

        public List<Administrador> Todos(int? pagina)
        {
         var query = _contexto.Administradores.AsQueryable();
            int itensPorPagina = 10;

            if(pagina != null){
            query = query.Skip(((int) pagina - 1) * itensPorPagina).Take(itensPorPagina);
            }
            return query.ToList(); 
        }
    }
}