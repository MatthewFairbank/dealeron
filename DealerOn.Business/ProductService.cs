using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DealerOn.Data.Data;
using DealerOn.Data.Entities;
using DealerOn.Data.Enums;
using DealerOn.Helpers;

namespace DealerOn.Business
{
    public class ProductService
    {
        private readonly ItemsDataTable _db = ShoppingCartDataSet.GetItemsTable();

        //public void UpdateImportTaxCheck(int rowIndex, int colIndex, bool isImported)
        //{
        //    var price = StringHelper.ConvertColToDecimal(_db.Rows[rowIndex][colIndex].ToString());
            
        //}
        public void UpdateItemType(int rowIndex, int colIndex, ProductType type)
        {
        }

        public static Product GetProductFromInput(MatchCollection matches)
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
            product.IsImported = product.Input?.ToLower().Contains("imported") ?? false;
            return product;
        }
    }
}
