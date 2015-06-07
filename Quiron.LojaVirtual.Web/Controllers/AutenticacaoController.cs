﻿using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Dominio.Repositorio;
using System.Web.Security;

namespace Quiron.LojaVirtual.Web.Controllers
{
   public class AutenticacaoController : Controller
   {
      AdministradoresRepositorio _repositorio;

      public ActionResult Login(string returnUrl)
      {
         ViewBag.ReturnUrl = returnUrl;
         return View(new Administrador());
      }


      [HttpPost]
      public ActionResult Login(Administrador administrador, string returnUrl)
      {
         _repositorio = new AdministradoresRepositorio();

         if (ModelState.IsValid)
         {
            Administrador admin = _repositorio.ObterAdministrador(administrador);

            if (admin != null)
            {
               if (!Equals(administrador.Senha, admin.Senha))
               {
                  ModelState.AddModelError("", "Senha não confere");
               }
               else
               {
                  FormsAuthentication.SetAuthCookie(admin.Login, false);

                  if (Url.IsLocalUrl(returnUrl)
                     && returnUrl.Length > 1
                     && returnUrl.StartsWith("/")
                     && !returnUrl.StartsWith("//")
                     && !returnUrl.StartsWith("/\\"))
                  {
                     return Redirect(returnUrl);
                  }

                  return RedirectToAction("Index", "Produto", new {area = "Administrativo"});
               }
            }
            else
            {
               ModelState.AddModelError("", "Administrador não localizado");
            }
         }

         return View(new Administrador());
      }
   }
}