using System.Xml;

namespace Sample1
{
    public interface IProductMapper
    {
        Product Map(XmlReader reader);
    }
}