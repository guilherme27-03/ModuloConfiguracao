using Models;
using DAL;
using System.CodeDom;
using System.ComponentModel;
using System.Collections.Generic;
using System;

namespace BLL
{
    public class UsuarioBLL
    {
        public void Inserir(Usuario _usuario)
        {
            ValidarDados(_usuario);
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Inserir(_usuario);

        }

        public void Alterar(Usuario _usuario)
        {
            ValidarDados(_usuario);

            new UsuarioDAL().Alterar(_usuario);
        }
        public void Excluir(int _id)
        {
            new UsuarioDAL().Excluir(_id);
        }
        public List<Usuario> BuscarTodos()
        {
            return new UsuarioDAL().BuscarTodos();
        }
        public Usuario BuscarPorId(int _id)
        {
            return new UsuarioDAL().BuscarPorId(_id);
        }
        public Usuario BuscarPorCPF(string Cpf)
        {
            return new UsuarioDAL().BuscarPorCpf(Cpf);
        }
        public List<Usuario> BuscarPorNome(string _nome)
        {
            return new UsuarioDAL().BuscarPorNome(_nome);
        }
        public Usuario BuscarPorNomeUsuario(string _nomeUsuario)
        {
            return new UsuarioDAL().BuscarPorNomeUsuario(_nomeUsuario);
        }
        private void ValidarDados(Usuario usuario)
        {
            if(usuario.Senha.Length <= 3)
                throw new System.Exception("A senha deve ter mais de 3 caracteres");
            if (usuario.Nome.Length <= 2)
                throw new System.Exception("O Nome deve ter mais de 2 caracteres");
        }

        public void ValidarPermissao(int _IdPermissao)
        {
            if (! new UsuarioDAL().ValidarPermissao(Constantes.IdUsuarioLogado,_IdPermissao))
            {
                throw new Exception("Você nao tem permissão para realizar essa ação");
            }
        }
    }
  
}
