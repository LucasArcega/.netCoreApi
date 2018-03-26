using App.Lib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Rep.Entities
{
    public class Estabelecimento
    {
        [DataPropertyToSql(DataPropertyToSqlAttribute.ColumnType.PrimaryKey)]
        public int IdEstabelecimento { get; set; }

        [DataPropertyToSql]
        //[DataPropertyToSql("estNome")]
        public string Nome { get; set; }

        [DataPropertyToSql]
        //[DataPropertyToSql("estCNPJ")]
        public string CNPJ { get; set; }

        [DataPropertyToSql]
        //[DataPropertyToSql("estRazaoSocial")]
        public string RazaoSocial { get; set; }

        [DataPropertyToSql]
        //[DataPropertyToSql("estNomeFantasia")]
        public string NomeFantasia { get; set; }

        [DataPropertyToSql]
        //[DataPropertyToSql("estAtivo")]
        public bool Ativo { get; set; }

        [DataPropertyToSql]
        //[DataPropertyToSql("estInscricaoEstadual")]
        public string InscricaoEstadual { get; set; }

        [DataPropertyToSql]
        //[DataPropertyToSql("estInscricaoMunicipal")]
        public string InscricaoMunicipal { get; set; }

        [DataPropertyToSql]
        //[DataPropertyToSql("estNomeContato")]
        public string NomeContato { get; set; }

        [DataPropertyToSql]
        //[DataPropertyToSql("estTelefoneContato")]
        public string TelefoneContato { get; set; }
    }
}
