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
    public partial class JobRoleListForm : Form
    {
        JobRoleService _service;

        public JobRoleListForm()
        {
            InitializeComponent();
            _service = new JobRoleService();
        }

        private void JobRoleListForm_Load(object sender, EventArgs e)
        {
            IEnumerable<JobRole> jobRoles = _service.ReadAll();
            foreach (var jobRole in jobRoles)
            {
                dgpJobRoles.Rows.Add(jobRole.Name, jobRole.Level, null, null);
            }
        }
    }
}
