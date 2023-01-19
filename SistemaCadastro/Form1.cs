using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class formCadastro : Form
    {

        List<Pessoa> pessoas;

        public formCadastro()
        {
            InitializeComponent();

            pessoas = new List<Pessoa>();

            cbEstadoCivil.Items.Add("Casado");
            cbEstadoCivil.Items.Add("Solteiro");
            cbEstadoCivil.Items.Add("Viuvo");
            cbEstadoCivil.Items.Add("Divorciado");

            cbEstadoCivil.SelectedIndex = 0;

        }


        private void formCadastro_Load(object sender, EventArgs e)
        {
                
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int index  = -1;

            foreach(Pessoa pessoa in pessoas)
            {
                if(pessoa.Nome == txtNome.Text)
                {
                    index = pessoas.IndexOf(pessoa);
                }
            }

            if(txtNome.Text == "")
            {
                MessageBox.Show("Preencha o campo nome !");
                txtNome.Focus();
                return;
            }

            if (txtTelefone.Text == "(  )      -")
            {
                MessageBox.Show("Preencha o campo telefone !");
                txtTelefone.Focus();
                return;
            }

            char sexo;

            if(radioM.Checked)
            {
                sexo = 'M';
            }else if (radioF.Checked)
            {
                sexo = 'F';
            }
            else
            {
                sexo = 'O';
            }


            Pessoa p            = new Pessoa();
            p.Nome              = txtNome.Text;
            p.DataNascimento    = dtNascimento.Text;
            p.EstadoCivil       = cbEstadoCivil.SelectedItem.ToString();
            p.Telefone          = txtTelefone.Text;
            p.CasaPropria       = checkCasa.Checked;
            p.Veiculo           = checkVeiculo.Checked;
            p.Sexo              = sexo;

            //VERIFICA SE É UM CADASTRO NOVO OU SOMENTE ALTERAÇÃO
            if(index < 0)
            {
                pessoas.Add(p);
            }
            else
            {
                pessoas[index] = p;
            }

            //EXECUTAR O BOTÃO DE LIMPAR
            btnLimpar_Click(btnLimpar, EventArgs.Empty);

            //EXECUTAR O MÉTODO LISTAR
            Listar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int indice = lista.SelectedIndex;

            pessoas.RemoveAt(indice);

            Listar();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            dtNascimento.Text = "";
            cbEstadoCivil.SelectedIndex = 0;
            txtTelefone.Text = "";
            checkCasa.Checked = false;
            checkVeiculo.Checked = false;
            radioM.Checked = true;
            radioF.Checked = false;
            radioO.Checked = false;
            txtNome.Focus();
        }

        private void Listar()
        {
            lista.Items.Clear();

            foreach(Pessoa p in pessoas)
            {
                lista.Items.Add(p.Nome);
            }

        }

        private void lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = lista.SelectedIndex;
            Pessoa p = pessoas[indice];

            txtNome.Text                = p.Nome;
            dtNascimento.Text           = p.DataNascimento;
            cbEstadoCivil.SelectedItem  = p.EstadoCivil;
            txtTelefone.Text            = p.Telefone;
            checkCasa.Checked           = p.CasaPropria;
            checkVeiculo.Checked        = p.Veiculo;


            switch (p.Sexo)
            {
                case 'M':
                    radioM.Checked = true;
                    break;

                case 'F':
                    radioF.Checked = true;
                    break;

                default:
                    radioO.Checked = true;
                    break;
            }

        }
    }
}
