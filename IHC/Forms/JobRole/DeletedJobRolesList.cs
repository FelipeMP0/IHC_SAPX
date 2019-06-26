using IHC.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IHC.Forms.JobRole
{
    public partial class DeletedJobRolesList : Form
    {
        public JobRoleService jobRoleService;

        public DeletedJobRolesList()
        {
            InitializeComponent();
            jobRoleService = new JobRoleService();
        }

        private void DeletedJobRolesList_Load(object sender, EventArgs e)
        {
            LoadToDataGridView();
        }

        private void LoadToDataGridView()
        {
            jobRoleService = new JobRoleService();
            dgvJobRoles.Rows.Clear();
            IEnumerable<Models.JobRole> jobRoles = jobRoleService.ReadAll(false);
            foreach (var jobRole in jobRoles)
            {
                dgvJobRoles.Rows.Add(jobRole.Id, jobRole.Name, jobRole.Level, null, null);
            }
        }

        private void DgvJobRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    string id = dgvJobRoles.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if (id.Trim() != "")
                    {
                        if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja restaurar o cargo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            jobRoleService.ActivateOrDeactivateById(int.Parse(id), true);
                            LoadToDataGridView();
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            DeletedJobRolesList deletedJobRolesList = new DeletedJobRolesList();
            deletedJobRolesList.ShowDialog();
        }
    }
}
