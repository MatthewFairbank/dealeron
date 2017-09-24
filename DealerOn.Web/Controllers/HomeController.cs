using DealerOn.Data.Entities;
using DealerOn.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using DealerOn.Business;

namespace DealerOn.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IList<string> _types = new List<string>()
        {
            "Book",
            "Food",
            "Medical Product",
            "Other"
        };
        // GET: Home
        public ActionResult Index()
        {
            ViewData["types"] = _types;
            return View();
        }

        [HttpPost]
        public ActionResult Index(SalesTaxViewModel model)
        {
            ViewData["types"] = _types;
            model.Inputs = StringHelper.SplitByNewLine(model.Input);
            foreach (var input in model.Inputs)
            {
                var matches = RegexHelper.InputRegex.Matches(input);
                var product = ProductService.GetProductFromInput(matches);
                var productVm = ProductViewModel.ConvertTblProducts(product);
                model.Products.Add(productVm);
            }
            return View(model);
        }
    }

    public class SalesTaxViewModel
    {
        public string Input { get; set; }
        public string[] Inputs { get; set; }
        public IList<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();


    }

    public class ProductViewModel : Product
    {
        public bool Editable { get; set; }

        public static ProductViewModel ConvertTblProducts(Product p)
        {
            var vm = new ProductViewModel()
            {
                Input = p.Input,
                Name = p.Name,
                Qty = p.Qty,
                Price = p.Price,
                Type = p.Type,
                IsImported = p.IsImported,
                IsTaxExempt = p.IsTaxExempt,
                BaseTax = p.BaseTax,
                ImportTax = p.ImportTax,
                Editable = false,
            };
            return vm;
        }

        public static Product ConvertProductViewModel(ProductViewModel p)
        {
            var product = new Product()
            {
                Input = p.Input,
                Name = p.Name,
                Qty = p.Qty,
                Price = p.Price,
                Type = p.Type,
                IsImported = p.IsImported,
                IsTaxExempt = p.IsTaxExempt,
                BaseTax = p.BaseTax,
                ImportTax = p.ImportTax
            };
            return product;
        }
    }
}