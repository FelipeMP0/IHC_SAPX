using IHC.Enums;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace IHC
{
    public partial class HorasPorMes : Form
    {
        private ProjectService projectService;
        private PlanningService planningService;
        private int horas = 0;

        public HorasPorMes()
        {
            InitializeComponent();
            projectService = new ProjectService();
            planningService = new PlanningService();
            numericUpDown1.Minimum = 2010;
            numericUpDown1.Maximum = 2099;
            numericUpDown1.Value = DateTime.Now.Year;
        }

        private void HorasPorMes_Load(object sender, EventArgs e)
        {
            LoadData();
            chart1.Titles.Add("Horas X Mês");
        }

        private void SomarHoras(List<Project> projects)
        {
            foreach (var project in projects)
            {
                project.Plannings = planningService.ReadAllByProjectId(project.Id).ToList();
                if (project.Plannings.Count != 0)
                {
                    foreach (var planning in project.Plannings)
                    {
                        horas += planning.PlannedHours;
                    }
                }
            }
        }

        private void LoadData()
        {
            string[] Meses = {
                    "Janeiro",
                    "Fevereiro",
                    "Março",
                    "Abril",
                    "Maio",
                    "Junho",
                    "Julho",
                    "Agosto",
                    "Setembro",
                    "Outubro",
                    "Novembro",
                    "Dezembro"
                    };

            List<int> Percentual = new List<int>();

            for (int i = 1; i <= 12; i++)
            {
                DateTime primeiroDiaDoMes = new DateTime(Convert.ToInt32(numericUpDown1.Value), i, 1);
                DateTime ultimoDiaDoMes = new DateTime(Convert.ToInt32(numericUpDown1.Value), i, DateTime.DaysInMonth(Convert.ToInt32(numericUpDown1.Value), i));

                List<Project> projects = projectService.ReadWithParameters(primeiroDiaDoMes, ultimoDiaDoMes, 0, ProjectState.NULL).ToList();

                SomarHoras(projects);

                Percentual.Add(horas);

                horas = 0;
            }

            chart1.Palette = ChartColorPalette.SeaGreen;
            chart1.Series.Clear();

            for (int i = 0; i < Meses.Length; i++)
            {
                Series series = chart1.Series.Add(Meses[i]);
                series.Points.Add(Percentual[i]);
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
