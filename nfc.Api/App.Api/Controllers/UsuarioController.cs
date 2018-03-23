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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Usuario/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Usuario
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
