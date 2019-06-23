using IHC.Enums;
using IHC.Models;
using IHC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IHC
{
    public partial class ProjectsList : Form
    {
        ProjectService _service;
        CustomerService _customerService;
        ManagerService _managerService;
        PlanningService _planningService;
        DateTime defaultStartTime;
        DateTime defaultEndTime;

        public ProjectsList()
        {
            InitializeComponent();
            _service = new ProjectService();
            _customerService = new CustomerService();
            _managerService = new ManagerService();
            _planningService = new PlanningService();
            Activated += new EventHandler(ProjectsList_Activated);
            defaultStartTime = DateTime.Now.AddMonths(-1);
            defaultEndTime = DateTime.Now;
            dtpInicio.Value = defaultStartTime;
            dtpFim.Value = defaultEndTime;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm();
            projectForm.ShowDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();

            reports.ShowDialog();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            CustomerListForm customerListForm = new CustomerListForm();
            customerListForm.ShowDialog();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            JobRoleForm jobRoleForm = new JobRoleForm();
            jobRoleForm.ShowDialog();
        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            JobRoleListForm jobRoleListForm = new JobRoleListForm();
            jobRoleListForm.ShowDialog();
        }

        private void ProjectsList_Load(object sender, EventArgs e)
        {
            LoadStateToComboBox();
            LoadCustomersToComboBox();
            LoadToDataGridView();
        }

        private void ProjectsList_Activated(object sender, EventArgs e)
        {
            LoadStateToComboBox();
            LoadCustomersToComboBox();
            LoadToDataGridView();
        }

        private void LoadToDataGridView()
        {
            _service = new ProjectService();

            dgvProjects.Rows.Clear();

            long customerId = cbCliente.Text != "" ? long.Parse(cbCliente.Text.Split(' ')[0]) : 0;
            ProjectState state;
            try
            {
                state = cbEstado.Text == "" || cbEstado.Text == "Todos os Estados" ? ProjectState.NULL : ProjectStateExtensions.GetValueFromDescription<ProjectState>(cbEstado.Text);
            }
            catch (ArgumentException e)
            {
                state = ProjectState.NULL;
            }
            IEnumerable<Project> projects = _service.ReadWithParameters(dtpInicio.Value, dtpFim.Value, customerId, state);

            if (projects.Count() != 0)
            {
                foreach (var project in projects)
                {
                    project.Customer = _customerService.ReadById(project.CustomerId);
                    project.Manager = _managerService.ReadById(project.ManagerId);
                    dgvProjects.Rows.Add(project.Id, project.Name, project.Customer.Name, ProjectStateExtensions.ToDescriptionString(project.State), null, null);
                }
            }
        }

        private void LoadStateToComboBox()
        {
            cbEstado.Items.Clear();
            cbEstado.Items.Add(ProjectStateExtensions.ToDescriptionString(ProjectState.IN_NEGOCIATION));
            cbEstado.Items.Add(ProjectStateExtensions.ToDescriptionString(ProjectState.CONTRACTED));
            cbEstado.Items.Add("Todos os Estados");
        }

        private void LoadCustomersToComboBox()
        {
            cbCliente.Items.Clear();
            _customerService = new CustomerService();
            cbCliente.Items.Clear();
            IEnumerable<Customer> customers = _customerService.ReadAll();
            foreach (var customer in customers)
            {
                cbCliente.Items.Add(customer.Id + " " + customer.Name);
            }
        }

        private void BtnDetalhes_Click(object sender, EventArgs e)
        {
        }

        private void DgvProjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    string id = dgvProjects.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if (id.Trim() != "")
                    {
                        if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja excluir o projeto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            _service.DeleteById(int.Parse(id));
                            LoadToDataGridView();
                        }
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    string id = dgvProjects.SelectedCells[0].Value.ToString();
                    Project project = _service.ReadById(long.Parse(id));
                    ProjectForm projectForm = new ProjectForm(project.Id);
                    projectForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            LoadToDataGridView();
        }
    }
}
