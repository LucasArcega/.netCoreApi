using App.Rep.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Rep.Services
{
    public interface IBaseService<Type>
    {
        Type Carregar(int id);

        void Salvar(Type entidade);

        List<Type> Listar();

        void Deletar(int id);

        List<Type> Listar(Filtro filtro);
    }
}
