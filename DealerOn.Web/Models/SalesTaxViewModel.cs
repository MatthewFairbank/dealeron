using System.Collections.Generic;
using System.Linq;

namespace DealerOn.Web.Models
{
    public class SalesTaxViewModel
    {
        public string Input { get; set; }
        public string[] Inputs { get; set; }
        public IList<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

        public IList<IGrouping<string, ProductViewModel>> GroupedProducts => this.Products.GroupBy(g => g.Name)

            .ToList();
        public IList<string> Errors { get; set; } = new List<string>();
        public decimal SalesTaxTotal { get; set; }
        public decimal Total { get; set; }

        public static void CalculateViewModel(SalesTaxViewModel model)
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