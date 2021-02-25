using ChocolateStoreConsoleApp.Models;
using ChocolateStoreConsoleApp.Repositorys;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using System.Transactions;
using System.Collections.Generic;
using System.Linq;

namespace ChocolateStoreNUnitTestProject
{
    public class SalesRepositoryTests
    {
        private TransactionScope transactionScope;
        private ISalesDBRepository repository;
        private SalesContext context;
        [SetUp]
        public void Setup()
        {
            MyContainer.Initialize();
            repository = MyContainer.provider.GetService<ISalesDBRepository>();
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
            List<Item> Items = new List<Item>() { item };
            //var sale = new Sale(Items) { Id = 2, Items = Items};
            var sale = new Sale { Id = 2, Items = Items };
            //Act
            int countBefore = context.Sales.Count();
            repository.Add(sale);
            int countAfter = context.Sales.Count();
            Sale thisSaleFromRepository = repository.Find(2);
            //Assert            
            Assert.AreEqual(countAfter - 1, countBefore);
            Assert.IsNotNull(thisSaleFromRepository);
        }
        [Test]
        public void Add_IncorrectData_NullObject()
        {
            //Arrange         
            Sale sale = null;
            bool failed = false;
            //Act
            try
            {
                repository.Add(sale);                
            }
            catch
            {
                failed = true;               
            }

            Assert.IsTrue(failed);

        }
        [Test]
        public void Add_IncorrectData_IncorrectObject()
        {
            Assert.Pass();
        }

        [Test]
        public void Delete()
        {
            Assert.Pass();
        }

        [Test]
        public void Find()
        {
            Assert.Pass();
        }

        [Test]
        public void Update()
        {
            Assert.Pass();
        }
    }
}