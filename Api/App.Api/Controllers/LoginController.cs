using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using App.Rep.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using App.Lib.Models;
using App.Rep.IServices;
using System.Net;

namespace App.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        private readonly IUsuarioService usuarioService;


        public LoginController(IUsuarioService usuario)
        {
            usuarioService = usuario;
        }

        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody]Usuario usuario)
        {
            RetornoModel<LoginModel, HttpStatusCode> retorno = new RetornoModel<LoginModel, HttpStatusCode>();
            retorno.Sucesso = true;
            retorno.Tipo = HttpStatusCode.OK;
            retorno.Mensagem = "Login realizado com sucesso.";

            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioDb = usuarioService.Carregar(usuario.Login);

                    if (usuarioDb != null)
                    {
                        retorno.Retorno = usuarioService.Login(usuario, usuarioDb);
                        if (!retorno.Retorno.Authenticated)
                        {
                            retorno.Sucesso = false;
                            retorno.Tipo = HttpStatusCode.BadRequest;
                            retorno.Mensagem = "Senha inválida.";
                        }
                    }
                    else{
                        retorno.Sucesso = false;
                        retorno.Tipo = HttpStatusCode.BadRequest;
                        retorno.Mensagem = "Usuário não cadastrado.";
                    }
                    
                }

                else
                {
                    retorno.Sucesso = false;
                    retorno.Tipo = HttpStatusCode.BadRequest;
                    retorno.Mensagem = "Dados incompletos! Preencha os dados obrigatórios.";
                }
            }
            catch(Exception ex)
            {
                retorno.Sucesso = false;
                retorno.Tipo = HttpStatusCode.InternalServerError;
                retorno.Mensagem = "Houve um erro ao processar sua requisição, tente novamente mais tarde.";
            }
            return retorno;
        }
    }
}