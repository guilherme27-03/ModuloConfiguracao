using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
        public void BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void BuscarPorId(int Id)
        {
            throw new NotImplementedException();
        }
        public void BuscarPorNomeGrupo(string _nomeGrupoUsuario)
        {
            throw new NotImplementedException();
        }
        public void Alterar(GrupoUsuario grupoUsuario)
        {
            throw new NotImplementedException();
        }
        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
