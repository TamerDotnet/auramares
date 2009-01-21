using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Sample1.Step3
{
    //public class ProductRepository : IProductRepository
    //{
    //    public IEnumerable<Product> GetByFileName(string fileName)
    //    {
    //        var products = new List<Product>();
    //        using (var fs = new FileStream(fileName, FileMode.Open))
    //        {
    //            var reader = XmlReader.Create(fs);
    //            while (reader.Read())
    //            {
    //                if (reader.Name != "product") continue;
    //                var product = new Product();
    //                product.Id = int.Parse(reader.GetAttribute("id"));
    //                product.Name = reader.GetAttribute("name");
    //                product.UnitPrice = decimal.Parse(reader.GetAttribute("unitPrice"));
    //                product.Discontinued = bool.Parse(reader.GetAttribute("discontinued"));
    //                products.Add(product);
    //            }
    //        }
    //        return products;
    //    }
    //}

    public class ProductRepository : IProductRepository
    {
        private readonly IFileLoader loader;
        private readonly IProductMapper mapper;

        public ProductRepository()
        {
            loader = new FileLoader();
            mapper = new ProductMapper();
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