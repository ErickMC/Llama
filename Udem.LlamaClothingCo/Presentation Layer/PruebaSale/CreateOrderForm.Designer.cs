namespace PruebaSale
{
    partial class CreateOrderForm
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
            this.showItems = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.quantityBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.itemNameLabel = new System.Windows.Forms.Label();
            this.addToCart = new System.Windows.Forms.Button();
            this.currentCart = new System.Windows.Forms.DataGridView();
            this.completeSale = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.showItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentCart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // showItems
            // 
            this.showItems.AllowUserToAddRows = false;
            this.showItems.AllowUserToDeleteRows = false;
            this.showItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.showItems.BackgroundColor = System.Drawing.SystemColors.Control;
            this.showItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.showItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showItems.Location = new System.Drawing.Point(18, 43);
            this.showItems.MultiSelect = false;
            this.showItems.Name = "showItems";
            this.showItems.ReadOnly = true;
            this.showItems.RowHeadersVisible = false;
            this.showItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.showItems.Size = new System.Drawing.Size(488, 95);
            this.showItems.TabIndex = 2;
            this.showItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.showItems_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Quantity";
            // 
            // quantityBox
            // 
            this.quantityBox.Location = new System.Drawing.Point(428, 172);
            this.quantityBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityBox.Name = "quantityBox";
            this.quantityBox.Size = new System.Drawing.Size(66, 20);
            this.quantityBox.TabIndex = 5;
            this.quantityBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Item: ";
            // 
            // itemNameLabel
            // 
            this.itemNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.itemNameLabel.Location = new System.Drawing.Point(350, 144);
            this.itemNameLabel.Name = "itemNameLabel";
            this.itemNameLabel.Size = new System.Drawing.Size(144, 23);
            this.itemNameLabel.TabIndex = 7;
            this.itemNameLabel.Text = " ";
            // 
            // addToCart
            // 
            this.addToCart.Location = new System.Drawing.Point(419, 198);
            this.addToCart.Name = "addToCart";
            this.addToCart.Size = new System.Drawing.Size(75, 23);
            this.addToCart.TabIndex = 8;
            this.addToCart.Text = "Add to Cart";
            this.addToCart.UseVisualStyleBackColor = true;
            this.addToCart.Click += new System.EventHandler(this.addToCart_Click);
            // 
            // currentCart
            // 
            this.currentCart.AllowUserToAddRows = false;
            this.currentCart.AllowUserToDeleteRows = false;
            this.currentCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.currentCart.BackgroundColor = System.Drawing.SystemColors.Control;
            this.currentCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currentCart.Location = new System.Drawing.Point(6, 19);
            this.currentCart.MultiSelect = false;
            this.currentCart.Name = "currentCart";
            this.currentCart.ReadOnly = true;
            this.currentCart.RowHeadersVisible = false;
            this.currentCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.currentCart.Size = new System.Drawing.Size(476, 95);
            this.currentCart.TabIndex = 9;
            // 
            // completeSale
            // 
            this.completeSale.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.completeSale.Location = new System.Drawing.Point(419, 117);
            this.completeSale.Name = "completeSale";
            this.completeSale.Size = new System.Drawing.Size(75, 23);
            this.completeSale.TabIndex = 10;
            this.completeSale.Text = "Complete Sale";
            this.completeSale.UseVisualStyleBackColor = true;
            this.completeSale.Click += new System.EventHandler(this.completeSale_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.itemNameLabel);
            this.groupBox1.Controls.Add(this.quantityBox);
            this.groupBox1.Controls.Add(this.addToCart);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 230);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Catalog";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.currentCart);
            this.groupBox2.Controls.Add(this.completeSale);
            this.groupBox2.Location = new System.Drawing.Point(12, 249);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 146);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cart";
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 407);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.showItems);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "CreateOrderForm";
            this.Text = "CreateOrderForm";
            this.Load += new System.EventHandler(this.CreateOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentCart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView showItems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown quantityBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label itemNameLabel;
        private System.Windows.Forms.Button addToCart;
        private System.Windows.Forms.DataGridView currentCart;
        private System.Windows.Forms.Button completeSale;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}