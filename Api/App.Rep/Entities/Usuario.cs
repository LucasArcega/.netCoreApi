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

        [DataPropertyToSql]
        //[DataPropertyToSql("usuNome")]
        public string Nome { get; set; }

        [DataPropertyToSql]
        //[DataPropertyToSql("usuTelefone")]
        public string Telefone { get; set; }

        [DataPropertyToSql]
        //[DataPropertyToSql("usuAtivo")]
        public bool Ativo { get; set; }

        [DataPropertyToSql]
        //[DataPropertyToSql("usuEmail")]
        public string Email { get; set; }

        [DataPropertyToSql]
        //[DataPropertyToSql("usuTipoUsuario")]
        public string TipoUsuario { get; set; }

        [DataPropertyToSql]
        //[DataPropertyToSql("usuLogin")]
        public string Login { get; set; }

        [DataPropertyToSql]
        //[DataPropertyToSql("usuSenha")]
        public string Senha { get; set; }
    }
}

