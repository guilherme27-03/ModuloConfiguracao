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
        public void Inserir(Usuario _usuario, string _confirmacaodesenha)
        {
            ValidarDados(_usuario, _confirmacaodesenha);
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Inserir(_usuario);

        }

        public void Alterar(Usuario _usuario, string _confirmacaodesenha)
        {
            ValidarDados(_usuario, _confirmacaodesenha);

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
        private void ValidarDados(Usuario usuario, string _confirmacaodesenha)
        {
            if (usuario.Senha != _confirmacaodesenha)
                throw new Exception("A senha e a confirmação de senha devem ser iguais");
            if (usuario.Senha.Length <= 3)
                throw new System.Exception("A senha deve ter mais de 3 caracteres");
            if (usuario.Nome.Length <= 2)
                throw new System.Exception("O Nome deve ter mais de 2 caracteres");

        }

        public void ValidarPermissao(int _IdPermissao)
        {
            if (!new UsuarioDAL().ValidarPermissao(Constantes.IdUsuarioLogado, _IdPermissao))
            {
                throw new Exception("Você nao tem permissão para realizar essa ação");
            }
        }
        public void AdicionarGrupoUsuario(int _IdUsuario, int IdGrupoUsuario)
        {
            if (!new UsuarioDAL().UsuarioPertenceAoGrupo(_IdUsuario, _IdUsuario))
                new UsuarioDAL().AdicionarGrupoUsuario(_IdUsuario, IdGrupoUsuario);
        }

        public void RemoverGrupoUsuario(int idUsuario, int idGrupoUsuario)
        {
            new UsuarioDAL().RemoverGrupoUsuario(idUsuario, idGrupoUsuario);
        }
    }
}

