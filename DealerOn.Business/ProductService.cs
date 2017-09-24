using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DealerOn.Data.Data;
using DealerOn.Data.Entities;
using DealerOn.Data.Enums;
using System.Data;

namespace DealerOn.Business
{
    public class ProductService
    {
        private static ItemsDataTable _db;

        public ProductService(ItemsDataTable db)
        {
            _db = db;
        }

        public IList<DataRow> GetRows()
        {
            return _db.AsEnumerable().ToList();
        }

        public IList<IGrouping<string, DataRow>> GetGroupedRows()
        {
            var rows = _db.AsEnumerable()
                .GroupBy(row => row.Field<string>("Name"))
                .ToList();
            return rows;
        }

        public void ClearRows()
        {
            _db.Rows.Clear();
        }

        public static readonly IList<Tuple<ProductType, string>> _exemptList = new List<Tuple<ProductType, string>>()
        {
            new Tuple<ProductType, string>(ProductType.Food, "choco"),
            new Tuple<ProductType, string>(ProductType.Food, "chocolate bar"),
            new Tuple<ProductType, string>(ProductType.Food, "box of chocolates"),
            new Tuple<ProductType, string>(ProductType.Book, "book"),
            new Tuple<ProductType, string>(ProductType.MedicalProduct, "pills")
        };

        public void AddProductRow(Product p)
        {
            _db.Rows.Add(p.Input, p.Name, p.Qty, p.Price, p.BaseTax, p.ImportTax, p.IsTaxExempt, p.IsImported,
                p.Total);
        }

        public Product GetProductFromInput(MatchCollection matches)
        {
            var product = new Product();
            foreach (Match match in matches)
            {
                Console.WriteLine(match);
                for (int i = 0; i < match.Groups.Count; i++)
                {
                    switch (i)
                    {
                        case (int)InputRegexMatch.FullValue:
                            product.Input = match.Groups[i].Value;
                            break;
                        case (int)InputRegexMatch.Qty:
                            product.Qty = int.TryParse(match.Groups[i].Value, out var qty) ? qty : 0;
                            break;
                        case (int)InputRegexMatch.Item:
                            product.Name = match.Groups[i].Value;
                            break;
                        case (int)InputRegexMatch.At:
                            break;
                        case (int)InputRegexMatch.Price:
                            product.Price = decimal.TryParse(match.Groups[i].Value, out var price) ? price : 0;
                            break;
                        default:
                            break;
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(product.Name))
            {
                product.IsTaxExempt = _exemptList.Any(e => product.Name.ToLower().Contains(e.Item2));
                product.Type = _exemptList.FirstOrDefault(e => product.Name.Contains(e.Item2))?.Item1 ??
                               ProductType.None;
                product.BaseTax = product.IsTaxExempt ? 0 : Product.CalculateBaseTax(product.Price);
            }
            product.IsImported = product.Input?.ToLower().Contains("imported") ?? false;
            product.ImportTax = product.IsImported ? Product.CalculateImportTax(product.Price) : 0;
            product.Name = ParseName(product.Name);
            //product.Total = product.Price + product.BaseTax + product.ImportTax;
            return product;
        }

        private static string ParseName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return name;
            name = char.ToUpper(name[0]) + name.Substring(1);
            return name.Trim();
        }
    }
}
