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
      public int ProdutosPorPagina = 8;

      // GET: Vitrine
      public ActionResult ListarProdutos(string categoria, int pagina = 1)
      {
         _repositorio = new ProdutosRepositorio();

         ProdutosViewModel model = new ProdutosViewModel
         {
            Produtos = _repositorio.Produtos
               .Where(p => categoria == null || p.Categoria == categoria)
               .OrderBy(p => p.Descricao)
               .Skip((pagina - 1) * ProdutosPorPagina)
               .Take(ProdutosPorPagina),

            Paginacao = new Paginacao
            {
               PaginaAtual = pagina,
               ItensPorPagina = ProdutosPorPagina,
               ItensTotal = _repositorio.Produtos.Count(),
            },

            CategoriaAtual = categoria
         };

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
   }
}