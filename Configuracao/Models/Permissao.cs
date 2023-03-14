using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Permissao
    {
        public string Descricao { get; set; }
        public int Id { get; set; }   
        public List<GrupoUsuario> Grupo { get; set; }
    }
}
