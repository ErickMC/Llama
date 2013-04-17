using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Udem.LlamaClothingCo.Entities;
using Udem.LlamaClothingCo.Managers;
using System.Data.Objects;

namespace Prueba
{
    public partial class Prueba : Form
    {
        public Prueba()
        {
            InitializeComponent();
        }

        private void Prueba_Load(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            ClientManager clientManager = new ClientManager();
            List<Client> query = clientManager.GetActiveClients().ToList();
            bs.DataSource = query.ToList();
            dataGridView1.DataSource = bs;
            foreach (var item in query)
            {
                listBox1.Items.Add(item);
            }

        }
    }
}
