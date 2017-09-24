using System;

namespace DealerOn.Helpers
{
    public static class SalesTax
    {
        public enum TaxType
        {
            Base,
            Import
        }
        public const decimal Base = 0.10m;
        public const decimal Import = 0.05m;

        public static decimal Round(decimal basePrice, TaxType type)
        {
            return Math.Round((basePrice * (type == TaxType.Base ? Base : Import)) * 20) / 20;
        }
        public static decimal BaseWithTax(decimal shelfPrice)
        {
            return shelfPrice * Base;
        }

        public static decimal BaseWithImport(decimal shelfPrice)
        {
            return shelfPrice * Import;
        }
    }
}