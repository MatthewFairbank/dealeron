using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DealerOn.Data.Data;
using DealerOn.Data.Entities;
using DealerOn.Data.Enums;
using DealerOn.Helpers;

namespace DealerOn.SalesTax
{
    public partial class ShoppingCartForm : Form
    {
        private readonly BindingSource _bindingSrc;

        private readonly ItemsDataTable _src;

        private readonly IList<string> Types = new List<string>()
        {
            $"{ProductType.Book}",
            $"{ProductType.Food}",
            $"{ProductType.MedicalProduct}",
            $"{ProductType.Other}"
        };

        public ShoppingCartForm()
        {
            InitializeComponent();
            Type.DataSource = Types;
            _bindingSrc = new BindingSource() {DataSource = ShoppingCartDataSet.GetItemsTable()};
            _src = (ItemsDataTable) _bindingSrc.DataSource;
            UpdateDataGridView();
        }

        public void AddRow(Product p)
        {
            _src.Rows.Add(p.Input, p.Name, p.Qty, p.Price, p.BaseTax, p.ImportTax, p.IsTaxExempt, p.IsImported,
                p.Total);
        }

        private void Checkout_Click(object sender, EventArgs evt)
        {
            var inputs = StringHelper.SplitByNewLine(this.shoppingCartItems.Text);
            foreach (var input in inputs)
            {
                var matches = RegexHelper.InputRegex.Matches(input);
                var product = GetProductFromInput(matches);
                AddRow(product);
            }
            this.UpdateDataGridView();
        }

        private void Clear_Click(object sender, EventArgs evt)
        {
            this.shoppingCartItems.Text = string.Empty;
            _src.Clear();
            _bindingSrc.ResetBindings(true);
            this.UpdateDataGridView();
        }


        private static Product GetProductFromInput(MatchCollection matches)
        {
            var product = new Product();
            foreach (Match match in matches)
            {
                Console.WriteLine(match);
                for (int i = 0; i < match.Groups.Count; i++)
                {
                    switch (i)
                    {
                        case (int) InputRegexMatch.FullValue:
                            product.Input = match.Groups[i].Value;
                            break;
                        case (int) InputRegexMatch.Qty:
                            product.Qty = int.TryParse(match.Groups[i].Value, out var qty) ? qty : 0;
                            break;
                        case (int) InputRegexMatch.Item:
                            product.Name = match.Groups[i].Value;
                            break;
                        case (int) InputRegexMatch.At:
                            break;
                        case (int) InputRegexMatch.Price:
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

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    var price = StringHelper.ConvertColToDecimal(dataGridView1.Rows[e.RowIndex].Cells[(int)ItemsColIndex.Price].Value.ToString());
        //    var importTax = _src.Rows[e.RowIndex][(int)ItemsColIndex.ImportTax];
        //    var baseTax = _src.Rows[e.RowIndex][(int)ItemsColIndex.BaseTax];

        //    if (e.ColumnIndex == (int)ItemsColIndex.IsTaxExempt || e.ColumnIndex == (int)ItemsColIndex.IsImported)
        //    {
        //        var value = !StringHelper.ConvertColToBool(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        //        switch (e.ColumnIndex)
        //        {
        //            case (int)ItemsColIndex.IsImported:
        //                var importTaxValue = value ? Product.CalculateImportTax(price) : 0;
        //                Console.Write($@"IsImported: {value}, Import Tax: {importTaxValue}, Price: {price}");
        //                _src.Rows[e.RowIndex][e.ColumnIndex] = value;
        //                importTax = importTaxValue;
        //                break;
        //            case (int)ItemsColIndex.IsTaxExempt:
        //                var baseTaxValue = value ? 0 : Product.CalculateBaseTax(price);
        //                Console.WriteLine($@"IsExempt: {value}, Base Tax: {baseTaxValue} Price: {price}");
        //                _src.Rows[e.RowIndex][e.ColumnIndex] = value;
        //                baseTax = baseTaxValue;
        //                break;
        //            default:
        //                break;
        //        }
        //        UpdateDataGridView();
        //    } else if (e.ColumnIndex == (int) ItemsColIndex.Type)
        //    {

        //    }
        //}

        private void UpdateDataGridView()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = _bindingSrc.DataSource;
            this.dataGridView1.AutoSize = true;
            this.dataGridView1.Visible = _src.Rows.Count > 0;
            this.totalItemsInCart.Text = $@"{_src.Rows.Count}";
            this.dataGridView1.EditMode = DataGridViewEditMode.EditOnF2;
            this.dataGridView1.Refresh();
            this.Refresh();
        }
    }
}