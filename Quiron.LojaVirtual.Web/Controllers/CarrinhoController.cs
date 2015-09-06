using System.Linq;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
using System.Configuration;

namespace Quiron.LojaVirtual.Web.Controllers
{
   public class CarrinhoController : Controller
   {
      private ProdutosRepositorio _repositorio;

      public ViewResult Index(Carrinho carrinho, string returnUrl)
      {
         return View(new CarrinhoViewModel
         {
            Carrinho = carrinho,
            ReturnUrl = returnUrl
         });
      }

      public PartialViewResult Resumo(Carrinho carrinho)
      {
         return PartialView(carrinho);
      }

      public RedirectToRouteResult Adicionar(Carrinho carrinho, int produtoId, int quantidade, string returnUrl)
      {
         _repositorio = new ProdutosRepositorio();

         Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

         if (produto != null)
         {
            carrinho.AdicionarItem(produto, quantidade);
         }

         return RedirectToAction("Index", new { returnUrl });
      }

      public RedirectToRouteResult Remover(Carrinho carrinho, int produtoId, string returnUrl)
      {
         _repositorio = new ProdutosRepositorio();

         Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

         if (produto != null)
         {
            carrinho.RemoverItem(produto);
         }

         return RedirectToAction("Index", new { returnUrl });
      }

      public ViewResult FecharPedido()
      {
         return View(new Pedido());
      }

      [HttpPost]
      public ViewResult FecharPedido(Carrinho carrinho, Pedido pedido)
      {
         var emailConfiguracoes = new EmailConfiguracoes
         {
            EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"] ?? "false")
         };

         var emailPedido = new EmailPedido(emailConfiguracoes);

         if (!carrinho.ItensCarrinho.Any())
         {
            ModelState.AddModelError("", "Não foi possível concluir o pedido, seu carrinho está vazio!");
         }

         if (ModelState.IsValid)
         {
            emailPedido.ProcessarPedido(carrinho, pedido);
            carrinho.LimparCarrinho();
            return View("PedidoConcluido");
         }
         else
         {
            return View(pedido);
         }
      }

      public ViewResult PedidoConcluido()
      {
         return View();
      }
   }
}