using App.Rep.DAL;
using App.Rep.Models;
using Microsoft.Extensions.Configuration;
using nfc.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Rep.DAO
{
    class UsuarioDAO : DAOSuper, IUsuarioDAL
    {
        public UsuarioDAO(IConfiguration configuration) : base(configuration)
        {
        }
        public Usuario Carregar(int id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public int Inserir(Usuario entidade)
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
