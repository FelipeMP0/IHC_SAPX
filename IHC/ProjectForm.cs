using IHC.Enums;
using IHC.Models;
using IHC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IHC
{
    public partial class ProjectForm : Form
    {
        ProjectService _service;
        CustomerService _customerService;
        JobRoleService _jobRoleService;
        ManagerService _managerService;
        PlanningService _planningService;
        Manager defaultManager;
        private long? idToUpdate;
        private List<Planning> planningsToDelete;

        public ProjectForm()
        {
            InitializeComponent();
            _service = new ProjectService();
            _customerService = new CustomerService();
            _jobRoleService = new JobRoleService();
            _managerService = new ManagerService();
            _planningService = new PlanningService();

            defaultManager = new Manager()
            {
                Id = 1,
                Name = "teste",
                Phone = "fasdfs",
                Email = "fasdf",
                Password = "fsadf"
            };

            Manager foundManager = _managerService.ReadById(defaultManager.Id);

            if (foundManager == null)
            {
                defaultManager = _managerService.Create(defaultManager);
            }

            Activated += new EventHandler(ProjectForm_Activated);
        }

        public ProjectForm(long id) : this()
        {
            idToUpdate = id;

            if (idToUpdate != null)
            {
                Project project = _service.ReadById(Convert.ToInt64(idToUpdate));
                project.Customer = _customerService.ReadById(project.CustomerId);
                project.Manager = _managerService.ReadById(project.ManagerId);
                project.Plannings = _planningService.ReadAllByProjectId(project.Id).ToList();
                txtNome.Text = project.Name;
                dtpInicio.Value = project.StartDate;
                dtpFim.Value = project.EndDate;
                numReceita.Value = (decimal) project.ExpectedReveneu;
                cbEstado.Text = ProjectStateExtensions.ToDescriptionString(project.State);
                cbCliente.Text = project.Customer.Id + " " + project.Customer.Name;
                
                if (project.Plannings != null)
                {
                    foreach (var planning in project.Plannings)
                    {
                        planning.JobRole = _jobRoleService.ReadById(planning.JobRoleId);
                        dgvRecursos.Rows.Add(planning.JobRole.Id, planning.JobRole.Name, planning.JobRole.Level, planning.PlannedHours);
                        planning.JobRole = null;
                    }
                }

                planningsToDelete = project.Plannings.ToList();
            }
        }

        private void ProjectForm_Activated(object sender, EventArgs e)
        {
            LoadCustomersToComboBox();
            LoadJobRolesToComboBox();
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
                ExpectedReveneu = (double)numReceita.Value,
                State = ProjectStateExtensions.GetValueFromDescription<ProjectState>(cbEstado.Text),
                ManagerId = defaultManager.Id,
                CustomerId = customer.Id
            };

            if (idToUpdate != null)
            {
                project.Id = Convert.ToInt64(idToUpdate);
            }

            List<Planning> plannings = new List<Planning>();

            foreach (DataGridViewRow row in dgvRecursos.Rows)
            {
                long jobRoleId = Convert.ToInt64(row.Cells[0].Value);
                if (jobRoleId != 0)
                {
                    JobRole jobRole = _jobRoleService.ReadById(jobRoleId);

                    Planning planning = new Planning()
                    {
                        JobRoleId = jobRole.Id,
                        ProjectId = project.Id,
                        PlannedHours = Convert.ToInt32(row.Cells[3].Value)
                    };

                    plannings.Add(planning);
                }
            }
            project.Plannings = plannings;

            if (idToUpdate == null)
            {
                _service.Create(project);
            }
            else
            {
                if (planningsToDelete != null) { 
                    foreach (var planning in planningsToDelete)
                    {
                        _planningService.DeleteById(planning.Id);
                    }
                }
                _service.Update(project);
            }
            MessageBox.Show("Projeto salvo com sucesso", "Projetos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Close();
        }

        private void LoadCustomersToComboBox()
        {
            cbCliente.Items.Clear();
            IEnumerable<Customer> customers = _customerService.ReadAll();
            foreach (var customer in customers)
            {
                cbCliente.Items.Add(customer.Id + " " + customer.Name);
            }
        }

        private void LoadJobRolesToComboBox()
        {
            cbRecurso.Items.Clear();
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
            LoadCustomersToComboBox();
            LoadJobRolesToComboBox();
            loadStateToComboBox();
        }

        private void BtnAdicionarRecurso_Click(object sender, EventArgs e)
        {
            string[] values = cbRecurso.Text.Split(' ');
            dgvRecursos.Rows.Add(values[0], values[1], values[2], numHoras.Value.ToString(), null);
        }

        private void DgvRecursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                dgvRecursos.Rows.RemoveAt(dgvRecursos.SelectedRows[0].Index);
            }
        }
    }
}
