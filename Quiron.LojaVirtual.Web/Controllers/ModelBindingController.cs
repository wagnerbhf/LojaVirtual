using Quiron.LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
   public class ModelBindingController : Controller
   {
      public ActionResult Index()
      {
         return View(new Produto());
      }

      [HttpPost]
      public ActionResult Editar([Bind(Include = "Nome")] Produto prod)
      {
         var produto = new Produto();

         //produto.Nome = prod.Nome;
         //produto.Preco = prod.Preco;

         return RedirectToAction("Index");
      }
   }
}