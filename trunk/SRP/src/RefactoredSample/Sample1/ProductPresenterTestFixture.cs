using System.Collections.Generic;
using System.Windows.Forms;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Exceptions;

namespace Sample1
{
    [TestFixture]
    public class ProductPresenterTestFixture
    {
        protected ProductPresenter presenter;
        protected IProductView view;
        protected IProductRepository repository;
        protected IOpenFileDialog dialog;

        [SetUp]
        public void Setup()
        {
            SetupContext();
        }

        protected virtual void SetupContext()
        {
            // Arrange
            repository = MockRepository.GenerateMock<IProductRepository>();
            view = MockRepository.GenerateMock<IProductView>();
            dialog = MockRepository.GenerateMock<IOpenFileDialog>();
            presenter = new ProductPresenter(view, repository, dialog);
        }
    }

    [TestFixture]
    public class when_instantiating_product_presenter : ProductPresenterTestFixture
    {
        [Test]
        public void should_initialize_view()
        {
            view.AssertWasCalled(x => x.Initialize(presenter));
        }
    }

    [TestFixture]
    public class when_browsing_for_filename : ProductPresenterTestFixture
    {
        private string fileName;

        protected override void SetupContext()
        {
            base.SetupContext();
            // Arrange
            fileName = "Products.xml";
            dialog.Stub(x => x.ShowDialog()).Return(DialogResult.OK);
            dialog.Stub(x => x.FileName).Return(fileName);

            // Act
            presenter.BrowseForFileName();
        }

        [Test]
        public void should_call_open_file_dialog()
        {
            dialog.AssertWasCalled(x => x.ShowDialog());
        }

        [Test]
        public void should_set_file_name_on_view()
        {
            view.AssertWasCalled(x=>x.SetFileName(fileName));
        }
    }

    [TestFixture]
    public class when_browsing_for_filename_and_user_aborts : ProductPresenterTestFixture
    {
        private string fileName;

        protected override void SetupContext()
        {
            base.SetupContext();
            // Arrange
            fileName = "Products.xml";
            dialog.Stub(x => x.ShowDialog()).Return(DialogResult.Cancel);
            dialog.Stub(x => x.FileName).Return(fileName);

            // Act
            presenter.BrowseForFileName();
        }

        [Test][ExpectedException(typeof(ExpectationViolationException))]
        public void should_not_set_file_name_on_view()
        {
            view.AssertWasCalled(x=>x.SetFileName(fileName));
        }
    }

    public class when_getting_products_from_product_presenter : ProductPresenterTestFixture
    {
        private string fileName;
        private IEnumerable<Product> products;

        protected override void SetupContext()
        {
            base.SetupContext();
            // Arrange
            fileName = "Products.xml";
            products = new List<Product>();

            view.Stub(x => x.GetFileName()).Return(fileName);
            repository.Stub(x => x.GetByFileName(fileName)).Return(products);

            // Act
            presenter.GetProducts();
        }

        [Test]
        public void should_get_file_name_form_view()
        {
            view.AssertWasCalled(x => x.GetFileName());
        }

        [Test]
        public void should_get_products_from_repository()
        {

            repository.AssertWasCalled(x => x.GetByFileName(fileName));
        }

        [Test]
        public void should_pass_products_to_view_for_display()
        {
            view.AssertWasCalled(x => x.ShowProducts(products));
        }
    }
}