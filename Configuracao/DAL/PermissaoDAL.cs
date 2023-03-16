using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PermissaoDAL
    {
        public void Inserir(Permissao permissao)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Usuario(Id,Descricao) Values(@Id,@Descricao";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", permissao.Id);
                cmd.Parameters.AddWithValue("@NomeUsuario", permissao.Descricao);

                cmd.Connection = cn;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao inserir uma permissãoB no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Permissao> BuscarTodos()
        {
            List<Permissao> permissaos = new List<Permissao>();
            Permissao permissao;
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,Descricao WHERE (@Id,@Descricao)";
                cmd.CommandType = System.Data.CommandType.Text;

                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        permissao = new Permissao();
                        permissao.Id = Convert.ToInt32(rd["ID"]);
                        permissao.Descricao = rd["Nome"].ToString();
                    }
                }
                return permissaos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar todos as permissões no banco de dados", ex);
            }
            finally
            {
                cn.Close();


            }
        }

        public List<Permissao> BuscarPorDescricao(string _descricao)
        {
            List<Permissao> permissaos = new List<Permissao> { };
            Permissao permissao = new Permissao();

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,Descricao FROM Usuario WHERE Descricao LIKE @Descricao";
                cmd.Parameters.AddWithValue("@Nome", "%" + _descricao + "%");

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Descricao", _descricao);

                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())

                    while (rd.Read())
                    {

                        permissao = new Permissao();
                        permissao.Id = Convert.ToInt32(rd["ID"]);
                        permissao.Descricao = rd["Descricao"].ToString();

                    }
                return permissaos;

            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar Descricao no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }

        }
        public Permissao BuscarPorId(int _id)
        {
            Permissao permissao = new Permissao();

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,Descricao WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _id);

                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())

                    if (rd.Read())
                    {
                        permissao.Id = Convert.ToInt32(rd["Id"]);
                        permissao.Descricao = rd["Descricao"].ToString();

                    }

                return permissao;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar Id de permissão no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public void Alterar(Permissao permissao)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"UPDATE INTO Permissao(Id,Descricao) Values (@Id , @Descricao";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", permissao.Id);
                cmd.Parameters.AddWithValue("@Descricao", permissao.Descricao);

                cmd.Connection = cn;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao Alterar uma permissão no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public void Excluir(int _id)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "DELETE FROM Permissao WHERE ID = @Id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _id);

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
    

