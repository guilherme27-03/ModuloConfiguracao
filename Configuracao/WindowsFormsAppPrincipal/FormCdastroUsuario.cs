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

namespace WindowsFormsAppPrincipal
{
    public partial class FormCadastroUsuario : Form
    {
        public int id;
        public FormCadastroUsuario(int _id = 0)
        {
            InitializeComponent();
            id = _id;   
        }

        private void FormCadastroUsuario_Load(object sender, EventArgs e)
        {
            if (id == 0)
                usuarioBindingSource.AddNew();
            else
                usuarioBindingSource.DataSource = new UsuarioBLL().BuscarPorId(id);
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                usuarioBindingSource.EndEdit();
                if (id == 0)
                    usuarioBLL.Inserir((Usuario)usuarioBindingSource.Current, textBoxConfirmarSenha.Text);
                else
                    usuarioBLL.Alterar((Usuario)usuarioBindingSource.Current, textBoxConfirmarSenha.Text);
                MessageBox.Show("Registro Salvo com sucesso!");
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
