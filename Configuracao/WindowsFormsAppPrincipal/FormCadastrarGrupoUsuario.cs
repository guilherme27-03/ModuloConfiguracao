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
    public partial class FormCadastrarGrupoUsuario : Form
    {
        public int id;
        public FormCadastrarGrupoUsuario(int id = 0)
        {
            InitializeComponent();
            this.id = id;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {

            GrupoUsuarioBLL grupousuarioBLL = new GrupoUsuarioBLL();
            grupoUsuarioBindingSource.EndEdit();
            if (id == 0)
                grupousuarioBLL.Inserir((GrupoUsuario)grupoUsuarioBindingSource.Current);
            else
                grupousuarioBLL.Alterar((GrupoUsuario)grupoUsuarioBindingSource.Current);
            MessageBox.Show("Registro Salvo com sucesso!");
            Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void FormCadastrarGrupoUsuario_Load(object sender, EventArgs e)
        {
            if (id == 0)
            {
                grupoUsuarioBindingSource.AddNew();
            }
        }
    }
}
