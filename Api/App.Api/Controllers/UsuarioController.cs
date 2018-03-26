using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App.Lib.Models;
using App.Rep.Entities;
using App.Rep.IServices;
using App.Rep.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {

        IUsuarioService usuarioService;
        
        public UsuarioController(IUsuarioService service)
        {
            usuarioService = service;
        }


        [HttpGet]
        public JsonResult  Get()
        {
            List<Usuario> retorno = null;
            try
            {
                retorno = usuarioService.Listar();
            }catch(Exception ex)
            {

            }
            return Json(data: retorno);
        }

        // GET: api/Usuario/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }        
        
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public RetornoModel<bool,HttpStatusCode> Post([FromBody]Usuario entidade)
        {
            RetornoModel<bool,HttpStatusCode> retorno = new RetornoModel<bool,HttpStatusCode>();
            retorno.Sucesso = true;
            retorno.Tipo = HttpStatusCode.OK;
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioService.Salvar(entidade);
                }
                else{
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
        /// Atualiza os dados de um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize("Bearer")]
        public RetornoModel<bool, HttpStatusCode> Atualizar([FromBody]Usuario usuario)
        {
            RetornoModel<bool, HttpStatusCode> retorno = new RetornoModel<bool, HttpStatusCode>();
            retorno.Sucesso = true;
            retorno.Tipo = HttpStatusCode.OK;
            retorno.Mensagem= "Dados atualizados com sucesso";
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioService.Salvar(usuario);
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
        /// Deleta um usuário específico
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
            retorno.Mensagem = "Usuário deletado com sucesso";

            try
            {
                if ( id > 0)
                {
                    usuarioService.Deletar(id);
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
