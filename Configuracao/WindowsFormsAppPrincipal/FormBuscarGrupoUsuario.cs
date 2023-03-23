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
    public partial class FormBuscarGrupoUsuario : Form
    {
        public FormBuscarGrupoUsuario()
        {
            InitializeComponent();
        }
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            grupoUsuarioBindingSource.DataSource = new GrupoUsuarioBLL().BuscarTodos();
        }
        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            int _id = ((GrupoUsuario)grupoUsuarioBindingSource.Current).Id;
            using (FormCadastrarGrupoUsuario frm = new FormCadastrarGrupoUsuario(_id))
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(null, null);
        }
        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            using (FormCadastrarGrupoUsuario frm = new FormCadastrarGrupoUsuario())
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(null, null);
        }
        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            if (grupoUsuarioBindingSource.Count <= 0)
            {
                MessageBox.Show("Não existe registro para ser excluido");
                return;
            }
            if (MessageBox.Show("Deseja mesmo excluir esse registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            int id = ((GrupoUsuario)grupoUsuarioBindingSource.Current).Id;
            new GrupoUsuarioBLL().Excluir(id);
            grupoUsuarioBindingSource.RemoveCurrent();
            MessageBox.Show("Registro excluído com sucesso");
        }
        private void FormBuscarGrupoUsuario_Load(object sender, EventArgs e)
        {

        }
        private void BotãoExcluir_Click(object sender, EventArgs e)
        {
            
        }
        private void BotãoAdicionar_Click(object sender, EventArgs e)
        {

        }
    }
}
