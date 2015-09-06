using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
   public class VitrineController : Controller
   {
      private ProdutosRepositorio _repositorio;
      public int ProdutosPorPagina = 12;

      // GET: Vitrine
      //public ActionResult ListarProdutos(string categoria, int pagina = 1)
      //{
      //   _repositorio = new ProdutosRepositorio();

      //   ProdutosViewModel model = new ProdutosViewModel
      //   {
      //      Produtos = _repositorio.Produtos
      //         .Where(p => categoria == null || p.Categoria == categoria)
      //         .OrderBy(p => p.Descricao)
      //         .Skip((pagina - 1) * ProdutosPorPagina)
      //         .Take(ProdutosPorPagina),

      //      Paginacao = new Paginacao
      //      {
      //         PaginaAtual = pagina,
      //         ItensPorPagina = ProdutosPorPagina,
      //         ItensTotal = _repositorio.Produtos.Count(),
      //      },

      //      CategoriaAtual = categoria
      //   };

      //   return View(model);
      //}

      public ActionResult ListarProdutos(string categoria)
      {
         _repositorio = new ProdutosRepositorio();

         var model = new ProdutosViewModel();
         var rnd = new Random();

         if (categoria != null)
         {
            model.Produtos = _repositorio.Produtos.Where(p => p.Categoria == categoria).OrderBy(r => rnd.Next());
         }
         else
         {
            model.Produtos = _repositorio.Produtos.OrderBy(r => rnd.Next()).Take(ProdutosPorPagina).ToList();
         }

         return View(model);
      }
      
      [Route("Vitrine/ObterImagem/{produtoid}")]
      public FileContentResult ObterImagem(int produtoId)
      {
         _repositorio = new ProdutosRepositorio();
         Produto prod = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

         if (prod != null)
         {
            return File(prod.Imagem, prod.ImagemMimeType);
         }

         return null;
      }

      [Route("DetalhesProduto/{id}/{produto}")]
      public ViewResult Detalhes(int id)
      {
         _repositorio = new ProdutosRepositorio();
         Produto produto = _repositorio.ObterProduto(id);
         return View(produto);
      }
   }
}