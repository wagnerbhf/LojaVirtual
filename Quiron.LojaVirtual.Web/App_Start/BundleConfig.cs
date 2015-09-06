﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Quiron.LojaVirtual.Web
{
   public class BundleConfig
   {
      public static void RegisterBundles(BundleCollection bundles)
      {
         bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-1.*"));

         BundleTable.EnableOptimizations = true;
      }
   }
}