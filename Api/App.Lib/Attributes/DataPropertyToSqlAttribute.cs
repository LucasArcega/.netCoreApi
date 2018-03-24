using System;
using System.Collections.Generic;
using System.Text;

namespace App.Lib.Attributes
{
    public class DataPropertyToSqlAttribute : Attribute
    {
        public enum ColumnType
        {
            Normal,
            PrimaryKey,
            ForeignKey,
            Unchangeble
        }

        public string NomeCampo { get; set; }

        public ColumnType columnType { get; private set; }

        public DataPropertyToSqlAttribute()
        {
            columnType = ColumnType.Normal;
        }

        public DataPropertyToSqlAttribute(ColumnType eType, string nome)
        {
            columnType = eType;
            NomeCampo = nome;
        }

        public DataPropertyToSqlAttribute(string nome)
        {
            NomeCampo = nome;
        }
        public DataPropertyToSqlAttribute(ColumnType eType)
        {
            columnType = eType;
        }
    }
}
