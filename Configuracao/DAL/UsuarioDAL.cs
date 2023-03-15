using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL
    {
        public void Inserir(Usuário usuário)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Usuario(Nome,NomeUsuario,Email,CPF,Ativo,senha) Values(@Nome , @NomeUsuario,@Email,@CPF,@Ativo,@Senha";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome",usuário.Nome);
                cmd.Parameters.AddWithValue("@NomeUsuario", usuário.NomeUsuario);
                cmd.Parameters.AddWithValue("@Email", usuário.Email);
                cmd.Parameters.AddWithValue("@CPF", usuário.CPF);
                cmd.Parameters.AddWithValue("@Ativo", usuário.Ativo);
                cmd.Parameters.AddWithValue("@Senha", usuário.Senha);
                cmd.Connection = cn;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao inserir um usuário no banco de dados",ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Usuário> BuscarTodos()
        {
            throw new NotImplementedException();
        }
        public List<Usuário> BuscarPorNomeUsuario(string _nomeUsuario)
        {
            throw new NotImplementedException();
        }
        public List<Usuário> BuscarPorId(int _id)
        {
            throw new NotImplementedException();
        }
        public List<Usuário> Alterar(Usuário usuário)
        {
            throw new NotImplementedException();    
        }
        public List<Usuário> Excluir(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
