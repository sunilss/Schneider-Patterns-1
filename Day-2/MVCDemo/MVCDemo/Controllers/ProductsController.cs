using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Infrastructure;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/

        public ViewResult Index()
        {
            return View("Index",ProductsDb.GetAllProducts());
        }

        public ViewResult New()
        {
            return View();
        }

        public ActionResult Save(Product product)
        {
            var newProduct = ProductsDb.Add(product);
            return RedirectToAction("Index");
        }

    }
}
