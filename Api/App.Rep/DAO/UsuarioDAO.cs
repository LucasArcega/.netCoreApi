using App.Lib.Helpers;
using App.Rep.DAL;
using App.Rep.Entities;
using App.Rep.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
            string sql = EntityHelper.GetUpdateQuery(entidade);
            using (var con = Connection)
            {
                con.Open();
                con.Execute(sql, entidade);
                con.Close();
            }
        }

        public Usuario Carregar(int id)
        {
            string sql = EntityHelper.GetSelectByIdQuery<Usuario>();
            Usuario entidade = null;
            using (var con = Connection)
            {
                con.Open();
                entidade = con.Query<Usuario>(sql, new {IdUsuario = id}).FirstOrDefault();
                con.Close();
            }

            return entidade;
        }

        public void Excluir(int id)
        {
            string sql = EntityHelper.GetDeleteQuery<Usuario>();
            using (var con = Connection)
            {
                con.Open();
                con.Execute(sql, new { IdUsuario = id });
                con.Close();
            }
        }

        public void Inserir(Usuario entidade)
        {
            string sql = EntityHelper.GetInsertQuery(entidade);
            using (var con = Connection)
            {
                con.Open();
                con.Execute(sql, entidade);
                con.Close();                
            }
        }

        public List<Usuario> Listar()
        {
            string sql = EntityHelper.GetSelectByIdQuery<Usuario>();
            List<Usuario> entidades = null;
            using (var con = Connection)
            {
                con.Open();
                entidades = con.Query<Usuario>(sql).ToList();
                con.Close();
            }

            return entidades;
        }

        public List<Usuario> Listar(Filtro filtro)
        {
            throw new NotImplementedException();
        }
    }
}
