using IHC.Models;
using IHC.Services;
using System;
using System.Collections.Generic;
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
            Activated += new EventHandler(CustomerListForm_Activated);
        }

        private void CustomerListForm_Activated(object sender, EventArgs e)
        {
            LoadToDataGridView();
        }

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            LoadToDataGridView();
        }

        private void LoadToDataGridView()
        {
            _service = new CustomerService();
            dgvCustomers.Rows.Clear();
            IEnumerable<Customer> customers = _service.ReadAll();
            foreach (var customer in customers)
            {
                dgvCustomers.Rows.Add(customer.Id, customer.Document, customer.Name, null, null);
            }
        }

        private void DgpCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja excluir o cliente?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        string id = dgvCustomers.SelectedCells[0].Value.ToString();
                        _service.DeleteById(int.Parse(id));
                        LoadToDataGridView();
                    }
                }
                else if (e.ColumnIndex == 3)
                {
                    string id = dgvCustomers.SelectedCells[0].Value.ToString();
                    CustomerForm customerForm = new CustomerForm(long.Parse(id));
                    customerForm.ShowDialog();
                }
            } catch (Exception ex)
            {

            }
        }
    }
}
