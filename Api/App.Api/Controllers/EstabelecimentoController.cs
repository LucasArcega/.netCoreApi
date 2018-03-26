using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App.Lib.Models;
using App.Rep.Entities;
using App.Rep.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Estabelecimento")]
    public class EstabelecimentoController : Controller
    {
        IEstabelecimentoService estabelecimentoService;

        public EstabelecimentoController(IEstabelecimentoService service)
        {
            estabelecimentoService = service;
        }


        [HttpGet]
        public JsonResult Get()
        {
            List<Estabelecimento> retorno = null;
            try
            {
                retorno = estabelecimentoService.Listar();
            }
            catch (Exception ex)
            {

            }
            return Json(data: retorno);
        }

        // GET: api/Estabelecimento/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Cadastra um novo estabelecimento
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public RetornoModel<bool, HttpStatusCode> Post([FromBody]Estabelecimento entidade)
        {
            RetornoModel<bool, HttpStatusCode> retorno = new RetornoModel<bool, HttpStatusCode>();
            retorno.Sucesso = true;
            retorno.Tipo = HttpStatusCode.OK;
            try
            {
                if (ModelState.IsValid)
                {
                    estabelecimentoService.Salvar(entidade);
                }
                else
                {
                    retorno.Sucesso = false;
                    retorno.Tipo = HttpStatusCode.BadRequest;
                    retorno.Mensagem = "Prencha os dados corretamente";
                }

            }
            catch (Exception ex)
            {
                retorno.Sucesso = false;
                retorno.Tipo = HttpStatusCode.InternalServerError;
                retorno.Mensagem = "Erro ao processar sua requisição, tente novamente mais tarde.";
            }

            return retorno;

        }

        /// <summary>
        /// Atualiza os dados de um estabelecimento
        /// </summary>
        /// <param name="estabelecimento"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize("Bearer")]
        public RetornoModel<bool, HttpStatusCode> Atualizar([FromBody]Estabelecimento estabelecimento)
        {
            RetornoModel<bool, HttpStatusCode> retorno = new RetornoModel<bool, HttpStatusCode>();
            retorno.Sucesso = true;
            retorno.Tipo = HttpStatusCode.OK;
            retorno.Mensagem = "Dados atualizados com sucesso";
            try
            {
                if (ModelState.IsValid)
                {
                    estabelecimentoService.Salvar(estabelecimento);
                }
                else
                {
                    retorno.Sucesso = false;
                    retorno.Tipo = HttpStatusCode.BadRequest;
                    retorno.Mensagem = "Prencha os dados corretamente";
                }

            }
            catch (Exception ex)
            {
                retorno.Sucesso = false;
                retorno.Tipo = HttpStatusCode.InternalServerError;
                retorno.Mensagem = "Erro ao processar sua requisição, tente novamente mais tarde.";
            }

            return retorno;
        }


        /// <summary>
        /// Deleta um estabelecimento específico
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        public RetornoModel<bool, HttpStatusCode> Delete(int id)
        {
            RetornoModel<bool, HttpStatusCode> retorno = new RetornoModel<bool, HttpStatusCode>();
            retorno.Sucesso = true;
            retorno.Tipo = HttpStatusCode.OK;
            retorno.Mensagem = "Estabelecimento deletado com sucesso";

            try
            {
                if (id > 0)
                {
                    estabelecimentoService.Deletar(id);
                }
                else
                {
                    retorno.Sucesso = false;
                    retorno.Tipo = HttpStatusCode.BadRequest;
                    retorno.Mensagem = "Informe um id maior que 0!";
                }

            }
            catch (Exception ex)
            {
                retorno.Sucesso = false;
                retorno.Tipo = HttpStatusCode.InternalServerError;
                retorno.Mensagem = "Erro ao processar sua requisição, tente novamente mais tarde.";
            }

            return retorno;
        }

    }
}
