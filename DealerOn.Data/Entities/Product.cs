using System;
using DealerOn.Helpers;

namespace DealerOn.Data.Entities
{
    public class Product
    {
        private decimal _baseTax = 0;
        private decimal _importTax = 0;
        public long Id { get; set; } = DateTime.Now.Ticks;
        public string Input { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

        public decimal BaseTax
        {
            get => this._baseTax = this.IsTaxExempt ? 0 : CalculateBaseTax(this.Price);
            set => this._baseTax = value;
        }

        public decimal ImportTax
        {
            get => this._importTax = !this.IsImported ? 0 : CalculateImportTax(this.Price);
            set => this._importTax = value;
        }
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