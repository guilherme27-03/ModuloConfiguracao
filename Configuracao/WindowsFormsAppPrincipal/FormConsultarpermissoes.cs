using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppPrincipal
{
 
    public partial class FormConsultarpermissoes : Form
    {
        internal int Id;
        public FormConsultarpermissoes()
        {
            InitializeComponent();
        }

        private void FormConsultarpermissoes_Load(object sender, EventArgs e)
        {

        }

        private void buttonBuscarper_Click(object sender, EventArgs e)
        {
            try
            {
                permissaoBindingSource.DataSource = new PermmissaoBLL().BuscarPorDescricao(descricaoTextBox.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void buttoncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSelecionar_Click(object sender, EventArgs e)
        {
            try
            {

                if (permissaoBindingSource.Count > 0)
                {
                    Id = ((Permissao)permissaoBindingSource.Current).Id;
                    Close();
                }
                else
                {
                    MessageBox.Show("Não Existe registro para ser selecionado");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
