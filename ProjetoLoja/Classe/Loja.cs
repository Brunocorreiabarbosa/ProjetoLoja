using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoja.Classe
{
    public class Loja
    {
        private List<Produto> produtos;

        public Loja()
        {
            produtos = new List<Produto>();
        }
        public void AdicionarProduto(Produto produto)
        {
            produtos.Add(produto);
            Console.WriteLine("Produto adicionado com sucesso.");
        }
        public void ListarProdutos()
        {
            if(produtos.Count == 0)
            {
                Console.WriteLine("Nenhum  produto no inventario");
                return;
            }
            foreach (var produto in produtos)
            {
                produto.ExibirDetalhes();
                Console.WriteLine();
            }
        }
        public void AtualizarProduto(int index, Produto produtoAtualizado)
        {
            if (index < 0 || index >= produtos.Count)
            {
                Console.WriteLine("Indice Invalido");
                return;
            }
            produtos[index] = produtoAtualizado;
            Console.WriteLine("Produto atualizado com sucesso.");
        }
        public void RemoverProduto(int index)
        {
            if (index < 0 || index>= produtos.Count)
            {
                Console.WriteLine("Indice Invalido");
                return;
            }
            produtos.RemoveAt(index);
            Console.WriteLine("Produto removido com Sucesso");
        }
        public void RemoverProdutoPorNome(string nome)
        {
            
            Produto produtoARemover = produtos.Find(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (produtoARemover != null)
            {
                produtos.Remove(produtoARemover);
                Console.WriteLine($"Produto '{nome}' removido com sucesso.");
            }
            else
            {
                Console.WriteLine($"Produto '{nome}' não encontrado.");
            }
        }
        public void SalvarEmArquivo(string caminho)
        {
            using (StreamWriter writer = new StreamWriter(caminho))
            {
                foreach (var produto in produtos)
                {
                    writer.WriteLine(produto.ToFileString());
                }
            }
            Console.WriteLine("Dados Salvos com sucesso.");
        }
        public void CarregarDeArquivo(string caminho)
        {
            if (!File.Exists(caminho))
            {
                Console.WriteLine("Arquivo não encontrado.");
                return;
            }
            produtos.Clear();
            using (StreamReader reader = new StreamReader(caminho))
            {
                string linha;
                while((linha = reader.ReadLine()) != null)
                {
                    var partes = linha.Split('|');
                    if(partes.Length < 4)
                    {
                        Console.WriteLine("Formato de linha Invalido.");
                        continue;
                    }
                    var tipo = partes[0];
                    var nome = partes[1];
                    var preco = decimal.Parse(partes[2]);

                    if (tipo == "Eletronico")
                    {
                        var marca = partes[3];
                        produtos.Add(new Eletronicos(nome, preco, marca));
                    }
                    else if (tipo == "Roupas")
                    {
                        var tamanho = partes[3];
                        produtos.Add(new Roupas(nome, preco, tamanho));
                    }
                }
            }
            Console.WriteLine("Dados Carregados com sucesso.");
        }
    }
}
