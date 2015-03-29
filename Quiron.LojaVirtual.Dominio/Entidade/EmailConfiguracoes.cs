using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
   public class EmailConfiguracoes
   {

      public bool UsarSsl { get; set; }

      public string ServidorSmtp { get; set; }

      public int ServidorPorta { get; set; }

      public string Usuario { get; set; }

      public bool EscreverArquivo { get; set; }

      public string PastaArquivo { get; set; }

      public string De { get; set; }

      public string Para { get; set; }

      public EmailConfiguracoes()
      {
         UsarSsl = false;
         ServidorSmtp = "smtp.quiron.com.br";
         ServidorPorta = 587;
         Usuario = "quiron";
         EscreverArquivo = false;
         PastaArquivo = @"C:\envioemail";
         De = "wagnerbhf@gmail.com";
         Para = "wagnerbhf@gmail.com";
      }
   }
}
