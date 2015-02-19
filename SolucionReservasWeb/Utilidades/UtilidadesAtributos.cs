using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Utilidades
{
    public class UtilidadesAtributos
    {
        public static string AtributosATexto(Object objeto)
        {
            string s = ""; object valor;
            Type tipo = objeto.GetType();
          
            if (tipo == null) s = "Sin atributos";
            foreach (PropertyInfo p in tipo.GetProperties())
            {
                valor = p.GetValue(objeto, null);
                if (esTipoBasico(valor.GetType()))
                {

                    string nombre = p.Name;
                    s += nombre + " : " + valor.ToString() + " ";

                }
                
            }
            return s;
        }
        private static bool esTipoBasico(Type tipo)
        { return  tipo.IsPrimitive || tipo.IsValueType || (tipo == typeof(string));}
    }
}
