using System.Linq;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Web.Controllers
{
   public class CarrinhoController : Controller
   {
      private ProdutosRepositorio _repositorio;

      private Carrinho ObterCarrinho()
      {
         Carrinho carrinho = (Carrinho)Session["Carrinho"];

         if (carrinho == null)
         {
            carrinho = new Carrinho();
            Session["Carrinho"] = carrinho;
         }

         return carrinho;
      }

      public RedirectToRouteResult Adicionar(int produtoId, string returnUrl)
      {
         _repositorio = new ProdutosRepositorio();

         Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

         if (produto != null)
         {
            ObterCarrinho().AdicionarItem(produto, 1);
         }

         return RedirectToAction("Index", new { returnUrl });
      }

      public RedirectToRouteResult Remover(int produtoId, string returnUrl)
      {
         _repositorio = new ProdutosRepositorio();

         Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

         if (produto != null)
         {
            ObterCarrinho().RemoverItem(produto);
         }

         return RedirectToAction("Index", new { returnUrl });
      }

      public ViewResult Index(string returnUrl)
      {
         return View(new CarrinhoViewModel
         {
            Carrinho = ObterCarrinho(),
            ReturnUrl = returnUrl
         });
      }

      public PartialViewResult Resumo()
      {
         Carrinho carrinho = ObterCarrinho();

         return PartialView(carrinho);
      }

      public ViewResult FecharPedido()
      {
         return View(new Pedido());
      }

      [HttpPost]
      public ViewResult FecharPedido(Pedido pedido)
      {
         return View(new Pedido());
      }
   }
}