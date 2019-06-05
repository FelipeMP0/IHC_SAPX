using IHC.Models;
using IHC.Services;
using System;
using System.Windows.Forms;

namespace IHC
{
    public partial class JobRoleForm : Form
    {
        JobRoleService _service;
        private long? idToUpdate;

        public JobRoleForm()
        {
            InitializeComponent();
            _service = new JobRoleService();
        }

        public JobRoleForm(long id) : this()
        {
            idToUpdate = id;

            if (idToUpdate != null)
            {
                JobRole jobRole = _service.ReadById(Convert.ToInt64(idToUpdate));

                txtCargo.Text = jobRole.Name;
                txtNivel.Text = jobRole.Level;
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            JobRole jobRole = new JobRole()
            {
                Name = txtCargo.Text,
                Level = txtNivel.Text
            };

            if (idToUpdate != null)
            {
                jobRole.Id = Convert.ToInt64(idToUpdate);
            }

            if (jobRole.Id == 0)
            {
                _service.Create(jobRole);
            } else
            {
                _service.Update(jobRole);
            }

            MessageBox.Show("Cargo salvo com sucesso", "Cargos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Close();
        }
    }
}
