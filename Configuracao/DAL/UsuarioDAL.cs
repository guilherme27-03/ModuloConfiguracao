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
        public void BuscarTodos()
        {
            throw new NotImplementedException();
        }
        public void BuscarPorNomeUsuario(string _nomeUsuario)
        {
            throw new NotImplementedException();
        }
        public void BuscarPorId(int _id)
        {
            throw new NotImplementedException();
        }
        public void Alterar(Usuário _usuário)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"UPDATE INTO Usuario(Nome,NomeUsuario,Email,CPF,Ativo,senha) Values(@Nome , @NomeUsuario,@Email,@CPF,@Ativo,@Senha";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _usuário.Nome);
                cmd.Parameters.AddWithValue("@NomeUsuario", _usuário.NomeUsuario);
                cmd.Parameters.AddWithValue("@Email", _usuário.Email);
                cmd.Parameters.AddWithValue("@CPF", _usuário.CPF);
                cmd.Parameters.AddWithValue("@Ativo", _usuário.Ativo);
                cmd.Parameters.AddWithValue("@Senha", _usuário.Senha);
                cmd.Connection = cn;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao Alterar um usuário no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public void  Excluir(int _id)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "DELETE FROM Usuario WHERE ID = @Id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id",_id);
                
                cmd.Connection = cn;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao Excluir um usuário no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
