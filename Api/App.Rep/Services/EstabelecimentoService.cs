using App.Lib.Models;
using App.Rep.DAL;
using App.Rep.Entities;
using App.Rep.IServices;
using App.Rep.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace App.Rep.Services
{
    public class EstabelecimentoService:IEstabelecimentoService
    {
        private readonly IEstabelecimentoDAL estabelecimentoDAL;
        private IConfiguration configuration;

        public EstabelecimentoService(IEstabelecimentoDAL estabelecimentoDAL, IConfiguration configuration)
        {
            this.estabelecimentoDAL = estabelecimentoDAL;
            this.configuration = configuration;
        }

        public Estabelecimento Carregar(int id)
        {
            return this.estabelecimentoDAL.Carregar(id);
        }

        public void Salvar(Estabelecimento entidade)
        {
            if (entidade.IdEstabelecimento > 0)
            {
                estabelecimentoDAL.Atualizar(entidade);
            }
            else
            {
                estabelecimentoDAL.Inserir(entidade);
            }
        }

        public List<Estabelecimento> Listar()
        {
            return this.estabelecimentoDAL.Listar();
        }

        public void Deletar(int id)
        {
            this.estabelecimentoDAL.Excluir(id);
        }

        public List<Estabelecimento> Listar(Filtro filtro)
        {
            return this.estabelecimentoDAL.Listar(filtro);
        }
    }
}
