using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using System.Transactions;
using System.Linq;
using ChocolateStoreConsoleApp.Repositorys;
using ChocolateStoreConsoleApp.Models;

namespace ChocolateStoreNUnitTestProject
{
    public class ItemsRepositoryTests
    {
        private TransactionScope transactionScope;
        private IItemsDBRepository repository;
        private SalesContext context;
        [SetUp]
        public void Setup()
        {
            MyContainer.Initialize();
            repository = MyContainer.provider.GetService<IItemsDBRepository>();
            context = MyContainer.provider.GetService<SalesContext>();

            transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        }

        [TearDown]
        public void CleanUp()
        {
            transactionScope.Dispose();
        }

        [Test]
        public void Add_CorrectData()
        {
            //Arrange
            var item = new Item { Name = "Тестовый продукт", Price = 1 };
            //Act
            int countBefore = context.Items.Count();
            repository.Add(item);
            int countAfter = context.Items.Count();

            //Assert            
            Assert.AreEqual(countAfter - 1, countBefore);
        }

        [Test]
        public void Add_IncorrectData_NullObject()
        {
            //Arrange         
            Item item = null;
            bool failed = false;
            //Act
            try
            {
                repository.Add(item);
            }
            catch
            {
                failed = true;
            }
            //Assert 
            Assert.IsTrue(failed);
        }

        [Test]
        public void Add_IncorrectData_IncorrectObject()
        {
            //Arrange
            var item = new Item();
            bool failed = false;
            //Act
            try
            {
                repository.Add(item);
            }
            catch
            {
                failed = true;
            }
            //Assert 
            Assert.IsTrue(failed);
        }

        [Test]
        public void Delete()
        {
            //Arrange
            repository.Delete(1);
            //Act
            var sale = repository.Find(1);
            //Assert 
            Assert.IsNull(sale);
        }

        [Test]
        public void Find()
        {
            var sale = repository.Find(1);

            //Assert 
            Assert.IsNotNull(sale);
        }

        [Test]
        public void Update_CorrectData()
        {
            //Arrange
            var item = new Item { Name = "Тестовый продукт", Price = 1 };
            //Act
            int countBefore = context.Items.Count();
            repository.Update(item, 1);
            int countAfter = context.Items.Count();

            //Assert            
            Assert.AreEqual(repository.Find(1).Name, item.Name);
            Assert.AreEqual(countBefore, countAfter);
        }

        [Test]
        public void Update_IncorrectData_NullObject()
        {
            //Arrange         
            Item item = null;
            bool failed = false;
            //Act
            try
            {
                repository.Add(item);
            }
            catch
            {
                failed = true;
            }
            //Assert 
            Assert.IsTrue(failed);
        }

        [Test]
        public void Update_IncorrectData_IncorrectObject()
        {
            //Arrange
            var item = new Item();
            bool failed = false;
            //Act
            try
            {
                repository.Add(item);
            }
            catch
            {
                failed = true;
            }
            //Assert 
            Assert.IsTrue(failed);
        }
    }
}
