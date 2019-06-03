using IHC.Enums;
using IHC.Models;
using IHC.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IHC
{
    public partial class ProjectForm : Form
    {
        ProjectService _service;
        CustomerService _customerService;
        JobRoleService _jobRoleService;
        ManagerService _managerService;
        Manager defaultManager;

        public ProjectForm()
        {
            InitializeComponent();
            _service = new ProjectService();
            _customerService = new CustomerService();
            _jobRoleService = new JobRoleService();
            _managerService = new ManagerService();

            defaultManager = new Manager()
            {
                Id = 1,
                Name = "teste",
                Phone = "fasdfs",
                Email = "fasdf",
                Password = "fsadf"
            };

            defaultManager = _managerService.ReadById(defaultManager.Id);
            if (defaultManager == null)
            {
                defaultManager = _managerService.Create(defaultManager);
            }
        }

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
        }

        private void BtnNovoRecurso_Click(object sender, EventArgs e)
        {
            JobRoleForm jobRoleForm = new JobRoleForm();
            jobRoleForm.ShowDialog();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            Customer customer = _customerService.ReadById(int.Parse(cbCliente.Text.Split(' ')[0]));
            Project project = new Project()
            {
                Name = txtNome.Text,
                StartDate = dtpInicio.Value,
                EndDate = dtpFim.Value,
                ExpectedReveneu = (double) numReceita.Value,
                State = ProjectStateExtensions.GetValueFromDescription<ProjectState>(cbEstado.Text),
                Manager = defaultManager,
                Customer = customer
            };

            if (customer.Projects == null)
            {
                customer.Projects = new List<Project>();
            }

            customer.Projects.Add(project);

            if (defaultManager.Projects == null)
            {
                defaultManager.Projects = new List<Project>();
            }

            defaultManager.Projects.Add(project);

            List<Planning> plannings = new List<Planning>();

            foreach (DataGridViewRow row in dgvRecursos.Rows)
            {
                long jobRoleId = Convert.ToInt64(row.Cells[0].Value);
                if (jobRoleId != 0)
                {
                    JobRole jobRole = _jobRoleService.ReadById(jobRoleId);

                    Planning planning = new Planning()
                    {
                        JobRole = jobRole,
                        Project = project
                    };

                    if (jobRole.Plannings == null)
                    {
                        jobRole.Plannings = new List<Planning>();
                    }

                    jobRole.Plannings.Add(planning);
                }
            }

            project.Plannings = plannings;

            _service.Create(project);
        }

        private void loadCustomersToComboBox()
        {
            IEnumerable<Customer> customers =_customerService.ReadAll();
            foreach (var customer in customers)
            {
                cbCliente.Items.Add(customer.Id + " " + customer.Name);
            }
        }

        private void loadJobRolesToComboBox()
        {
            IEnumerable<JobRole> jobRoles = _jobRoleService.ReadAll();
            foreach (var jobRole in jobRoles)
            {
                cbRecurso.Items.Add(jobRole.Id + " " + jobRole.Name + " " + jobRole.Level);
            }
        }

        private void loadStateToComboBox()
        {
            cbEstado.Items.Add(ProjectStateExtensions.ToDescriptionString(ProjectState.IN_NEGOCIATION));
            cbEstado.Items.Add(ProjectStateExtensions.ToDescriptionString(ProjectState.CONTRACTED));
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            loadCustomersToComboBox();
            loadJobRolesToComboBox();
            loadStateToComboBox();
        }

        private void BtnAdicionarRecurso_Click(object sender, EventArgs e)
        {
            string[] values = cbRecurso.Text.Split(' ');
            dgvRecursos.Rows.Add(values[0], values[1], values[2], numHoras.Value.ToString(), null);
        }
    }
}
