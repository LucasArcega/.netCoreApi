using App.Rep.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Rep.DAL
{
    public interface ISuperDAL<Type>
    {
        void Inserir(Type entidade);

        void Atualizar(Type entidade);

        void Excluir(int id);

        Type Carregar(int id);

        List<Type> Listar();

        List<Type> Listar(Filtro filtro);
    }
}
