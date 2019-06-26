using IHC.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IHC.Forms.Customer
{
    public partial class DeletedCustomersList : Form
    {
        private CustomerService customerService;

        public DeletedCustomersList()
        {
            InitializeComponent();
            customerService = new CustomerService();
        }

        private void DgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    string id = dgvCustomers.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if (id.Trim() != "")
                    {
                        if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja restaurar o cliente?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            customerService.ActivateOrDeactivateById(int.Parse(id), true);
                            LoadToDataGridView();
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void DeletedCustomersList_Load(object sender, EventArgs e)
        {
            LoadToDataGridView();
        }

        private void LoadToDataGridView()
        {
            customerService = new CustomerService();
            dgvCustomers.Rows.Clear();
            IEnumerable<Models.Customer> customers = customerService.ReadAll(false);
            foreach (var customer in customers)
            {
                dgvCustomers.Rows.Add(customer.Id, customer.Document, customer.Name, null);
            }
        }
    }
}
