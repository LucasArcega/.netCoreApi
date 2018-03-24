using App.Lib.Attributes;
using App.Lib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Lib.Helpers
{
    public abstract class EntityHelper
    {
        public static string GetInsertQuery(object entity)
        {
            string retorno = string.Format("INSERT INTO {0} (colunas) OUTPUT Inserted.PK VALUES (valores);", entity.GetType().Name);
            List<string> colunas = new List<string>();
            List<string> valores = new List<string>();

            foreach (var item in entity.GetType().GetProperties())
            {
                object[] atr = item.GetCustomAttributes(typeof(DataPropertyToSqlAttribute), true);
                if (atr.Length > 0)
                {
                    //Verifica se a coluna possui um nome diferente;
                    if (!string.IsNullOrEmpty((atr[0] as DataPropertyToSqlAttribute).NomeCampo))
                    {
                        colunas.Add((atr[0] as DataPropertyToSqlAttribute).NomeCampo);
                    }
                    else if ((atr[0] as DataPropertyToSqlAttribute).columnType != DataPropertyToSqlAttribute.ColumnType.PrimaryKey)
                    {
                        colunas.Add(item.Name);
                    }

                    //Verifica se é datetime pra fazer a devida conversão
                    if (item.PropertyType.Name.Equals("DateTime"))
                    {
                        if ((DateTime)entity.GetPropByName(item.Name) == DateTime.MinValue)
                        {
                            valores.Add(string.Format("{0}", "NULL"));
                        }
                        else
                        {
                            valores.Add(string.Format("@{0}", item.Name));
                        }
                    }
                    else if ((atr[0] as DataPropertyToSqlAttribute).columnType == DataPropertyToSqlAttribute.ColumnType.ForeignKey)
                    {
                        valores.Add(string.Format("IIF(@{0} > 0, @{0}, NULL)", item.Name));
                    }
                    else if ((atr[0] as DataPropertyToSqlAttribute).columnType == DataPropertyToSqlAttribute.ColumnType.PrimaryKey)
                    {
                        retorno = retorno.Replace("PK", item.Name);
                    }
                    else
                    {
                        valores.Add(string.Format("@{0}", item.Name));
                    }
                }
            }
            retorno = retorno.Replace("colunas", string.Join(", ", colunas));
            retorno = retorno.Replace("valores", string.Join(", ", valores));

            return retorno;
        }

        public static string GetUpdateQuery(object entity)
        {
            string retorno = string.Format("UPDATE {0} SET colunas WHERE PK = @PK;", entity.GetType().Name);
            List<string> colunas = new List<string>();

            foreach (var item in entity.GetType().GetProperties())
            {
                object[] atr = item.GetCustomAttributes(typeof(DataPropertyToSqlAttribute), true);
                if (atr.Length > 0)
                {
                    if ((atr[0] as DataPropertyToSqlAttribute).columnType == DataPropertyToSqlAttribute.ColumnType.PrimaryKey)
                    {
                        retorno = retorno.Replace("PK", item.Name);
                    }
                    else if ((atr[0] as DataPropertyToSqlAttribute).columnType == DataPropertyToSqlAttribute.ColumnType.Unchangeble)
                    {
                        continue;
                    }
                    else if (item.PropertyType.Name.Equals("DateTime") || (item.PropertyType == typeof(DateTime?) && ((DateTime?)entity.GetPropByName(item.Name)).HasValue))
                    {
                        if ((DateTime)entity.GetPropByName(item.Name) > DateTime.MinValue)
                        {
                            if (!string.IsNullOrEmpty((atr[0] as DataPropertyToSqlAttribute).NomeCampo))
                                colunas.Add(string.Format("{0} = @{1}", item.Name, (atr[0] as DataPropertyToSqlAttribute).NomeCampo));
                            else
                                colunas.Add(string.Format("{0} = @{0}", item.Name));
                        }
                    }
                    else if ((atr[0] as DataPropertyToSqlAttribute).columnType == DataPropertyToSqlAttribute.ColumnType.ForeignKey)
                    {
                        colunas.Add(string.Format("{0} = IIF(@{0} > 0, @{0}, NULL)", item.Name));
                    }
                    else if (!string.IsNullOrEmpty((atr[0] as DataPropertyToSqlAttribute).NomeCampo))
                    {
                        //Verifica se a coluna possui um nome diferente;
                        colunas.Add(string.Format("{0} = @{1}", item.Name, (atr[0] as DataPropertyToSqlAttribute).NomeCampo));
                    }
                    else
                    {
                        colunas.Add(string.Format("{0} = @{0}", item.Name));
                    }
                }
            }
            retorno = retorno.Replace("colunas", string.Join(", ", colunas));

            return retorno;
        }

        private static string GetSelectByIdQuery(Type entity)
        {
            string retorno = string.Format("SELECT colunas FROM {0} (NOLOCK) WHERE PK = @PK;", entity.Name);
            List<string> colunas = new List<string>();
            foreach (var item in entity.GetProperties())
            {
                object[] atr = item.GetCustomAttributes(typeof(DataPropertyToSqlAttribute), true);
                if (atr.Length > 0)
                {
                    if (!string.IsNullOrEmpty((atr[0] as DataPropertyToSqlAttribute).NomeCampo))
                        colunas.Add((atr[0] as DataPropertyToSqlAttribute).NomeCampo);

                    else if ((atr[0] as DataPropertyToSqlAttribute).columnType != DataPropertyToSqlAttribute.ColumnType.PrimaryKey)                    
                        colunas.Add(item.Name);
                    
                    else if ((atr[0] as DataPropertyToSqlAttribute).columnType == DataPropertyToSqlAttribute.ColumnType.PrimaryKey)
                    {
                        retorno = retorno.Replace("PK", item.Name);
                    }
                }
            }
            retorno = retorno.Replace("colunas", string.Join(", ", colunas));
            return retorno;
        }

        public static string GetSelectAllQuery<T>()
        {
            var entity = typeof(T);
            var retorno = string.Format("SELECT * FROM {0} (NOLOCK)", entity.Name);
            return retorno;
        }

        public static string GetSelectByIdQuery<T>()
        {
            return GetSelectByIdQuery(typeof(T));
        }

        public static string GetDeleteQuery<T>()
        {
            Type entityObj = typeof(T);

            string retorno = string.Format("DELETE FROM {0} WHERE PK = @PK;", entityObj.Name);
            foreach (var item in entityObj.GetProperties())
            {
                object[] atr = item.GetCustomAttributes(typeof(DataPropertyToSqlAttribute), true);
                if (atr.Length > 0)
                {
                    if ((atr[0] as DataPropertyToSqlAttribute).columnType == DataPropertyToSqlAttribute.ColumnType.PrimaryKey)
                    {
                        retorno = retorno.Replace("PK", item.Name);
                        break;
                    }
                }
            }
            return retorno;
        }

        private static string GetColumns(Type entity, bool includePrimaryKey = true, string alias = "")
        {
            List<string> colunas = new List<string>();
            string tbl = alias;
            if (!string.IsNullOrEmpty(tbl)) tbl = tbl + ".";

            foreach (var item in entity.GetProperties())
            {
                object[] atr = item.GetCustomAttributes(typeof(DataPropertyToSqlAttribute), true);
                if (atr.Length > 0)
                {
                    if (((atr[0] as DataPropertyToSqlAttribute).columnType == DataPropertyToSqlAttribute.ColumnType.PrimaryKey) && includePrimaryKey)
                    {
                        colunas.Add(tbl + item.Name);
                    }
                    else
                    {
                        colunas.Add(tbl + item.Name);
                    }
                }
            }
            return string.Join(", ", colunas);
        }

        public static string GetColumns<T>(bool includePrimaryKey = true, string alias = "")
        {
            return GetColumns(typeof(T), includePrimaryKey, alias);
        }

        public static string GetLikeFilter(object filter)
        {
            string result = string.Empty;

            foreach (var item in filter.GetType().GetProperties())
            {
                if (item.DeclaringType == filter.GetType())
                {
                    string valor = Convert.ToString(item.GetValue(filter));
                    if (!string.IsNullOrEmpty(valor))
                    {
                        if (!string.IsNullOrEmpty(result))
                            result += " OR ";

                        if (item.PropertyType == typeof(string))
                            result += string.Format("{0} LIKE @{0} ", item.Name);
                        else
                            result += string.Format("{0} = @{0} ", item.Name);
                    }
                }
            }

            if (String.IsNullOrEmpty(result))
                result = "1 = 1";
            return result;
        }
    }
}
