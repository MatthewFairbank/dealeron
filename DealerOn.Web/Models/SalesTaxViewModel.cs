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
    }
}