using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestingLb1;
using Testing5Web;
using Testing5Web.Models;
using Testing5Web.Repository;
using System.Reflection;


namespace Testing5Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGoodsStoreContainer _gs;

        public HomeController(IGoodsStoreContainer gs, ILogger<HomeController> logger)
        {
            _gs = gs;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var found = _gs.GetGoodsStore();
            return View(found);
        }

        [HttpPost]
        public IActionResult AddProduct(AddItemModel model)
        {

            if (ModelState.IsValid)
            {
                _gs.GetGoodsStore().AddNewProduct(new Product(model.AddName, model.AddCount, model.AddPrice));
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult RemoveProduct(string removeName)
        {

            _gs.GetGoodsStore().RemoveAllWithName(removeName);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult BuyProduct(string buyName, string buyCount)
        {

            _gs.GetGoodsStore().BuyProduct(buyName, buyCount);

            return RedirectToAction("Index");
        }

        public IActionResult ImportProduct(string importName, string importCount)
        {


            _gs.GetGoodsStore().ImportProduct(importName, importCount);

            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
