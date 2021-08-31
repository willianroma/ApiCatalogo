using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogo.Exceptions
{
    public class JogoNaoCadastradoExcepction : Exception
    {
        public JogoNaoCadastradoExcepction() : base("Este jogo não está cadastrado") { }
    }
}
