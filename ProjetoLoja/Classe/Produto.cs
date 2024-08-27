using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoja.Classe
{
    public abstract class Produto
    {
        public string Nome { get; set; }
        public Decimal Preco { get; set; }

        protected Produto(string nome , decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }
        public abstract void ExibirDetalhes();
        public abstract string ToFileString();
    }
    
}
