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
        public ProjectsList()
        {
            InitializeComponent();
            _service = new ProjectService();
            _customerService = new CustomerService();
            _managerService = new ManagerService();
            _planningService = new PlanningService();
            Activated += new EventHandler(ProjectsList_Activated);
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
            loadProjectToDateGridView();
        }

        private void ProjectsList_Activated(object sender, EventArgs e)
        {
            loadProjectToDateGridView();
        }

        private void loadProjectToDateGridView()
        {
            dgvProjects.Rows.Clear();
            IEnumerable<Project> projects = _service.ReadAll();

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

        private void BtnDetalhes_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedCells.Count > 0)
            {
                string id = dgvProjects.SelectedCells[0].Value.ToString();
                Project project = _service.ReadById(int.Parse(id));

                project.Customer = _customerService.ReadById(project.CustomerId);
                project.Manager = _managerService.ReadById(project.ManagerId);
                project.Plannings = _planningService.ReadAllByProjectId(project.Id).ToList();

                //Mostrar detalhes
            }
        }

        private void DgvProjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                string id = dgvProjects.SelectedCells[0].Value.ToString();
                _service.DeleteById(int.Parse(id));
                loadProjectToDateGridView();
            }
        }
    }
}
