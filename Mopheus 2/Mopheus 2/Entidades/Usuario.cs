using System;
using System.Data;

namespace Entidades
{
    public class Usuario : Base
    {
        public string Nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string acesso { get; set; }

    }
}
