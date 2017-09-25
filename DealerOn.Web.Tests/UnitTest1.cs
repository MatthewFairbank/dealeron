using System;
using DealerOn.Business;
using DealerOn.Data.Data;
using DealerOn.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DealerOn.Helpers;

namespace DealerOn.Web.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ProductService _productSvc = new ProductService(ShoppingCartDataSet.GetItemsTable());
        [TestMethod]
        public void TestMethod1()
        {
            var model = new SalesTaxViewModel();
            decimal expSalesTax = 1.50m;
            decimal expTotal = 42.32m;
            int exptInputs = 4;

            string input1 = @"1 book at 12.49
                            1 book at 12.49
                            1 music CD at 14.99
                            1 chocolate bar at 0.85";

            var inputs = StringHelper.SplitByNewLine(input1);
            Assert.AreEqual(exptInputs, inputs.Length, "Split by new line did not execute correctly");

            model.Input = input1;
            model.Inputs = inputs;

            for (var i = 0; i < inputs.Length; i ++)
            {
                var input = inputs[i];
                var product = _productSvc.ParseEachInput(input);
                switch (i)
                {
                    case 0:
                        Assert.AreEqual(product.Name, "Book", "Could not parse product name. First Line.");
                        break;
                    case 1:
                        Assert.AreEqual(product.Name, "Book", "Could not parse product name. Second Line.");
                        break;
                    case 2:
                        Assert.AreEqual(product.Name, "Music CD", "Could not parse product name. Third Line.");
                        break;
                    case 3:
                        Assert.AreEqual(product.Name, "Chocolate bar", "Could not parse product name. Fourth Line.");
                        break;
                }
                
                var productVm = ProductViewModel.ConvertTblProducts(product);
                model.Products.Add(productVm);
            }

            Assert.AreEqual(exptInputs, model.Products.Count, "Expected input and Parsed Products are not equal");

            SalesTaxViewModel.CalculateViewModel(model);

            Assert.AreEqual(expSalesTax, model.SalesTaxTotal, "Sales Tax is not equal");
            Assert.AreEqual(expTotal, model.Total, "Totals are not equal");

        }
    }
}
