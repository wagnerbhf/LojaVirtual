using Quiron.LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
   public class ProdutosRepositorio
   {
      private readonly EFDbContext _context = new EFDbContext();

      public IEnumerable<Produto> Produtos
      {
         get { return _context.Produtos; }
      }

      public void Salvar(Produto produto)
      {
         if (produto.ProdutoId == 0)
         {
            _context.Produtos.Add(produto);
         }
         else
         {
            Produto prod = _context.Produtos.Find(produto.ProdutoId);

            if (prod != null)
            {
               prod.Nome = produto.Nome;
               prod.Descricao = produto.Descricao;
               prod.Preco = produto.Preco;
               prod.Categoria = produto.Categoria;
            }
         }

         _context.SaveChanges();
      }

      public Produto Excluir (int produtoId)
      {
         Produto prod = _context.Produtos.Find(produtoId);

         if (prod != null)
         {
            _context.Produtos.Remove(prod);
            _context.SaveChanges();
         }

         return prod;
      }
   }
}
