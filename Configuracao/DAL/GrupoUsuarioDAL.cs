using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class GrupoUsuarioDAL
    {
        public void Inserir(GrupoUsuario _grupoUsuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO GrupoUsuario(Id,NomeGrupo,) Values(@Id , @NomeGrupo";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _grupoUsuario.Id);
                cmd.Parameters.AddWithValue("@NomeUsuario", _grupoUsuario.NomeGrupo);

                cmd.Connection = cn;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao inserir um Grupo no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public List<GrupoUsuario> BuscarTodos()
        {
            List<GrupoUsuario> grupousuarios = new List<GrupoUsuario>();
            GrupoUsuario grupousuario;
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,NomeGrupo WHERE (@Id,@NomeGrupo)";
                cmd.CommandType = System.Data.CommandType.Text;

                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        grupousuario = new GrupoUsuario();
                        grupousuario.Id = Convert.ToInt32(rd["ID"]);
                        grupousuario.NomeGrupo = rd["NomeGrupo"].ToString();


                        grupousuarios.Add(grupousuario);
                    }
                }
                return grupousuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar todos os Grupos de usuários no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public GrupoUsuario BuscarPorId(int id)
        {
            GrupoUsuario grupousuario = new GrupoUsuario();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,NomeGrupo WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", id);

                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        grupousuario.Id = Convert.ToInt32(rd["ID"]);
                        grupousuario.NomeGrupo = rd["NomeGrupo"].ToString();
                    }
                }
                return grupousuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar Id de Grupo no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public List<GrupoUsuario> BuscarPorNomeGrupo(string _NomeGrupo)
        {
            List<GrupoUsuario> Grupousuarios = new List<GrupoUsuario>();
            GrupoUsuario grupousuario = new GrupoUsuario();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,NomeGrupo FROM GrupoUsuario WHERE NomeGrupo LIKE @NomeGrupo";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@NomeGrupo", "%" + _NomeGrupo + "%");

                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        grupousuario = new GrupoUsuario();
                        grupousuario.Id = Convert.ToInt32(rd["ID"]);
                        grupousuario.NomeGrupo = rd["NomeGrupo"].ToString();
                    }
                }
                return Grupousuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar Nome do Grupo  no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public void Alterar(GrupoUsuario _grupoUsuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"UPDATE INTO GrupoUsuario(Id,NomeGrupo,) Values(@Id , @NomeGrupo";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _grupoUsuario.Id);
                cmd.Parameters.AddWithValue("@NomeUsuario", _grupoUsuario.NomeGrupo);

                cmd.Connection = cn;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao Alterar um Grupo no banco de dados", ex);
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
                cmd.CommandText = @" DELETE FROM GrupoUsuario WHERE ID = @Id";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _id);

                cmd.Connection = cn;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao excluir um Grupo no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}



