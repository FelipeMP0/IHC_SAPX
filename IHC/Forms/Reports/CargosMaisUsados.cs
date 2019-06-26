using IHC.Enums;
using IHC.Models;
using IHC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IHC
{
    public partial class CargosMaisUsados : Form
    {
        private ProjectService projectService;
        private PlanningService planningService;
        private JobRoleService jobRoleService;

        public CargosMaisUsados()
        {
            InitializeComponent();
            projectService = new ProjectService();
            planningService = new PlanningService();
            jobRoleService = new JobRoleService();
            dtpInicio.Value = DateTime.Now.AddMonths(-1);
            dtpFim.Value = DateTime.Now;
        }

        private void CargosMaisUsados_Load(object sender, EventArgs e)
        {
            LoadData();
            this.chart1.Titles.Add("Cargos mais planejados");
        }

        private void LoadData()
        {
            Dictionary<string, int> horasPorCargo = new Dictionary<string, int>();

            List<Project> projects = projectService.ReadWithParameters(dtpInicio.Value, dtpFim.Value, 0, ProjectState.NULL).ToList();

            foreach (var project in projects)
            {
                project.Plannings = planningService.ReadAllByProjectId(project.Id).ToList();
                foreach (var planning in project.Plannings)
                {
                    planning.JobRole = jobRoleService.ReadById(planning.JobRoleId);
                    if (horasPorCargo.ContainsKey(planning.JobRole.Name))
                    {
                        horasPorCargo[planning.JobRole.Name] += 1;
                    }
                    else
                    {
                        horasPorCargo.Add(planning.JobRole.Name, 1);
                    }
                }
            }

            this.chart1.Palette = ChartColorPalette.SeaGreen;
            this.chart1.Series.Clear();

            foreach (var a in horasPorCargo.Keys)
            {
                Series series = this.chart1.Series.Add(a);
                series.Points.Add(horasPorCargo[a]);
            }
        }


        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (dtpInicio.Value.Date.CompareTo(dtpFim.Value.Date) > 0)
            {
                MessageBox.Show("Data final deve ser após a data inicial", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            LoadData();
        }
    }
}
