
using DAL;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BLL
{
    public class PermmissaoBLL
    {
        public void Inserir()
        {

        }
        public void Excluir(int _id)
        {
            new PermissaoDAL().Excluir(_id);
        }
        public void BuscarTodos()
        {
            new PermissaoDAL().BuscarTodos();
        }
        public void BuscarPorDescricao(string _descricao)
        {
            new PermissaoDAL().BuscarPorDescricao(_descricao);
        }

    }
}
