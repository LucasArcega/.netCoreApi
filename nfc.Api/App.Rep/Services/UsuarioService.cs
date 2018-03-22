using App.Rep.DAL;
using App.Rep.Models;
using nfc.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Rep.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioDAL usuarioDAL;

        public UsuarioService(IUsuarioDAL usuarioDAL)
        {
            this.usuarioDAL = usuarioDAL;
        }
        
        public Usuario Carregar(int id)
        {
            return this.usuarioDAL.Carregar(id);
        }

        public int Inserir(Usuario entidade)
        {
            return this.usuarioDAL.Inserir(entidade);
        }

        public List<Usuario> Listar()
        {
            return this.usuarioDAL.Listar();
        }

        public void Deletar(int id)
        {
            this.usuarioDAL.Excluir(id);
        }

        public List<Usuario> Listar(Filtro filtro)
        {
            return this.usuarioDAL.Listar(filtro);
        }

    }
}
