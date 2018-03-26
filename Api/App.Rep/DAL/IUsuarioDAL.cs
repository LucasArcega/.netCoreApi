using App.Rep.Entities;
using App.Rep.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Rep.DAL
{
    public interface IUsuarioDAL:ISuperDAL<Usuario>
    {
        Usuario Carregar(string login);
    }
}
