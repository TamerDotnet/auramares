using System.IO;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;

namespace Sample1
{
    [TestFixture]
    public class ProductRepositoryTestFixture
    {
        private ProductRepository repository;
        private IProductMapper mapper;
        private string fileName;
        private IFileLoader fileLoader;

        [SetUp]
        public void SetupContext()
        {
            fileName = "products.xml";
            mapper = MockRepository.GenerateMock<IProductMapper>();
            fileLoader = MockRepository.GenerateMock<IFileLoader>();
            repository=new ProductRepository(fileLoader, mapper);

            // Arrange
            var xmlFragment = "<product id='1' name='xyz' unitPrice='10.44' discontinued='true' />";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.WriteLine("<products>");
            writer.WriteLine(xmlFragment);
            writer.WriteLine(xmlFragment);
            writer.WriteLine("</products>");
            writer.Flush();
            ms.Position = 0;
            fileLoader.Stub(x => x.Load(fileName)).Return(ms);
        }

        [Test]
        public void xml_document_is_loaded_via_file_helper()
        {
            // Act
            repository.GetByFileName(fileName);
            // Assert
            fileLoader.AssertWasCalled(x => x.Load(fileName));
        }

        [Test]
        public void mapper_is_called_to_map_from_xml_reader_to_product()
        {
            // Act
            repository.GetByFileName(fileName);
            // Assert
            mapper.AssertWasCalled(x => x.Map(null), o => o.IgnoreArguments());
        }

        [Test]
        public void all_products_are_mapped_from_the_xml_document()
        {
            var products = repository.GetByFileName(fileName);
            Assert.AreEqual(2, products.Count());
        }
    }
}