using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WEBASPNETMVCWCFSECIDEN.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;


namespace WEBASPNETMVCWCFSECIDEN.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {

        // GET: Usuarios
        public ActionResult Index()
        {
            var list = new List<UsuariosViewModel>();
            
            using (var client = new UsuariosService.UsuariosServiceClient())
            {
                list.AddRange(client.ObtenerUsuarios().Select(item => new UsuariosViewModel
                {
                    UsuId = item.UsuId,
                    UsuNombre = item.UsuNombre,
                    UsuPassword = item.UsuPassword
                }));
            }
            return View(list);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            if (id==0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var UsuariosViewModel = new UsuariosViewModel();

            using (var client = new UsuariosService.UsuariosServiceClient())
            {
                var objeto = client.ObtenerUsuarioById(id);

                if (objeto != null)
                {
                    UsuariosViewModel.UsuId = objeto.First().UsuId;
                    UsuariosViewModel.UsuNombre = objeto.First().UsuNombre;
                    UsuariosViewModel.UsuPassword = objeto.First().UsuPassword;
                }

            }

            return View(UsuariosViewModel);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuId,UsuNombre,UsuPassword")] UsuariosViewModel usuariosViewModel)
        {
            using (var client = new UsuariosService.UsuariosServiceClient())
            {
                client.CrearUsuarios(new UsuariosService.Usuarios
                {
                    UsuId = usuariosViewModel.UsuId,
                    UsuNombre = usuariosViewModel.UsuNombre,
                    UsuPassword = usuariosViewModel.UsuPassword
                }
                );
            }
            return RedirectToAction("Index");
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            if (id==0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var UsuariosViewModel = new UsuariosViewModel();

            using (var client = new UsuariosService.UsuariosServiceClient())
            {
                var objeto = client.ObtenerUsuarioById(id);

                if (objeto != null)
                {
                    UsuariosViewModel.UsuId = objeto.First().UsuId;
                    UsuariosViewModel.UsuNombre = objeto.First().UsuNombre;
                    UsuariosViewModel.UsuPassword = objeto.First().UsuPassword;
                }
                else
                {
                    return HttpNotFound();
                }

            }


            return View(UsuariosViewModel);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuId,UsuNombre,UsuPassword")] UsuariosViewModel UsuariosViewModel)
        {
            if (ModelState.IsValid)
            {
                using (var client = new UsuariosService.UsuariosServiceClient())
                {
                    client.ActualizarUsuarios(new UsuariosService.Usuarios
                    {
                        UsuId = UsuariosViewModel.UsuId,
                        UsuNombre = UsuariosViewModel.UsuNombre,
                        UsuPassword = UsuariosViewModel.UsuPassword
                    });
                }
            }

            return RedirectToAction("Index");
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            if (id==0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var UsuariosViewModel = new UsuariosViewModel();

            using (var client = new UsuariosService.UsuariosServiceClient())
            {
                var objeto = client.ObtenerUsuarioById(id);

                if (objeto != null)
                {
                    UsuariosViewModel.UsuId = objeto.First().UsuId;
                    UsuariosViewModel.UsuNombre = objeto.First().UsuNombre;
                    UsuariosViewModel.UsuPassword = objeto.First().UsuPassword;
                }
                else
                {
                    return HttpNotFound();
                }

            }

            return View(UsuariosViewModel);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var client = new UsuariosService.UsuariosServiceClient())
            {
                client.EliminarUsuarios(id);
            }
            return RedirectToAction("Index");
        }

     
    }
}