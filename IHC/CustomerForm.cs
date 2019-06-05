﻿using IHC.Models;
using IHC.Services;
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

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
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
    }
}