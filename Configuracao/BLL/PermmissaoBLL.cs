
using DAL;
using Models;
using System.Data.SqlClient;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BLL
{
    public class PermmissaoBLL
    {
        public void Inserir(Permissao permissao)
        {
            ValidarDados2(permissao);
            new PermissaoDAL().Inserir(permissao);
        }
        public void Excluir(int _id)
        {
            new PermissaoDAL().Excluir(_id);
        }
        public void BuscarTodos()
        {
            new PermissaoDAL().BuscarTodos();
        }
        public Permissao BuscarPorId(int id)
        {
            return new PermissaoDAL().BuscarPorId(id);
        }
        public List<Permissao> BuscarPorDescricao(string _descricao)
        {
            return new PermissaoDAL().BuscarPorDescricao(_descricao);
        }
        public void Alterar(Permissao permissao)
        {
            ValidarDados2(permissao);

            new PermissaoDAL().Alterar(permissao);
        }
        private void ValidarDados2(Permissao permissao)
        {
            if (permissao.Descricao.Length <= 3)
                throw new System.Exception("A Descrição deve ter mais de 3 caracteres");
        }
    }
}
