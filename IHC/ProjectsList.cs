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
        public ProjectsList()
        {
            InitializeComponent();
            _service = new ProjectService();
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

        private void loadProjectToDateGridView()
        {
            IEnumerable<Project> projects = _service.ReadAll();

            if (projects.Count() != 0)
            {
                foreach (var project in projects)
                {
                    dgvProjects.Rows.Add(project.Name, project.Customer.Name, ProjectStateExtensions.ToDescriptionString(project.State), null, null);
                }
            }
        }
    }
}
