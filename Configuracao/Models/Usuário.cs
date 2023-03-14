﻿using System.Collections.Generic;

namespace Models
{
    public class Usuário

    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public string Senha { get; set; }
        public  List<GrupoUsuario> GrupoUsuarios { get; set; }
    }
}
