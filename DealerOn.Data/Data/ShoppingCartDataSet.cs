using System.Data;

namespace DealerOn.Data.Data
{
    public class ShoppingCartDataSet : DataSet
    {
        public ShoppingCartDataSet()
        {
            this.DataSetName = "ShoppingCart";
            this.Tables.Add(new ItemsDataTable());
        }

        public static ShoppingCartDataSet Initialize()
        {
            return new ShoppingCartDataSet();
        }

        public static ItemsDataTable GetItemsTable()
        {
            return (ItemsDataTable) new ShoppingCartDataSet().Tables[0];
        }
    }
}