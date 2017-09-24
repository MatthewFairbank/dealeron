using System.Data;

namespace DealerOn.Data.Data
{
    public enum ItemsColIndex
    {
        Input,
        Name,
        Qty,
        Price,
        BaseTax,
        ImportTax,
        IsTaxExempt,
        IsImported,
        Total
    }
    public class ItemsDataTable : DataTable
    {
        public int InputIndex = 0;
        public int NameIndex = 1;
        public int QtyIndex = 2;
        public int PriceIndex = 3;
        public int BaseTaxIndex = 4;
        public int ImportTaxIndex = 5;
        public int IsTaxExemptIndex = 6;
        public int IsImportedIndex = 7;
        public int TotalIndex = 8;

        public DataColumn Input = new DataColumn("Input", typeof(string));
        public DataColumn Name = new DataColumn("Name", typeof(string));
        public DataColumn Qty = new DataColumn("Qty", typeof(int));
        public DataColumn Price = new DataColumn("Price", typeof(decimal));
        public DataColumn BaseTax = new DataColumn("BaseTax", typeof(decimal));
        public DataColumn ImportTax = new DataColumn("ImportTax", typeof(decimal));
        public DataColumn IsTaxExempt = new DataColumn("IsTaxExempt", typeof(bool));
        public DataColumn IsImported = new DataColumn("IsImported", typeof(bool));
        public DataColumn Total = new DataColumn("Total", typeof(decimal));
        public ItemsDataTable()
        {
            this.TableName = "Items";
            this.Columns.AddRange(new DataColumn[] { this.Input, this.Name, this.Qty, this.Price, this.BaseTax, this.ImportTax, this.IsTaxExempt, this.IsImported, this.Total });
        }

        //public void AddNewRow(Product p)
        //{
        //    this.Rows.Add(p);
        //}
    }
}