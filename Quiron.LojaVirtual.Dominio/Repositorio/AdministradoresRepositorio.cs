using Quiron.LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
   public class AdministradoresRepositorio
   {
      private readonly EFDbContext _context = new EFDbContext();

      public Administrador ObterAdministrador(Administrador administrador)
      {
         return _context.Administradores.FirstOrDefault(a => a.Login == administrador.Login);
      }
   }
}
