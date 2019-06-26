using IHC.Models;
using IHC.Services;
using IHC.Utils;
using System;
using System.Windows.Forms;

namespace IHC
{
    public partial class CustomerForm : Form
    {
        CustomerService _service;
        private long? idToUpdate;

        public CustomerForm()
        {
            InitializeComponent();
            _service = new CustomerService();
            txtCNPJ.KeyPress += TxtCNPJ_KeyPress;
        }

        public CustomerForm(long id) : this()
        {
            idToUpdate = id;
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void ValidateData()
        {
            if (txtCNPJ.Text.Trim() == "")
            {
                MessageBox.Show("CNPJ/CPF do cliente é obrigatório", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw new Exception();
            }

            if (txtCNPJ.Text.Length == 11)
            {
                if (!DocumentUtils.IsCpf(txtCNPJ.Text))
                {
                    MessageBox.Show("CNPJ/CPF do cliente inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    throw new Exception();
                }
            }
            else if (txtCNPJ.Text.Length == 14)
            {
                if (!DocumentUtils.IsCnpj(txtCNPJ.Text))
                {
                    MessageBox.Show("CNPJ/CPF do cliente inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    throw new Exception();
                }
            }
            else
            {
                MessageBox.Show("CNPJ/CPF do cliente inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw new Exception();
            }

            if (txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Nome do cliente é obrigatório", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw new Exception();
            }

            if (txtTelefone.Text.Trim() == "")
            {
                MessageBox.Show("Telefone do cliente é obrigatório", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw new Exception();
            }

            if (!RegexUtilities.IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Formato do e-mail é inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw new Exception();
            }
        }

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateData();
            }
            catch (Exception)
            {
                return;
            }

            Customer foundCustomer = _service.existsWithDocument(txtCNPJ.Text);

            if (foundCustomer != null)
            {
                if (foundCustomer.Id != idToUpdate)
                {
                    MessageBox.Show("CPF ou CNPJ já cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }

            Customer customer = new Customer()
            {
                Name = txtNome.Text,
                Document = txtCNPJ.Text,
                Phone = txtTelefone.Text,
                Email = txtEmail.Text
            };

            if (idToUpdate != null)
            {
                customer.Id = Convert.ToInt64(idToUpdate);
            }

            if (customer.Id == 0)
            {
                _service.Create(customer);
            }
            else
            {
                _service.Update(customer);
            }

            MessageBox.Show("Cliente salvo com sucesso", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Close();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            if (idToUpdate != null)
            {
                Customer customer = _service.ReadById(Convert.ToInt64(idToUpdate));
                txtNome.Text = customer.Name;
                txtCNPJ.Text = customer.Document;
                txtEmail.Text = customer.Email;
                txtTelefone.Text = customer.Phone;
            }
        }

        private void TxtCNPJ_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita apenas números");
            }
        }
    }
}
