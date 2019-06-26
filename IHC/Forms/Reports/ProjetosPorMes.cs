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
    public partial class ProjetosPorMes : Form
    {

        private ProjectService projectService;
        private PlanningService planningService;
        private int projetos = 0;

        public ProjetosPorMes()
        {
            InitializeComponent();
            projectService = new ProjectService();
            planningService = new PlanningService();
            numericUpDown1.Minimum = 2010;
            numericUpDown1.Maximum = 2099;
            numericUpDown1.Value = DateTime.Now.Year;
        }

        private void ProjetosPorMes_Load(object sender, EventArgs e)
        {
            LoadData();
            this.chart1.Titles.Add("Projetos X Mês");
        }

        private void SomarHoras(List<Project> projects)
        {
            projetos = projects.Count;
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

                Percentual.Add(projetos);

                projetos = 0;
            }

            this.chart1.Palette = ChartColorPalette.Excel;
            this.chart1.Series.Clear();

            for (int i = 0; i < Meses.Length; i++)
            {
                Series series = this.chart1.Series.Add(Meses[i]);
                series.Points.Add(Percentual[i]);
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
