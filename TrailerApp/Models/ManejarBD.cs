using DataZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrailerApp.Models
{
    public class ManejarBD
    {
        BDClass BD = new BDClass();

        public videos BuscarVideos(int id)
        {
            return BD.Buscar(id);
        }

        public void ActualizarVideos(videos model)
        {
            BD.Actualizar(model);
        }

        public void BorrarVideos(int id)
        {
            BD.Borrar(id);
        }
    }
}