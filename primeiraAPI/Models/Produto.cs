namespace ProdutosApiAula.Models
{
    public class Produto
    {
        public Produto()
        {
            Name = "";
            Description = "";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
    }
}
