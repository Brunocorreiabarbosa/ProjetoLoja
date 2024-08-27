using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoja.Classe
{
    public class Eletronicos : Produto
    {
        public string Marca { get; set; }

        public Eletronicos(string nome, decimal preco, string marca)
            : base (nome, preco)
        {
            Marca = marca;
        }
        public override void ExibirDetalhes()
        {
            Console.WriteLine($"Eletronico : Nome: {Nome}, Preço: {Preco:c} Marca: {Marca}");
        }
        public override string ToFileString()
        {
            return $"Eletronico|{Nome}|{Preco}|{Marca}";
        }
    }
}
