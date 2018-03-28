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
    public class EstabelecimentoDAO : DAOSuper, IEstabelecimentoDAL
    {
        public EstabelecimentoDAO(IConfiguration configuration) : base(configuration)
        {
        }

        public void Atualizar(Estabelecimento entidade)
        {
            using (var con = Connection)
            {
                string sql = EntityHelper.GetUpdateQuery(entidade);
                con.Open();
                con.Execute(sql, entidade);
                con.Close();
            }
        }

        public Estabelecimento Carregar(int id)
        {
            string sql = EntityHelper.GetSelectByIdQuery<Estabelecimento>();
            Estabelecimento entidade = null;
            using (var con = Connection)
            {
                con.Open();
                entidade = con.QueryFirstOrDefault<Estabelecimento>(sql, new {IdEstabelecimento = id});
                con.Close();
            }

            return entidade;
        }

        public void Excluir(int id)
        {
            string sql = EntityHelper.GetDeleteQuery<Estabelecimento>();
            using (var con = Connection)
            {
                con.Open();
                con.Execute(sql, new { IdEstabelecimento = id });
                con.Close();
            }
        }

        public void Inserir(Estabelecimento entidade)
        {
            string sql = EntityHelper.GetInsertQuery(entidade);
            using (var con = Connection)
            {
                con.Open();
                con.Execute(sql, entidade);
                con.Close();
            }
        }

        public List<Estabelecimento> Listar()
        {
            string sql = EntityHelper.GetSelectByIdQuery<Estabelecimento>();
            List<Estabelecimento> entidades = null;
            using (var con = Connection)
            {
                con.Open();
                entidades = con.Query<Estabelecimento>(sql).ToList();
                con.Close();
            }

            return entidades;
        }

        public List<Estabelecimento> Listar(Filtro filtro)
        {
            throw new NotImplementedException();
        }
    }
}
