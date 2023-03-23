using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL
    {
        public void Inserir(Usuario _usuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Usuario(Nome,NomeUsuario,Email,CPF,Ativo,senha) Values(@Nome , @NomeUsuario,@Email,@CPF,@Ativo,@Senha)";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@Email", _usuario.Email);
                cmd.Parameters.AddWithValue("@CPF", _usuario.CPF);
                cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);
                cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao inserir um usuário no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public List<Usuario> BuscarPorNome(string _nome)
        {
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario = new Usuario();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,Nome,NomeUsuario,Email,Cpf,Ativo,Senha FROM Usuario WHERE Nome LIKE @Nome";
                cmd.Parameters.AddWithValue("@Nome", "%" + _nome + "%");

                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["ID"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();
                        usuario.GrupoUsuarios = new GrupoUsuarioDAL().BuscarPorIdUsuario(usuario.Id);
                        usuarios.Add(usuario);
                    }
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar Nome  no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }

        }

        public List<Usuario> BuscarTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario;
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,Nome,NomeUsuario,Email,CPF,Ativo,Senha FROM Usuario";
                cmd.CommandType = System.Data.CommandType.Text;

                cn.Open();
                cmd.ExecuteNonQuery();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["ID"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();
                        usuario.GrupoUsuarios = new GrupoUsuarioDAL().BuscarPorIdUsuario(usuario.Id);
                        usuarios.Add(usuario);
                    }
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar todos os usuarios no banco de dados", ex);
            }
            finally
            {
                cn.Close();


            }
        }
        public Usuario BuscarPorNomeUsuario(string _nomeUsuario)
        {
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario = new Usuario();

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,Nome,NomeUsuario,Email,CPF,Ativo,Senha WHERE NomeUsuario = @NomeUsuario";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@NomeUsuario", _nomeUsuario);

                cn.Open();
                cmd.ExecuteNonQuery();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["ID"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();
                        usuario.GrupoUsuarios = new GrupoUsuarioDAL().BuscarPorIdUsuario(usuario.Id);
                        usuarios.Add(usuario);
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar Nome de usuário no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public Usuario BuscarPorId(int _id)
        {
            Usuario usuario = new Usuario();

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,Nome,NomeUsuario,Email,CPF,Ativo,Senha FROM Usuario WHERE Id = @Id" ;
                                  
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _id);

                cn.Open();
                cmd.ExecuteNonQuery();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        usuario.Id = Convert.ToInt32(rd["ID"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();
                        usuario.GrupoUsuarios = new GrupoUsuarioDAL().BuscarPorIdUsuario(usuario.Id);
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar Id de usuario no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        
        public Usuario BuscarPorCpf(string _cpf)
        {
            Usuario usuario = new Usuario();

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,Nome,NomeUsuario,Email,CPF,Ativo,Senha WHERE CPF = @CPF";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@CPF+.", _cpf);

                cn.Open();
                cmd.ExecuteNonQuery();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["ID"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();
                        usuario.GrupoUsuarios = new GrupoUsuarioDAL().BuscarPorIdUsuario(usuario.Id);
                    }
                }

            }

            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar Cpf no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
            return usuario;

        }
        public void Alterar(Usuario _usuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "UPDATE Usuario SET Nome=@Nome,NomeUsuario=@NomeUsuario,Email=@Email,CPF=@CPF,Ativo=@Ativo,senha=@Senha WHERE Id = @Id";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@Email", _usuario.Email);
                cmd.Parameters.AddWithValue("@CPF", _usuario.CPF);
                cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);
                cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);
                cmd.Parameters.AddWithValue("@Id", _usuario.Id);
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
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
        public void Excluir(int _id)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "DELETE FROM Usuario WHERE ID = @Id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _id);
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
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

        public bool ValidarPermissao(int _IdUsuario, int _IdPermissao)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = " @SELECT 1 FROM PermissaoGrupoUsuario" +
                    "INNER JOIN UsuarioGrupoUsuario on PermissaoGrupoUsuario.IdGrupoUsuario = UsuarioGrupoUsuario.IdGrupoUsuario" +
                    "WHERE UsuarioGrupoUsuario.IdUsuario = @IdUsuario and PermissaoGrupoUsuario.IdPermissao = @IdPermissao";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@IdUsuario", _IdUsuario);
                cmd.Parameters.AddWithValue("@IdPermissao", _IdPermissao);
                cn.Open();
                cmd.ExecuteNonQuery();


                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())

                        return true;

                }
                return false;
            }

            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao validar uma permissão", ex);
            } 
        }

        public void AdicionarGrupoUsuario(int _idUsuario, int _idGrupoUsuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO UsuarioGrupoUsuario(IdUsuario,IdGrupoUsuario) 
                                    Values(@IdUsuario,@IdGrupoUsuario)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@IdUsuario",_idGrupoUsuario );
                cmd.Parameters.AddWithValue("@IdgrupoUsuario", _idGrupoUsuario);
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao inserir um usuário no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public bool UsuarioPertenceAoGrupo(int idUsuario, int IdGrupoUsuario)
        {
            Usuario usuario = new Usuario();

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT IdUsuario FROM Usuario WHERE IdUsuario = @IdUsuario AND IdGrupoUsuario = @IdGrupoUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@IdUsuario",idUsuario);
                cmd.Parameters.AddWithValue("@IdGrupoUsuario", IdGrupoUsuario);

                cn.Open();
                cmd.ExecuteNonQuery();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                     return true;
                    }
                    return false;
                }
              
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar Existenciar o Grupo vinculado ao usuário" +
                    " no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public void RemoverGrupoUsuario(int idUsuario, int idGrupoUsuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"DELETE FROM UsuarioGrupoUsuario WHERE IDUsuario = @IdUsuario
                                   AND IdGrupoUsuario = @IdGrupoUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@IdGrupoUsuario", idGrupoUsuario);
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
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
               
         
           
     
    


