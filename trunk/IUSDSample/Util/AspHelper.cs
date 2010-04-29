using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IUSDSample.Util
{
    public class AspHelper
    {
        public static string ParamPagina(string Name)
        {
            string resultado = string.Empty;
            if (HttpContext.Current != null && HttpContext.Current.Request.QueryString[Name] != null)
                resultado = HttpContext.Current.Request.QueryString[Name].ToString();
            return resultado;
        }

        public static int ParamPaginaInt(string Name)
        {
            string resultadoStr = ParamPagina(Name).ToUpperInvariant();
            int resultado;
            Int32.TryParse(resultadoStr, out resultado);
            return resultado;
        }
    }
}