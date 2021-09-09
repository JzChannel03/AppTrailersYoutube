using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataZone
{
    public class BDClass
    {
        TrailerDB conexion = new TrailerDB();
        public void AgregarEnlace(videos model)
        {
            conexion.videos.Add(model);
            conexion.SaveChanges();
        }

        public List<videos> ObtenerEnlaces()
        {
            return conexion.videos.ToList();
        }

        public videos Buscar(int id)
        {
            return conexion.videos.Find(id);
        }

        public void Actualizar(videos model)
        {
            var data = conexion.videos.Find(model.id);
            data.enlace = model.enlace;
            data.titulo = model.titulo;
            conexion.Entry(data).State = EntityState.Modified;
            conexion.SaveChanges();
        }

        public void Borrar(int id)
        {
            var data = conexion.videos.Find(id);
            conexion.videos.Remove(data);
            conexion.SaveChanges();
        }

        public List<videos> VideosPorNombre(string nombrevideo)
        {
            return conexion.videos.Where(a => a.titulo.ToLower().Contains(nombrevideo.ToLower())).ToList();
        }
    }
}
