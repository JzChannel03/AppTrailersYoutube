using DataZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrailerApp.Models
{
    public class FiltroVideos
    {
        BDClass BD = new BDClass();
        public List<videos> VideosPorNombre(string nombrevideo)
        {
            return BD.VideosPorNombre(nombrevideo);
        }
    }
}