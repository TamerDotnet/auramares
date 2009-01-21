using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Sample1
{
    public class ProductRepository : IProductRepository
    {
        private readonly IFileLoader loader;
        private readonly IProductMapper mapper;

        public ProductRepository()
            : this(new FileLoader(), new ProductMapper())
        {
        }

        public ProductRepository(IFileLoader loader, IProductMapper mapper)
        {
            this.loader = loader;
            this.mapper = mapper;
        }

        public IEnumerable<Product> GetByFileName(string fileName)
        {
            var products = new List<Product>();
            using (Stream input = loader.Load(fileName))
            {
                var reader = XmlReader.Create(input);
                while (reader.Read())
                {
                    if (reader.Name != "product") continue;
                    var product = mapper.Map(reader);
                    products.Add(product);
                }
            }
            return products;
        }
    }
}