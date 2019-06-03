using IHC.Models;
using IHC.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IHC
{
    public partial class CustomerListForm : Form
    {
        public CustomerService _service;

        public CustomerListForm()
        {
            InitializeComponent();
            _service = new CustomerService();
        }

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            loadToDataGridView();
        }

        private void loadToDataGridView()
        {
            IEnumerable<Customer> customers =_service.ReadAll();
            foreach (var customer in customers)
            {
                dgpCustomers.Rows.Add(customer.Document, customer.Name, null, null);
            }
        }
    }
}
