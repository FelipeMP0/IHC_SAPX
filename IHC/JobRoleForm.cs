using IHC.Models;
using IHC.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IHC
{
    public partial class JobRoleForm : Form
    {
        JobRoleService _service;

        public JobRoleForm()
        {
            InitializeComponent();
            _service = new JobRoleService();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            JobRole jobRole = new JobRole()
            {
                Name = txtCargo.Text,
                Level = txtNivel.Text
            };

            _service.Create(jobRole);
        }
    }
}
