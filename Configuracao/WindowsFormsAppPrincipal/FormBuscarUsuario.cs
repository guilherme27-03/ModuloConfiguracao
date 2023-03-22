using System;
using BLL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using System.Security.Cryptography;

namespace WindowsFormsAppPrincipal
{
    public partial class FormBuscarUsuario : Form
    {
        public FormBuscarUsuario()
        {
            InitializeComponent();
           
        }

        private void ButtonBuscar_Click(object sender, EventArgs e)
        {
            usuarioBindingSource.DataSource = new UsuarioBLL().BuscarTodos();
        }

        private void ButtonExcluirUsuario_Click(object sender, EventArgs e)
        {
            if(usuarioBindingSource.Count<=0)
            {
                MessageBox.Show("Não existe registro para ser excluido");
                return; 
            }
            if(MessageBox.Show("Deseja mesmo excluir esse registro?","Atenção",MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            int id = ((Usuario)usuarioBindingSource.Current).Id;
            new UsuarioBLL().Excluir(id);
            usuarioBindingSource.RemoveCurrent();
            MessageBox.Show("Registro excluído com sucesso");

        }

        private void ButtonAdicionarUsuario_Click(object sender, EventArgs e)
        {
            using(FormCadastroUsuario frm = new FormCadastroUsuario())
            {
                frm.ShowDialog();
            }
            ButtonBuscar_Click(null, null);
        }

        private void ButtonAlterar_Click(object sender, EventArgs e)
        {
            int _id = ((Usuario)usuarioBindingSource.Current).Id;
            using (FormCadastroUsuario frm = new FormCadastroUsuario(_id))
            {
                frm.ShowDialog();
            }
            ButtonBuscar_Click(null, null);
        }

        private void ButtonAdicionarGrupoUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
