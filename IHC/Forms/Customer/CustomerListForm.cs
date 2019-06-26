using IHC.Forms.Customer;
using IHC.Models;
using IHC.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IHC
{
    public partial class CustomerListForm : Form
    {
        private CustomerService _service;
        private ProjectService _projectService;
        public CustomerListForm()
        {
            InitializeComponent();
            _service = new CustomerService();
            _projectService = new ProjectService();
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
            IEnumerable<Customer> customers = _service.ReadAll(true);
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
                    string id = dgvCustomers.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if (id.Trim() != "")
                    {
                        if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja excluir o cliente?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            int idI = int.Parse(id);
                            if (!_projectService.ExistsWithCustomerId(idI))
                            {
                                _service.ActivateOrDeactivateById(idI, false);
                                LoadToDataGridView();
                            }
                            else
                            {
                                MessageBox.Show("Clientes associados a projetos não podem ser excluídos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else if (e.ColumnIndex == 3)
                {
                    string id = dgvCustomers.SelectedCells[0].Value.ToString();
                    CustomerForm customerForm = new CustomerForm(long.Parse(id));
                    customerForm.ShowDialog();
                }
            }
            catch (Exception)
            {

            }
        }

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            DeletedCustomersList deletedCustomersList = new DeletedCustomersList();
            deletedCustomersList.ShowDialog();
        }
    }
}
