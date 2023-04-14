﻿using Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
                cmd.CommandText = @"INSERT INTO GrupoUsuario(NomeGrupo) Values(@NomeGrupo)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@NomeGrupo", _grupoUsuario.NomeGrupo);
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
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
                cmd.CommandText = "SELECT Id,NomeGrupo FROM GrupoUsuario";
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
                cmd.CommandText = @"SELECT FROM Usuario WHERE @iD = iD";
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
        public List<GrupoUsuario> BuscarPorIdUsuario(int _idUsuario)
        {
            List<GrupoUsuario> Grupousuarios = new List<GrupoUsuario>();
            GrupoUsuario Grupousuario = new GrupoUsuario();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT GrupoUsuario.Id, GrupoUsuario.NomeGrupo FROM GrupoUsuario INNER JOIN UsuarioGrupoUsuario ON GrupoUsuario.Id = UsuarioGrupoUsuario.IdGrupoUsuario WHERE UsuarioGrupoUsuario.IdUsuario = @IdUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@IdUsuario", _idUsuario);

                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Grupousuario = new GrupoUsuario();
                        Grupousuario.Id = Convert.ToInt32(rd["Id"]);
                        Grupousuario.NomeGrupo = rd["NomeGrupo"].ToString();
                        Grupousuarios.Add(Grupousuario);

                    }
                }
                return Grupousuarios;
            }

            catch (Exception ex)
            {
                throw new Exception($"ocorreu um erro ao buscar por id de usuário", ex);
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
                        Grupousuarios.Add(grupousuario);
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
                cmd.CommandText = @"UPDATE INTO GrupoUsuario(Id,NomeGrupo,) Values(@Id , @NomeGrupo)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _grupoUsuario.Id);
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
        public void Excluir(int _idGrupoUsuario, SqlTransaction transaction = null)
        {
            SqlTransaction _transaction = null;

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM GrupoUsuario WHERE Id = @ID", cn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", _idGrupoUsuario);

                        if (_transaction == null)
                        {
                            cn.Open();
                            transaction = cn.BeginTransaction();
                        }

                        cmd.Transaction = _transaction;
                        cmd.Connection = _transaction.Connection;

                        RemoverTodasPermissoes(_idGrupoUsuario, _transaction);
                        cmd.ExecuteNonQuery();

                        if(transaction != null)
                        {
                            transaction.Rollback();
                        }

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
        private void RemoverTodasPermissoes(int idGrupoUsuario, SqlTransaction _transaction)
        {
            SqlTransaction transaction = _transaction;
            using (SqlConnection cn = new SqlConnection(Conexao.StringDeConexao))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM PermissaoGrupoUsuario WHERE IdGrupoUsuario = @Id"))
                {
                    cmd.Parameters.AddWithValue("@Id", idGrupoUsuario);
                    if (transaction == null)
                    {
                        cn.Open();
                        transaction = cn.BeginTransaction();
                    }
                    cmd.Transaction = transaction;
                    cmd.Connection = transaction.Connection;

                    try
                    {
                        if (_transaction == null)
                            transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        throw new Exception("ocorreu um erro ao tentar excluir todas as permissoes do grupo");
                    }
                   
                }
            }
        }
    }
}



