using System;
using DealerOn.Data.Enums;
using DealerOn.Helpers;

namespace DealerOn.Data.Entities
{
    public class Product
    {
        public long Id { get; set; } = DateTime.Now.Ticks;
        public string Input { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public ProductType Type { get; set; }
        public decimal BaseTax { get; set; }
        public decimal ImportTax { get; set; }
        public bool IsTaxExempt { get; set; }
        public bool IsImported { get; set; } 

        public decimal Total => this.Price + this.BaseTax + this.ImportTax;

        public static decimal CalculateBaseTax(decimal basePrice)
        {
            return SalesTax.Round(basePrice, SalesTax.TaxType.Base);
        }

        public static decimal CalculateImportTax(decimal basePrice)
        {
            return SalesTax.Round(basePrice, SalesTax.TaxType.Import);
        }

    }
}