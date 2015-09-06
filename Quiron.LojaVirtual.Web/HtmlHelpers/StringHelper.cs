using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Quiron.LojaVirtual.Web.HtmlHelpers
{
   public static class StringHelper
   {
      public static string ToSeoUrl(this string url)
      {
         string encodeUrl = (url ?? "").ToLower();

         // replace & with and
         encodeUrl = Regex.Replace(encodeUrl, @"\&+", "and");

         // remove characters
         encodeUrl = encodeUrl.Replace("'", "");

         // remove invalid characters
         encodeUrl = Regex.Replace(encodeUrl, @"[^a-z0-9]", "-");

         // remove duplicates
         encodeUrl = Regex.Replace(encodeUrl, @"-+", "-");

         // trim leading & trailing characters
         encodeUrl = encodeUrl.Trim('-');

         return encodeUrl;
      }
      public static bool IsNullOrEmpty(this string input)
      {
         return input.IsNullOrEmpty();
      }
   }
}