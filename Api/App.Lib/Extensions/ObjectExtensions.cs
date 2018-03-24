using System;
using System.Collections.Generic;
using System.Text;

namespace App.Lib.Extensions
{
    public static class ObjectExtensions
    {        
     
        public static T GetAsType<T>(this object o)
        {
            return (T)o;
        }

        public static bool PropsIsNullOrEmpty(this object o, string[] propriedades = null)
        {
            bool retorno = true;
            foreach (var propriedade in propriedades)
            {
                if (!o.PropIsNullOrEmpty(propriedade))
                {
                    retorno = false;
                }
            }
            return retorno;
        }

        public static bool PropIsNullOrEmpty(this object o, string propriedade)
        {
            var valor = o.GetPropByNameAsString(propriedade);
            return (string.IsNullOrEmpty(valor) || (valor == "0"));
        }

        public static object GetPropByName(this object o, string propriedade)
        {
            var tipo = o.GetType();
            var prop = tipo.GetProperty(propriedade);
            return prop.GetValue(o);
        }

        public static void SetPropByName(this object o, string propriedade, object value)
        {
            var tipo = o.GetType();
            var prop = tipo.GetProperty(propriedade);
            prop.SetValue(o, value);
        }

        public static T GetPropByName<T>(this object o, string propriedade)
        {
            return (T)o.GetPropByName(propriedade);
        }

        public static string GetPropByNameAsString(this object o, string propriedade)
        {
            var valor = o.GetPropByName(propriedade);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ToString();
            }
        }

        public static int GetPropByNameAsInt(this object o, string propriedade)
        {
            return Convert.ToInt32(o.GetPropByNameAsString(propriedade));
        }

        public static T GetFirstOrDefaultAttribute<T>(this object o) where T : Attribute
        {
            var fi = o.GetType().GetField(o.ToString());
            try
            {
                var attributes = fi.GetCustomAttributes(typeof(T), false);
                if (attributes != null && attributes.Length > 0)
                    return (T)attributes[0];
            }
            catch
            {
            }
            return default(T);
        }
    }
}
