using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoja.Classe
{
    public class Roupas : Produto
    {
        public string Tamanho { get; set; }

        public Roupas(string nome, decimal preco, string tamanho)
            : base (nome, preco)
        {
            Tamanho = tamanho;
        }
        public override void ExibirDetalhes()
        {
            Console.WriteLine($"Roupas: Nome: {Nome}, Preço: {Preco:c}, Tamanho: {Tamanho}");
        }
        public override string ToFileString()
        {
            return $"Roupas|{Nome}|{Preco}|{Tamanho}";
        }
    }
}
