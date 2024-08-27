using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoja.Classe
{
    class Program
    {
        static void Main(string[] args)
        {
            Loja loja = new Loja();

            loja.AdicionarProduto(new Eletronicos("Smartphone", 299.99m, "Samsung"));
            loja.AdicionarProduto(new Roupas("Camisa Polo", 49.99m, "M"));
            loja.AdicionarProduto(new Roupas("Calça conguinha", 49.99m, "M"));

            Console.WriteLine("Listagem de produtos");
            loja.ListarProdutos();

            loja.AtualizarProduto(0, new Eletronicos("smartphoone", 3349.99m, "Apple"));
            loja.AtualizarProduto(1,new Roupas("Camisa calango", 119.00m, "M"));

            Console.WriteLine("Listagem de Produtos após atualizar");
            loja.RemoverProdutoPorNome("Calça conguinha");
            loja.SalvarEmArquivo("inventario.txt");

            Console.WriteLine("Listagem de produtos carregados do arquivo:");
            loja.ListarProdutos();

            Console.WriteLine("pressione Enter para sair..");
            Console.ReadLine();
            Console.ReadKey();
        }
    }
}
