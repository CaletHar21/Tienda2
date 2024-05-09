namespace TienditaStore.DB
{
    public record Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class ProductDB
    {
        private static List<Product> _products = new List<Product>()
       {
         new Product{ Id=1, Name="Carne", Description="Carne Punta Negra"},
         new Product{ Id=2, Name="Sopa Maruchan", Description="Sopa Laky"},
         new Product{ Id=3, Name="Soda", Description="Soda de 3l"}
       };

        public static List<Product> GetProducts()
        {
            return _products;
        }

        public static Product? GetProduct(int id)
        {
            return _products.FirstOrDefault(product => product.Id == id);
        }


        public static Product CreateProduct(Product product)
        {
            _products.Add(product);
            return product;
        }

        public static Product UpdateProduct(Product update)
        {
            _products = _products.Select(product =>
            {
                if (product.Id == update.Id)
                {
                    product.Name = update.Name;
                    product.Description = update.Description;
                }
                return product;
            }).ToList();
            return update;
        }

        public static void RemoveProduct(int id)
        {
            _products = _products.FindAll(product => product.Id != id).ToList();
        }
    }
}
