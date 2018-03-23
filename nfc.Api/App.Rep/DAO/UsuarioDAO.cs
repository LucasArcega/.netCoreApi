using App.Rep.DAL;
using App.Rep.Entities;
using App.Rep.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Rep.DAO
{
    public class UsuarioDAO : DAOSuper, IUsuarioDAL
    {
        public UsuarioDAO(IConfiguration configuration) : base(configuration)
        {
        }

        public void Atualizar(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public Usuario Carregar(int id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Listar(Filtro filtro)
        {
            throw new NotImplementedException();
        }
    }
}
