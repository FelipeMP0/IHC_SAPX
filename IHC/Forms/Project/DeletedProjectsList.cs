using IHC.Enums;
using IHC.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IHC.Forms.Project
{
    public partial class DeletedProjectsList : Form
    {
        private ProjectService projectService;
        private CustomerService customerService;

        public DeletedProjectsList()
        {
            InitializeComponent();
            projectService = new ProjectService();
            customerService = new CustomerService();
        }

        private void DgvProjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    string id = dgvProjects.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if (id.Trim() != "")
                    {
                        if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja restaurar o projeto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            projectService.ActivateOrDeactivateById(int.Parse(id), true);
                            LoadToDataGridView();
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void LoadToDataGridView()
        {
            projectService = new ProjectService();
            dgvProjects.Rows.Clear();
            IEnumerable<Models.Project> projects = projectService.ReadAll(false);
            foreach (var project in projects)
            {
                project.Customer = customerService.ReadById(project.CustomerId);
                dgvProjects.Rows.Add(project.Id, project.Name, project.Customer.Name, ProjectStateExtensions.ToDescriptionString(project.State), null);
            }
        }

        private void DeletedProjectsList_Load(object sender, EventArgs e)
        {
            LoadToDataGridView();
        }
    }
}
