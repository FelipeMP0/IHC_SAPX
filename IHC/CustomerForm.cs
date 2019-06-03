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
    public partial class CustomerForm : Form
    {
        CustomerService _service;

        public CustomerForm()
        {
            InitializeComponent();
            _service = new CustomerService();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer()
            {
                Name = txtNome.Text,
                Document = txtCNPJ.Text,
                Phone = txtTelefone.Text,
                Email = txtEmail.Text
            };

            _service.Create(customer);
        }
    }
}
