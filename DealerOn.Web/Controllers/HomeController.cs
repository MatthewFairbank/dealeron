using DealerOn.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using DealerOn.Business;
using DealerOn.Data.Data;
using DealerOn.Data.Entities;
using DealerOn.Data.Enums;
using DealerOn.Web.Models;

namespace DealerOn.Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ProductService _productSvc = new ProductService(ShoppingCartDataSet.GetItemsTable());

        static readonly IList<ProductType> _productTypes = new List<ProductType>()
        {
            ProductType.None,
            ProductType.Book,
            ProductType.Food,
            ProductType.MedicalProduct,
            ProductType.Other
        };
        private readonly List<SelectListItem> _types =
            _productTypes.OrderBy(e => e).Select(t => new SelectListItem { Value = ((int)t).ToString(), Text = t.ToString() }).ToList();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SalesTaxViewModel model)
        {
            model.Errors.Clear();
            ViewBag.TypesList = _types;
            model.Inputs = StringHelper.SplitByNewLine(model.Input.Trim());
            foreach (var input in model.Inputs)
            {
                try
                {
                    var product = _productSvc.ParseEachInput(input);
                    var productVm = ProductViewModel.ConvertTblProducts(product);
                    model.Products.Add(productVm);
                }
                catch (Exception ex)
                {
                    model.Errors.Add(
                        @"Error: Sorry we could not parse the items. Please make sure they are in the correct format.");
                    return View(model);
                }
            }

            if (model.Products.Any())
            {
                SalesTaxViewModel.CalculateViewModel(model);
            }
            else
            {
                model.Errors.Add(@"We did not find any items. Please make sure they are in the correct format.");
            }

            return View(model);
        }

        public static void ConvertToViewModel(SalesTaxViewModel model)
        {
            decimal salesTax = 0;
            decimal total = 0;
            foreach (var rowGroup in model.GroupedProducts)
            {
                if (rowGroup.Count() == 1)
                {
                    var row = rowGroup.First();
                    total += row.Price;
                    salesTax += row.BaseTax;
                    salesTax += row.ImportTax;
                }
                else
                {
                    decimal salesTaxTotal = rowGroup.Sum(e => e.BaseTax);
                    decimal importTaxTotal = rowGroup.Sum(e => e.ImportTax);
                    decimal totalPrice = rowGroup.Sum(e => e.Total);
                    total += totalPrice;
                    salesTax += salesTaxTotal + importTaxTotal;
                }
            }
            total += salesTax;
            model.SalesTaxTotal = salesTax;
            model.Total = total;
        }
    }
}