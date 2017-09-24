using DealerOn.Data.Entities;

namespace DealerOn.Web.Models
{
    public class ProductViewModel : Product

    {
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