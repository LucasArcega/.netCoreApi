using App.Rep.DAL;
using App.Rep.Entities;
using App.Rep.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Rep.DAO
{
    internal class ApiUsuarioDAO : DAOSuper, ISuperDAL<ApiUsuario>
    {
        public ApiUsuarioDAO(IConfiguration configuration) : base(configuration)
        {
        }

        public void Atualizar(ApiUsuario entidade)
        {
            throw new NotImplementedException();
        }

        public ApiUsuario Carregar(int id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public int Inserir(ApiUsuario entidade)
        {
            throw new NotImplementedException();
        }

        public List<ApiUsuario> Listar()
        {
            throw new NotImplementedException();
        }

        public List<ApiUsuario> Listar(Filtro filtro)
        {
            throw new NotImplementedException();
        }

        void ISuperDAL<ApiUsuario>.Inserir(ApiUsuario entidade)
        {
            throw new NotImplementedException();
        }
    }
}
