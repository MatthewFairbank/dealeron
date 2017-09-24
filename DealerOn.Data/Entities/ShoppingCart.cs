using System.Collections.Generic;
using System.Linq;

namespace DealerOn.Data.Entities
{
    public class ShoppingCart
    {
        public IList<Product> Products { get; set; } = new List<Product>();
        public int Quantity => this.Products.Count;
        public int TaxExemptItems => this.Products.Count(e => e.IsTaxExempt);
        public int ImportedItems => this.Products.Count(e => e.IsImported);
        public decimal Total => this.Products.Sum(e => e.Total);
        public decimal SalesTaxTotal => this.Products.Sum(e => e.BaseTax + e.ImportTax);
    }
}