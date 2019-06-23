using IHC.Models;
using IHC.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IHC
{
    public partial class JobRoleListForm : Form
    {
        private JobRoleService _service;
        private PlanningService _planningService;
        public JobRoleListForm()
        {
            InitializeComponent();
            _service = new JobRoleService();
            _planningService = new PlanningService();
            Activated += new EventHandler(JobRoleListForm_Activated);
        }

        private void JobRoleListForm_Activated(object sender, EventArgs e)
        {
            LoadToDataGridView();
        }

        private void JobRoleListForm_Load(object sender, EventArgs e)
        {
            LoadToDataGridView();
        }

        private void LoadToDataGridView()
        {
            _service = new JobRoleService();
            dgvJobRoles.Rows.Clear();
            IEnumerable<JobRole> jobRoles = _service.ReadAll();
            foreach (var jobRole in jobRoles)
            {
                dgvJobRoles.Rows.Add(jobRole.Id, jobRole.Name, jobRole.Level, null, null);
            }
        }

        private void DgpJobRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    string id = dgvJobRoles.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if (id.Trim() != "")
                    {
                        if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja excluir o cargo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            int idI = int.Parse(id);
                            if (!_planningService.ExistsWithJobRole(idI))
                            {
                                _service.DeleteById(idI);
                                LoadToDataGridView();
                            }
                            else
                            {
                                MessageBox.Show("Cargos associados a projetos não podem ser excluídos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else if (e.ColumnIndex == 3)
                {
                    string id = dgvJobRoles.SelectedCells[0].Value.ToString();
                    JobRole jobRole = _service.ReadById(long.Parse(id));
                    JobRoleForm jobRoleForm = new JobRoleForm(jobRole.Id);
                    jobRoleForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
