using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrailerApp.Models
{
    public class ConversorEnlaces
    {
        public static string ConversorEnlacesMethod(string enlace)
        {
            List<string> tmp = new List<string>();
            int i;
            long cantidadpuntos = enlace.LongCount(letra => letra.ToString() == ".");
            if (cantidadpuntos == 2)
            {
                string[] enlacecorto = enlace.Split('=');

                tmp = enlacecorto.ToList();

                i = 1;
            }
            else
            {
                string[] enlacecorto = enlace.Split('/');

                tmp = enlacecorto.ToList();

                i = 3;
            }
            

            return $"https://www.youtube.com/embed/{tmp[i]}";
        }

        public static bool ValidacionEnlaces(string enlace)
        {
            if (enlace.Contains("youtube") || enlace.Contains("youtu"))
            {
                if (enlace.Contains(".com") || enlace.Contains(".be"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}