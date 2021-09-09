using DataZone;
using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;
using TrailerApp.Models;

namespace TrailerApp.Controllers
{
    public class PrincipalController : Controller
    {
        BDClass DB = new BDClass();
        ManejarBD MDB = new ManejarBD();
        FiltroVideos FDB = new FiltroVideos();
        public static string filtroname;
        public static bool session = false;
        static string error;
        // GET: Principal
        public ActionResult Index(int? pageSize, int? page)
        {
            List<videos> enlaces = new List<videos>();
            ViewBag.Session = session;
            if (error != null)
            {
                ViewBag.UrlError = error;
                error = null;
            }
            if (filtroname != null)
            {
                enlaces = FDB.VideosPorNombre(filtroname);
                filtroname = null;
            }
            else
            {
                enlaces = DB.ObtenerEnlaces();
            }

            pageSize = (pageSize ?? 3);
            page = (page ?? 1);
            ViewBag.PageSize = pageSize;

            return View(enlaces.ToPagedList(page.Value, pageSize.Value));
        }


        [HttpPost, ActionName("Index")]
        public ActionResult Index2(string title, string url)
        {
            List<videos> enlaces = new List<videos>();
            if (url != null)
            {
                if (title != null)
                {
                    if (ConversorEnlaces.ValidacionEnlaces(url))
                    {
                        url = ConversorEnlaces.ConversorEnlacesMethod(url);
                        AgregarABD.AgregarADataBase(url, title);
                    }
                    else
                    {
                        error = "Escriba una dirección correcta!";
                    }
                }
            }

            return RedirectToAction("Index");/*View(enlaces.ToPagedList(page.Value, pageSize.Value));*/
        }

        public ActionResult InicioSesión()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InicioSesión(string usuario, string contra)
        {
            string username = usuario;
            string contraseña = contra;

            if (username == "admin" && contraseña == "1234")
            {
                session = true;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorSession = "Los datos son erróneos";
                session = false;
            }
            return View();
        }


        public ActionResult CierreSesión()
        {
            session = false;
            return RedirectToAction("Index");
        }




        [HttpPost]
        public ActionResult Filtro(string buscar)
        {
            filtroname = buscar;
            return RedirectToAction("Index");
        }







        [HttpGet]
        public ActionResult GetByID(int ID)
        {
            var model = MDB.BuscarVideos(ID);
            if (model == null)
            {
                return HttpNotFound();
            }
            return PartialView("EditarVideos", model);
        }
        public ActionResult GetByDeleteID(int ID)
        {
            var model = MDB.BuscarVideos(ID);
            if (model == null)
            {
                return HttpNotFound();
            }
            return PartialView("BorraVideos", model);
        }
        public ActionResult MyEditPartial(videos model)
        {

            if (!string.IsNullOrEmpty(model.enlace))
            {
                if (!string.IsNullOrEmpty(model.titulo))
                {
                    if (model.enlace.Contains("embed") == false)
                    {
                        if (ConversorEnlaces.ValidacionEnlaces(model.enlace))
                        {
                            model.enlace = ConversorEnlaces.ConversorEnlacesMethod(model.enlace);
                            MDB.ActualizarVideos(model);
                        }
                    }
                    else
                    {
                        MDB.ActualizarVideos(model);
                    }
                    return RedirectToAction("Index");
                }


            }
            return PartialView("EditarVideos");
        }
        [HttpPost]
        public ActionResult MyDeletePartial(int ID)
        {
            MDB.BorrarVideos(ID);
            return RedirectToAction("Index");
        }
    }
}