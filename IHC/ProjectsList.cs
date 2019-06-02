using System;
using System.Windows.Forms;

namespace IHC
{
    public partial class ProjectsList : Form
    {

        public ProjectsList()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm();
            projectForm.ShowDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
        }
    }
}
