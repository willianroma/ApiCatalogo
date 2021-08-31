using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogo.ViewModel
{
    public class JogoViewModel
    {
        public Guid Id { set; get; }
        public string Nome { get; set;}
        public string Produtora { get; set; }
        public double Preco { get; set; }

    }
}
