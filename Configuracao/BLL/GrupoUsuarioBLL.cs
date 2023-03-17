using DAL;
using Models;
using System.Security.Cryptography;

namespace BLL
{
    public class GrupoUsuarioBLL
    {
        public void Inserir(GrupoUsuario _grupousuario)
        {
            ValidarDados(_grupousuario);
            GrupoUsuarioDAL usuarioDAL = new GrupoUsuarioDAL();
            usuarioDAL.Inserir(_grupousuario);
        }
        public void Excluir(int id)
        {
            new GrupoUsuarioDAL().Excluir(id);
        }
        private void ValidarDados(GrupoUsuario _grupousuario)
        {
            if (_grupousuario.NomeGrupo.Length <= 5)
                throw new System.Exception("O nome do grupo deve ter mais de 5 caracteres");
            
        }
    }
}
