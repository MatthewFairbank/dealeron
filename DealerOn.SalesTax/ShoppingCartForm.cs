using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DealerOn.Business;
using DealerOn.Data.Data;
using DealerOn.Data.Entities;
using DealerOn.Data.Enums;
using DealerOn.Helpers;

namespace DealerOn.SalesTax
{
    public partial class ShoppingCartForm : Form
    {
        private readonly ProductService productSvc = new ProductService(ShoppingCartDataSet.GetItemsTable());

        public ShoppingCartForm()
        {
            InitializeComponent();
            UpdateDataGridView();
        }

        private void Checkout_Click(object sender, EventArgs evt)
        {
            var inputs = StringHelper.SplitByNewLine(this.shoppingCartItems.Text);
            foreach (var input in inputs)
            {
                try
                {
                    var matches = RegexHelper.InputRegex.Matches(input);
                    var product = productSvc.GetProductFromInput(matches);
                    if (string.IsNullOrWhiteSpace(product.Name) || product.Price == 0) throw new NullReferenceException();
                    productSvc.AddProductRow(product);
                }
                catch (Exception ex)
                {
                    this.panel1.Controls.Add(new Label()
                    {
                        AutoSize = true,
                        Text =
                            $"Error: Sorry we could not parse the items.\r\nPlease make sure they are in a format of [Qty] [Description] [at] [Price]",
                        ForeColor = System.Drawing.Color.Red
                    });
                }

            }
            this.UpdateDataGridView();
        }

        private void Clear_Click(object sender, EventArgs evt)
        {
            this.shoppingCartItems.Text = string.Empty;
            productSvc.ClearRows();
            this.UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {
            var controls = panel1.Controls;
            foreach (Control control in controls)
            {
                panel1.Controls.Remove(control);
            }

            var rows = productSvc.GetRows();

            if (rows.Any())
            {
                var labelText = new StringBuilder();
                decimal salesTax = 0;
                decimal total = rows.Sum(e=> StringHelper.ConvertColToDecimal(e[(int)ItemsColIndex.Price].ToString()));
                foreach (IGrouping<string, DataRow> rowGroup in productSvc.GetGroupedRows())
                {
                    if (rowGroup.Count() == 1)
                    {
                        var row = rowGroup.First();
                        labelText.Append($"{ConvertRowToOutput(row)}\r\n");
                        salesTax += StringHelper.ConvertColToDecimal(row[(int)ItemsColIndex.BaseTax].ToString());
                        salesTax += StringHelper.ConvertColToDecimal(row[(int)ItemsColIndex.ImportTax].ToString());
                    }
                    else
                    {
                        decimal salesTaxTotal = rowGroup.Sum(e => StringHelper.ConvertColToDecimal(e[(int)ItemsColIndex.BaseTax].ToString()));
                        decimal importTaxTotal = rowGroup.Sum(e => StringHelper.ConvertColToDecimal(e[(int)ItemsColIndex.ImportTax].ToString()));
                        int qty = rowGroup.Count();
                        decimal totalPrice = rowGroup.Sum(e => StringHelper.ConvertColToDecimal(e[(int)ItemsColIndex.Total].ToString()));
                        decimal price = totalPrice / 2;
                        labelText.Append($"{rowGroup.Key}: ${totalPrice} ({qty} @ ${price})\r\n");
                        salesTax += salesTaxTotal + importTaxTotal;
                    }
                }
                total += salesTax;
                labelText.Append($"Sales Taxes: ${salesTax:#.00}\r\n");
                labelText.Append($"Total: ${total:#.00}");
                this.panel1.Controls.Add(new Label() { AutoSize = true, Text = labelText.ToString() });
            }
            this.panel1.Refresh();
            this.totalItemsInCart.Text = $@"{rows.Count}";
            this.Refresh();
        }

        private static string ConvertRowToOutput(DataRow row)
        {
            return $"{row[(int)ItemsColIndex.Name]}: ${row[(int)ItemsColIndex.Total]}";
        }

    }
}