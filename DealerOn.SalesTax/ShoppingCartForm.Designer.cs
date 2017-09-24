using System.Drawing;
using DealerOn.Data.Data;

namespace DealerOn.SalesTax
{
    partial class ShoppingCartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShoppingCartForm));
            this.shoppingCartItemsLabel = new System.Windows.Forms.Label();
            this.shoppingCartItems = new System.Windows.Forms.TextBox();
            this.checkoutBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.inputDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseTaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importTaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isTaxExemptDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isImportedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.itemsDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totalItemsInCart = new System.Windows.Forms.Label();
            this.totalItemsInCartLabel = new System.Windows.Forms.Label();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.completeBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsDataTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // shoppingCartItemsLabel
            // 
            this.shoppingCartItemsLabel.AutoSize = true;
            this.shoppingCartItemsLabel.Location = new System.Drawing.Point(11, 95);
            this.shoppingCartItemsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.shoppingCartItemsLabel.Name = "shoppingCartItemsLabel";
            this.shoppingCartItemsLabel.Size = new System.Drawing.Size(139, 17);
            this.shoppingCartItemsLabel.TabIndex = 1;
            this.shoppingCartItemsLabel.Text = "Shopping Cart Items:";
            // 
            // shoppingCartItems
            // 
            this.shoppingCartItems.Location = new System.Drawing.Point(14, 124);
            this.shoppingCartItems.Margin = new System.Windows.Forms.Padding(2);
            this.shoppingCartItems.Multiline = true;
            this.shoppingCartItems.Name = "shoppingCartItems";
            this.shoppingCartItems.Size = new System.Drawing.Size(562, 67);
            this.shoppingCartItems.TabIndex = 2;
            // 
            // checkoutBtn
            // 
            this.checkoutBtn.Location = new System.Drawing.Point(115, 206);
            this.checkoutBtn.Margin = new System.Windows.Forms.Padding(2);
            this.checkoutBtn.Name = "checkoutBtn";
            this.checkoutBtn.Size = new System.Drawing.Size(92, 29);
            this.checkoutBtn.TabIndex = 3;
            this.checkoutBtn.Text = "Checkout";
            this.checkoutBtn.UseVisualStyleBackColor = true;
            this.checkoutBtn.Click += new System.EventHandler(this.Checkout_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(14, 206);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(97, 29);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Clear";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.Clear_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inputDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.baseTaxDataGridViewTextBoxColumn,
            this.importTaxDataGridViewTextBoxColumn,
            this.isTaxExemptDataGridViewCheckBoxColumn,
            this.isImportedDataGridViewCheckBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.Type});
            this.dataGridView1.DataSource = this.itemsDataTableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(11, 282);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 31;
            this.dataGridView1.Size = new System.Drawing.Size(1425, 58);
            this.dataGridView1.TabIndex = 5;
            // 
            // inputDataGridViewTextBoxColumn
            // 
            this.inputDataGridViewTextBoxColumn.DataPropertyName = "Input";
            this.inputDataGridViewTextBoxColumn.HeaderText = "Input";
            this.inputDataGridViewTextBoxColumn.Name = "inputDataGridViewTextBoxColumn";
            this.inputDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            // 
            // baseTaxDataGridViewTextBoxColumn
            // 
            this.baseTaxDataGridViewTextBoxColumn.DataPropertyName = "BaseTax";
            this.baseTaxDataGridViewTextBoxColumn.HeaderText = "BaseTax";
            this.baseTaxDataGridViewTextBoxColumn.Name = "baseTaxDataGridViewTextBoxColumn";
            this.baseTaxDataGridViewTextBoxColumn.ReadOnly = true;
            this.baseTaxDataGridViewTextBoxColumn.Visible = false;
            // 
            // importTaxDataGridViewTextBoxColumn
            // 
            this.importTaxDataGridViewTextBoxColumn.DataPropertyName = "ImportTax";
            this.importTaxDataGridViewTextBoxColumn.HeaderText = "ImportTax";
            this.importTaxDataGridViewTextBoxColumn.Name = "importTaxDataGridViewTextBoxColumn";
            this.importTaxDataGridViewTextBoxColumn.ReadOnly = true;
            this.importTaxDataGridViewTextBoxColumn.Visible = false;
            // 
            // isTaxExemptDataGridViewCheckBoxColumn
            // 
            this.isTaxExemptDataGridViewCheckBoxColumn.DataPropertyName = "IsTaxExempt";
            this.isTaxExemptDataGridViewCheckBoxColumn.HeaderText = "IsTaxExempt";
            this.isTaxExemptDataGridViewCheckBoxColumn.Name = "isTaxExemptDataGridViewCheckBoxColumn";
            // 
            // isImportedDataGridViewCheckBoxColumn
            // 
            this.isImportedDataGridViewCheckBoxColumn.DataPropertyName = "IsImported";
            this.isImportedDataGridViewCheckBoxColumn.HeaderText = "IsImported";
            this.isImportedDataGridViewCheckBoxColumn.Name = "isImportedDataGridViewCheckBoxColumn";
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalDataGridViewTextBoxColumn.Visible = false;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // itemsDataTableBindingSource
            // 
            this.itemsDataTableBindingSource.DataSource = typeof(DealerOn.Data.Data.ItemsDataTable);
            // 
            // totalItemsInCart
            // 
            this.totalItemsInCart.AutoSize = true;
            this.totalItemsInCart.Location = new System.Drawing.Point(142, 253);
            this.totalItemsInCart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalItemsInCart.Name = "totalItemsInCart";
            this.totalItemsInCart.Size = new System.Drawing.Size(16, 17);
            this.totalItemsInCart.TabIndex = 7;
            this.totalItemsInCart.Text = "0";
            // 
            // totalItemsInCartLabel
            // 
            this.totalItemsInCartLabel.AutoSize = true;
            this.totalItemsInCartLabel.Location = new System.Drawing.Point(11, 253);
            this.totalItemsInCartLabel.Name = "totalItemsInCartLabel";
            this.totalItemsInCartLabel.Size = new System.Drawing.Size(126, 17);
            this.totalItemsInCartLabel.TabIndex = 6;
            this.totalItemsInCartLabel.Text = "Total Items in Cart:";
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.Location = new System.Drawing.Point(12, 22);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(742, 51);
            this.instructionsLabel.TabIndex = 0;
            this.instructionsLabel.Text = resources.GetString("instructionsLabel.Text");
            // 
            // completeBtn
            // 
            this.completeBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.completeBtn.ForeColor = System.Drawing.Color.AliceBlue;
            this.completeBtn.Location = new System.Drawing.Point(479, 206);
            this.completeBtn.Name = "completeBtn";
            this.completeBtn.Size = new System.Drawing.Size(97, 29);
            this.completeBtn.TabIndex = 8;
            this.completeBtn.Text = "Completed";
            this.completeBtn.UseVisualStyleBackColor = false;
            // 
            // ShoppingCartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 697);
            this.Controls.Add(this.completeBtn);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.totalItemsInCartLabel);
            this.Controls.Add(this.totalItemsInCart);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.checkoutBtn);
            this.Controls.Add(this.shoppingCartItems);
            this.Controls.Add(this.shoppingCartItemsLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ShoppingCartForm";
            this.Text = "Shopping Cart Form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsDataTableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Label shoppingCartItemsLabel;
        private System.Windows.Forms.TextBox shoppingCartItems;
        private System.Windows.Forms.Button checkoutBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource itemsDataTableBindingSource;
        private System.Windows.Forms.Label totalItemsInCart;
        private System.Windows.Forms.Label totalItemsInCartLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseTaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importTaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isTaxExemptDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isImportedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn Type;
        private System.Windows.Forms.Button completeBtn;
    }
}