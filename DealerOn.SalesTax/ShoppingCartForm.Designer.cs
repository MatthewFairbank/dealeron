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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShoppingCartForm));
            this.shoppingCartItemsLabel = new System.Windows.Forms.Label();
            this.shoppingCartItems = new System.Windows.Forms.TextBox();
            this.checkoutBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.totalItemsInCart = new System.Windows.Forms.Label();
            this.totalItemsInCartLabel = new System.Windows.Forms.Label();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // shoppingCartItemsLabel
            // 
            this.shoppingCartItemsLabel.AutoSize = true;
            this.shoppingCartItemsLabel.Location = new System.Drawing.Point(19, 158);
            this.shoppingCartItemsLabel.Name = "shoppingCartItemsLabel";
            this.shoppingCartItemsLabel.Size = new System.Drawing.Size(196, 25);
            this.shoppingCartItemsLabel.TabIndex = 1;
            this.shoppingCartItemsLabel.Text = "Shopping Cart Items:";
            // 
            // shoppingCartItems
            // 
            this.shoppingCartItems.Location = new System.Drawing.Point(19, 186);
            this.shoppingCartItems.Multiline = true;
            this.shoppingCartItems.Name = "shoppingCartItems";
            this.shoppingCartItems.Size = new System.Drawing.Size(771, 98);
            this.shoppingCartItems.TabIndex = 2;
            // 
            // checkoutBtn
            // 
            this.checkoutBtn.Location = new System.Drawing.Point(664, 290);
            this.checkoutBtn.Name = "checkoutBtn";
            this.checkoutBtn.Size = new System.Drawing.Size(126, 44);
            this.checkoutBtn.TabIndex = 3;
            this.checkoutBtn.Text = "Checkout";
            this.checkoutBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#337ab7");
            this.checkoutBtn.ForeColor = System.Drawing.Color.White;
            this.checkoutBtn.Click += new System.EventHandler(this.Checkout_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(510, 290);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(133, 44);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Clear";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.Clear_Click);
            // 
            // totalItemsInCart
            // 
            this.totalItemsInCart.AutoSize = true;
            this.totalItemsInCart.Location = new System.Drawing.Point(195, 380);
            this.totalItemsInCart.Name = "totalItemsInCart";
            this.totalItemsInCart.Size = new System.Drawing.Size(23, 25);
            this.totalItemsInCart.TabIndex = 7;
            this.totalItemsInCart.Text = "0";
            // 
            // totalItemsInCartLabel
            // 
            this.totalItemsInCartLabel.AutoSize = true;
            this.totalItemsInCartLabel.Location = new System.Drawing.Point(15, 380);
            this.totalItemsInCartLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalItemsInCartLabel.Name = "totalItemsInCartLabel";
            this.totalItemsInCartLabel.Size = new System.Drawing.Size(176, 25);
            this.totalItemsInCartLabel.TabIndex = 6;
            this.totalItemsInCartLabel.Text = "Total Items in Cart:";
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.Location = new System.Drawing.Point(16, 33);
            this.instructionsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(1013, 75);
            this.instructionsLabel.TabIndex = 0;
            this.instructionsLabel.Text = resources.GetString("instructionsLabel.Text");
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(19, 431);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 338);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Input Example: 1 import book at 10.00";
            // 
            // ShoppingCartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1914, 1046);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.totalItemsInCartLabel);
            this.Controls.Add(this.totalItemsInCart);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.checkoutBtn);
            this.Controls.Add(this.shoppingCartItems);
            this.Controls.Add(this.shoppingCartItemsLabel);
            this.Name = "ShoppingCartForm";
            this.Text = "Shopping Cart Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Label shoppingCartItemsLabel;
        private System.Windows.Forms.TextBox shoppingCartItems;
        private System.Windows.Forms.Button checkoutBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label totalItemsInCart;
        private System.Windows.Forms.Label totalItemsInCartLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}