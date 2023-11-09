using ProdutosApiAula.Models;

namespace ProdutosApiAula.Repositories
{
    public static class MockDB
    {
        public static List<Produto> Produtos { get; set; } = new List<Produto>();
        //Faça um método que retorne 10 produtos Mockados

        public static List<Produto> GetProdutos()
        {
            generateProdutos();
            return Produtos;
        }

        public static Produto? GetProduto(int id)
        {
            generateProdutos();
            return Produtos.FirstOrDefault(p => p.Id == id);
        }

        private static void generateProdutos()
        {
            for (int i = 0; i < 10; i++)
            {
                Produto produto = new Produto();
                produto.Id = i;
                produto.Name = $"Produto {i}";
                produto.Description = $"Descrição do produto {i}";
                produto.Price = i * 10;
                produto.Quantity = i * 2;
                Produtos.Add(produto);
            }
        }
        public static void UpdateProduto(Produto produto)
        {
            var existingProduto = Produtos.FirstOrDefault(p => p.Id == produto.Id);
            if (existingProduto != null)
            {
                existingProduto.Name = produto.Name;
                existingProduto.Description = produto.Description;
                existingProduto.Price = produto.Price;
                existingProduto.Quantity = produto.Quantity;
            }
        }

        public static void DeleteProduto(int id)
        {
            var produto = Produtos.FirstOrDefault(p => p.Id == id);
            if (produto != null)
            {
                Produtos.Remove(produto);
            }
        }

    }
}