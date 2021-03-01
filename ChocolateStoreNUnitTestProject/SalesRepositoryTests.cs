using ChocolateStoreClassLibrary.Models;
using ChocolateStoreClassLibrary.Repositorys;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace ChocolateStoreNUnitTestProject
{
    public class SalesRepositoryTests
    {
        private TransactionScope transactionScope;
        private ISalesDBRepository repository;
        private StoreContext context;
        [SetUp]
        public void Setup()
        {
            MyContainer.Initialize();
            repository = MyContainer.Provider.GetService<ISalesDBRepository>();
            context = MyContainer.Provider.GetService<StoreContext>();

            transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        }

        [TearDown]
        public void CleanUp()
        {
            transactionScope.Dispose();
        }

        [Test]
        public async Task Add_CorrectData()
        {
            //Arrange
            var item = new Item { Name = "Тестовый продукт", Price = 1 };
            List<Item> Items = new List<Item>() { item };
            var sale = new Sale { Items = Items };
            //Act
            int countBefore = context.Sales.Count();
            await repository.Add(sale);
            int countAfter = context.Sales.Count();

            //Assert            
            Assert.AreEqual(countAfter - 1, countBefore);
        }
        [Test]
        public async Task Add_IncorrectData_NullObject()
        {
            //Arrange         
            Sale sale = null;
            bool failed = false;
            //Act
            try
            {
                await repository.Add(sale);
            }
            catch
            {
                failed = true;
            }
            //Assert 
            Assert.IsTrue(failed);

        }
        [Test]
        public async Task Add_IncorrectData_IncorrectObject()
        {
            //Arrange
            var sale = new Sale();
            bool failed = false;
            //Act
            try
            {
                await repository.Add(sale);
            }
            catch
            {
                failed = true;
            }
            //Assert 
            Assert.IsTrue(failed);
        }

        [Test]
        public async Task Delete()
        {
            int id = context.Sales.FirstOrDefault(x => x != null).Id;
            bool failed = false;
            //Arrange
            await repository.Delete(id);
            //Act
            try
            {
                var sale = await repository.Find(id);
            }
            catch
            {
                failed = true;
            }
            
            //Assert 
            Assert.IsTrue(failed);
        }

        [Test]
        public async Task Find()
        {
            int id = context.Sales.FirstOrDefault(x => x != null).Id;
            var sale = await repository.Find(id);

            //Assert 
            Assert.IsNotNull(sale);
        }
    }
}