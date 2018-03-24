using App.Lib.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Rep.Entities
{
    public class Usuario
    {
        [DataPropertyToSql(DataPropertyToSqlAttribute.ColumnType.PrimaryKey)]
        public int IdUsuario{ get; set; }

        [DataPropertyToSql("usuNome")]
        public string Nome { get; set; }

        [DataPropertyToSql("usuTelefone")]
        public string Telefone { get; set; }
        [DataPropertyToSql("usuAtivo")]
        public bool Ativo { get; set; }

        [DataPropertyToSql("usuInativo")]
        public string Email { get; set; }

        [DataPropertyToSql("usuSenha")]
        public string Senha { get; set; }
    }
}

