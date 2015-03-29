using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
   public class EmailConfiguracoes
   {

      public bool UsarSsl = false;

      public string ServidorSmtp = "smtp.quiron.com.br";

      public int ServidorPorta = 587;

      public string Usuario = "quiron";

      public bool EscreverArquivo = false;

      public string PastaArquivo = @"C:\envioemail";

      public string De = "wagnerbhf@gmail.com";

      public string Para = "wagnerbhf@gmail.com";
   }
}
