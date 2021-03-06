﻿using App.Lib.Models;
using App.Rep.Entities;
using App.Rep.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Rep.IServices
{
    public interface IUsuarioService:IBaseService<Usuario>
    {
        Usuario Carregar(string Login);

        LoginModel Login(Usuario usuarioEntrada, Usuario usuarioDb);
    }
}
