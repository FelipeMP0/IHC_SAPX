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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void BtnHorasPorMes_Click(object sender, EventArgs e)
        {
            HorasPorMes horasPorMes = new HorasPorMes();
            horasPorMes.ShowDialog();
        }

        private void BtnCargosMaisUsados_Click(object sender, EventArgs e)
        {
            CargosMaisUsados cargosMaisUsados = new CargosMaisUsados();
            cargosMaisUsados.ShowDialog();
        }

        private void BtnProjetosPorMes_Click(object sender, EventArgs e)
        {
            ProjetosPorMes projetosPorMes = new ProjetosPorMes();
            projetosPorMes.ShowDialog();
        }
    }
}
