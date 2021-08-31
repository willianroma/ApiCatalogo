using System;

namespace ApiCatalogoJogo.Entities
{
    public class Jogo
    {
        public Guid Id { set; get; }
        public string Nome { get; set; }
        public string Produtora { get; set; }
        public double Preco { get; set; }
    }
}
