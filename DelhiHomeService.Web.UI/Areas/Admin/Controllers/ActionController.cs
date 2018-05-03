using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DelhiHomeService.Models;
using DelhiHomeService.Data.Admin;

namespace DelhiHomeService.Web.UI.Areas.Admin.Controllers
{
    public class ActionController : Controller
    {
        // GET: Admin/Action
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult ViewProduct()
        {

            Data.Admin.Product p = new Data.Admin.Product();
            var products = p.GetProduct();
            return View(products);
        }

        public ActionResult ViewService()
        {
            return View();
        }

        public ActionResult ViewOrder()
        {
            return View();
        }


    }
}