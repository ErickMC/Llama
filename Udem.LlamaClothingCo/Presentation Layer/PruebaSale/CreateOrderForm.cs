using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Udem.LlamaClothingCo.Entities;
using Udem.LlamaClothingCo.Business;

namespace PruebaSale
{
    public partial class CreateOrderForm : Form
    {
        private ItemLogic itemLogic = new ItemLogic();
        private SaleLogic saleLogic = new SaleLogic();
        private ClientLogic clientLogic = new ClientLogic();
        
        private readonly int clientId;
        private List<SaleDetail> details = new List<SaleDetail>();
        private Sale sale;
        private BindingSource cartBS;
        public CreateOrderForm(int id)
        {
            clientId = id;
            sale = new Sale { ClientId = id };
            InitializeComponent();
        }

        private void CreateOrderForm_Load(object sender, EventArgs e)
        {
            BindingSource itemsBS = new BindingSource();
            var allItems = itemLogic.GetActiveItems();
            foreach (var item in allItems)
            {
                itemsBS.Add(item);
            }
            
            showItems.DataSource = itemsBS;

            for (int i = 6; i < 9; i++)
            {

                showItems.Columns[i].Visible = false;
            }
           cartBS= new BindingSource();
            currentCart.DataSource = cartBS;
            cartBS.DataSource = details;

        }

        private void showItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            itemNameLabel.Text = showItems.SelectedRows[0].Cells["Name"].Value.ToString();
        }

        private void addToCart_Click(object sender, EventArgs e)
        {
            int itemId = (int)showItems.SelectedRows[0].Cells["ItemId"].Value;
            SaleDetail detail = new SaleDetail { SaleId = sale.SaleId, ItemId = itemId, Quantity = (int) quantityBox.Value };
            if (details.Exists(s => s.SaleId == detail.SaleId && s.ItemId == detail.ItemId))
            {
                details.Remove(details.Find(s => s.SaleId == detail.SaleId && s.ItemId == detail.ItemId));
            }
            details.Add(detail);
            refreshCartBinding();
        }

        private void refreshCartBinding()
        {
            cartBS= new BindingSource();
            currentCart.DataSource = cartBS;
            cartBS.DataSource = details;
            for (int i = 3; i < 5; i++)
            {

                currentCart.Columns[i].Visible = false;
            }
        }

        private void completeSale_Click(object sender, EventArgs e)
        {
            sale.Date = DateTime.Now;
            sale.ShippingAddressId = 4;
            saleLogic.AddSale(sale, details);
          
        }
    }
}
