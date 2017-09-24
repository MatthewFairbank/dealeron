using System;
using System.Windows.Forms;
using DealerOn.Data.Data;

namespace DealerOn.SalesTax
{
    internal static class Program
    {
        public static ShoppingCartDataSet Data;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                using (Data = ShoppingCartDataSet.Initialize())
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new ShoppingCartForm());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
