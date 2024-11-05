using Dinnet.Entidades;
using Dinnet.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dinnet.Web.Controllers
{
    public class HomeController : Controller
    {
        private ProxyInventario proxy = null;
        public HomeController()
        {
            proxy = new ProxyInventario();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult InsertarInventario(InventarioBe inventario)
        {
            var filasAfectadas = proxy.InsertarInventario(inventario);
            JsonResult json = Json(new { d = filasAfectadas }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }
        public JsonResult FiltrarInventario(string filtro)
        {
            var inventarios = proxy.Filtrarinventario(filtro);
            JsonResult json = Json(new { d = inventarios }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

    }
}