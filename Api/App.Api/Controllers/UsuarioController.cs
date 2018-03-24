using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Rep.Entities;
using App.Rep.IServices;
using App.Rep.Services;
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
        public string Post([FromBody]Usuario entidade)
        {
            try
            {
                usuarioService.Salvar(entidade);
            }
            catch (Exception ex)
            {

            }

            return "retprno";

        }
        
        // PUT: api/Usuario/5
        [HttpPut]
        public void Put([FromBody]Usuario usuario)
        {
            try
            {
                usuarioService.Salvar(usuario);
            }
            catch (Exception ex)
            {

            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                usuarioService.Deletar(id);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
