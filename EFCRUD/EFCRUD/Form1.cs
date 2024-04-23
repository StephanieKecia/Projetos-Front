using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCRUD
{
    public partial class Form1 : Form
    {
        Customer model = new Customer();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            txtPrimeiroNome.Text = txtUltimoNome.Text = txtCidade.Text = txtEndereco.Text = "";
            btnSalvar.Text = "Salvar";
            btnApagar.Enabled = false;
            model.CustomerId = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Clear();
            this.ActiveControl = txtPrimeiroNome;
            LoadData();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            model.PrimeiroNome = txtPrimeiroNome.Text.Trim();
            model.UltimoNome = txtUltimoNome.Text.Trim();
            model.Cidade = txtCidade.Text.Trim();
            model.Endereco = txtEndereco.Text.Trim();
            using (EFDBEntities db = new EFDBEntities())
            {
                if (model.CustomerId == 0)
                db.Customers.Add(model);
                else
                    db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
            Clear();
            LoadData();
            MessageBox.Show("Enviado com Sucesso!");
        }

        void LoadData()
        {

            dgvCustomer.AutoGenerateColumns = false;
            using (EFDBEntities db = new EFDBEntities())
            {
                dgvCustomer.DataSource = db.Customers.ToList<Customer>();
            }
        }

        private void dgvCustomer_DoubleClick(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow.Index != -1) 
            {
                model.CustomerId = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["dgCustomerId"].Value);
                using (EFDBEntities db = new EFDBEntities())
                {
                    model = db.Customers.Where(x => x.CustomerId == model.CustomerId).FirstOrDefault();
                    txtPrimeiroNome.Text = model.PrimeiroNome;
                    txtUltimoNome.Text = model.UltimoNome;
                    txtCidade.Text = model.Cidade;
                    txtEndereco.Text = model.Endereco;
                }
                btnSalvar.Text = "Atualizar";
                btnApagar.Enabled = true;
               

            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Tem certeza que quer apagar esse campo?", "Message",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (EFDBEntities db = new EFDBEntities())
                {
                    var entry = db.Entry(model);
                    if(entry.State == EntityState.Detached)
                    {
                        db.Customers.Attach(model);
                        db.Customers.Remove(model);
                        db.SaveChanges();
                        LoadData();
                        Clear();
                        MessageBox.Show("Apagado com sucesso");
                    }
                }
            }
        }
    }
}
