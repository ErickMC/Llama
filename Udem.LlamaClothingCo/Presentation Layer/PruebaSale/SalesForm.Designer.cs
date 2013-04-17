namespace PruebaSale
{
    partial class SalesForm
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
            this.showClient = new System.Windows.Forms.DataGridView();
            this.clientIdComboBox = new System.Windows.Forms.ComboBox();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.showOrders = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.createOrderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.showClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showOrders)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // showClient
            // 
            this.showClient.AllowUserToAddRows = false;
            this.showClient.AllowUserToDeleteRows = false;
            this.showClient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.showClient.BackgroundColor = System.Drawing.SystemColors.Control;
            this.showClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showClient.Location = new System.Drawing.Point(12, 65);
            this.showClient.Name = "showClient";
            this.showClient.ReadOnly = true;
            this.showClient.RowHeadersVisible = false;
            this.showClient.Size = new System.Drawing.Size(575, 95);
            this.showClient.TabIndex = 0;
            // 
            // clientIdComboBox
            // 
            this.clientIdComboBox.DataSource = this.clientBindingSource;
            this.clientIdComboBox.DisplayMember = "ClientId";
            this.clientIdComboBox.FormattingEnabled = true;
            this.clientIdComboBox.Location = new System.Drawing.Point(61, 24);
            this.clientIdComboBox.Name = "clientIdComboBox";
            this.clientIdComboBox.Size = new System.Drawing.Size(41, 21);
            this.clientIdComboBox.TabIndex = 1;
            this.clientIdComboBox.ValueMember = "ClientId";
            this.clientIdComboBox.SelectedIndexChanged += new System.EventHandler(this.clientIdComboBox_SelectedIndexChanged);
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(Udem.LlamaClothingCo.Entities.Client);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ClientId";
            // 
            // showOrders
            // 
            this.showOrders.AllowUserToAddRows = false;
            this.showOrders.AllowUserToDeleteRows = false;
            this.showOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.showOrders.BackgroundColor = System.Drawing.SystemColors.Control;
            this.showOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showOrders.Location = new System.Drawing.Point(4, 19);
            this.showOrders.Name = "showOrders";
            this.showOrders.ReadOnly = true;
            this.showOrders.RowHeadersVisible = false;
            this.showOrders.Size = new System.Drawing.Size(565, 95);
            this.showOrders.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.showOrders);
            this.groupBox1.Location = new System.Drawing.Point(12, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 152);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order History";
            // 
            // createOrderButton
            // 
            this.createOrderButton.Location = new System.Drawing.Point(626, 165);
            this.createOrderButton.Name = "createOrderButton";
            this.createOrderButton.Size = new System.Drawing.Size(75, 23);
            this.createOrderButton.TabIndex = 5;
            this.createOrderButton.Text = "Create Order";
            this.createOrderButton.UseVisualStyleBackColor = true;
            this.createOrderButton.Click += new System.EventHandler(this.createOrderButton_Click);
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 347);
            this.Controls.Add(this.createOrderButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clientIdComboBox);
            this.Controls.Add(this.showClient);
            this.Name = "SalesForm";
            this.Text = "Orders";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showOrders)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView showClient;
        private System.Windows.Forms.ComboBox clientIdComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.DataGridView showOrders;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button createOrderButton;
    }
}

