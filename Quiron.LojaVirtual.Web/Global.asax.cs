using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Web.Infraestrutura;
using System.Web.Mvc;
using System.Web.Routing;

namespace Quiron.LojaVirtual.Web
{
   public class MvcApplication : System.Web.HttpApplication
   {
      protected void Application_Start()
      {
         AreaRegistration.RegisterAllAreas();
         RouteConfig.RegisterRoutes(RouteTable.Routes);

         ModelBinders.Binders.Add(typeof(Carrinho), new CarrinhoModelBinder());
      }
   }
}
