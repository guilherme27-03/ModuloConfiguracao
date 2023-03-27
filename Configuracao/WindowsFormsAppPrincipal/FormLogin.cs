using BLL;
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
    public partial class FormLogin : Form
    {
        public bool logou;
        public FormLogin()
        {
            InitializeComponent();
            logou = false;
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                new UsuarioBLL().Autenticar(nomeUsuarioTextBox.Text, textBoxSenha.Text);
                logou = true;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxNomeusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void nomeUsuarioTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBoxSenha.Focus(); 

           
        }

        private void textBoxSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonEntrar_Click(null,null);
        }
    }
    
}
