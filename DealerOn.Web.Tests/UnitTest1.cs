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

            string input1 = "1 book at 12.49\r\n1 book at 12.49\r\n1 music CD at 14.99\r\n1 chocolate bar at 0.85";

            var inputs = StringHelper.SplitByNewLine(input1);
            Assert.AreEqual(exptInputs, inputs.Length, "Split by new line did not execute correctly");

            model.Input = input1;
            model.Inputs = inputs;

            for (var i = 0; i < inputs.Length; i++)
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

        [TestMethod]
        public void TestMethod2()
        {
            var model = new SalesTaxViewModel();
            decimal expSalesTax = 7.65m;
            decimal expTotal = 65.15m;
            int exptInputs = 2;

            string input1 = "1 imported box of chocolates at 10.00\r\n1 imported bottle of perfume at 47.50";

            var inputs = StringHelper.SplitByNewLine(input1);
            Assert.AreEqual(exptInputs, inputs.Length, "Split by new line did not execute correctly");

            model.Input = input1;
            model.Inputs = inputs;

            for (var i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                var product = _productSvc.ParseEachInput(input);
                switch (i)
                {
                    case 0:
                        Assert.AreEqual(product.Name, "Imported box of chocolates", "Could not parse product name. First Line.");
                        break;
                    case 1:
                        Assert.AreEqual(product.Name, "Imported bottle of perfume", "Could not parse product name. Second Line.");
                        break;
                        default: break;
                }

                var productVm = ProductViewModel.ConvertTblProducts(product);
                model.Products.Add(productVm);
            }

            Assert.AreEqual(exptInputs, model.Products.Count, "Expected input and Parsed Products are not equal");

            SalesTaxViewModel.CalculateViewModel(model);

            Assert.AreEqual(expSalesTax, model.SalesTaxTotal, "Sales Tax is not equal");
            Assert.AreEqual(expTotal, model.Total, "Totals are not equal");
        }

        [TestMethod]
        public void TestMethod3()
        {
            var model = new SalesTaxViewModel();
            decimal expSalesTax = 7.30m;
            decimal expTotal = 86.53m;
            int exptInputs = 5;

            string input1 = "1 imported bottle of perfume at 27.99\r\n1 bottle of perfume at 18.99\r\n1 packet of headache pills at 9.75\r\n1 box of imported chocolates at 11.25\r\n1 box of imported chocolates at 11.25";

            var inputs = StringHelper.SplitByNewLine(input1);
            Assert.AreEqual(exptInputs, inputs.Length, "Split by new line did not execute correctly");

            model.Input = input1;
            model.Inputs = inputs;

            for (var i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                var product = _productSvc.ParseEachInput(input);
                switch (i)
                {
                    case 0:
                        Assert.AreEqual(product.Name, "Imported bottle of perfume", "Could not parse product name. First Line.");
                        break;
                    case 1:
                        Assert.AreEqual(product.Name, "Bottle of perfume", "Could not parse product name. Second Line.");
                        break;
                    case 2:
                        Assert.AreEqual(product.Name, "Packet of headache pills", "Could not parse product name. Third Line.");
                        break;
                    case 3:
                        Assert.AreEqual(product.Name, "Box of imported chocolates", "Could not parse product name. Fourth Line.");
                        break;
                    case 4:
                        Assert.AreEqual(product.Name, "Box of imported chocolates", "Could not parse product name. Fifth Line.");
                        break;
                    default: break;
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
