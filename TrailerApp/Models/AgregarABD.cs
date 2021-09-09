using DataZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrailerApp.Models
{
    public class AgregarABD
    {
        public static void AgregarADataBase(string url, string title)
        {
            BDClass BD = new BDClass();
            videos videos = new videos();
            videos.enlace = url;
            videos.titulo = title;
            BD.AgregarEnlace(videos);
        }
    }
}