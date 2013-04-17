using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Udem.LlamaClothingCo.Entities;
using Udem.LlamaClothingCo.Business;

namespace PruebaSale
{
    public partial class SalesForm : Form
    {

        private ClientLogic clientLogic = new ClientLogic();
        private ItemLogic itemLogic = new ItemLogic();
        private SaleLogic saleLogic = new SaleLogic();
        private BindingSource ordersBS;
        public SalesForm()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ICollection<Client> allClients = clientLogic.GetAllActiveClients();
            clientIdComboBox.DataSource = allClients;
            clientIdComboBox.SelectedIndex = 0;
            for (int i = 7; i < 11; i++)
            {
                
                showClient.Columns[i].Visible = false;
            }
            
        }

        private void clientIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource clientBS = new BindingSource();
            clientBS.Add(clientLogic.GetClientByID( (int) clientIdComboBox.SelectedValue));
            showClient.DataSource = clientBS;
            refreshOrderBindings();
            
            
        }

        private void createOrderButton_Click(object sender, EventArgs e)
        {
            CreateOrderForm orderForm = new CreateOrderForm((int)clientIdComboBox.SelectedValue);
            if (orderForm.ShowDialog() == DialogResult.OK)
            {
                refreshOrderBindings();
            }
        }

        private void refreshOrderBindings()
        {
            ordersBS = new BindingSource();
            showOrders.DataSource = ordersBS;
            ordersBS.DataSource = saleLogic.GetSalesOfAClient(clientLogic.GetClientByID((int)clientIdComboBox.SelectedValue));
            for (int i = 5; i < 8; i++)
            {

                showOrders.Columns[i].Visible = false;
            }
        }

      

        

       
    }
}
