using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // 1 - Início
            routes.MapRoute(
                null,
                "",
                new
                {
                    controller = "Vitrine",
                    action = "ListarProdutos",
                    categoria = (string)null,
                    pagina = 1
                }
            );

            // 2
            routes.MapRoute(
                null,
                "Pagina{pagina}",
                new
                {
                    controller = "Vitrine",
                    action = "ListarProdutos",
                    categoria = (string)null
                },
                new { pagina = @"\d+" }
            );

            // 3
            routes.MapRoute(
               null,
               "{categoria}",
               new
               {
                   controller = "Vitrine",
                   action = "ListarProdutos",
                   pagina = 1
               }
            );

            // 4
            routes.MapRoute(
                null,
                "{categoria}Pagina{pagina}",
                new
                {
                    controller = "Vitrine",
                    action = "ListarProdutos"
                },
                new { pagina = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
