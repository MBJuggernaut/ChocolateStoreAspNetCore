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
            var item = new Item { Name = "�������� �������", Price = 1 };
            List<Item> Items = new List<Item>() { item };
            var sale = new Sale { Items = Items };
            //Act
            int countBefore = context.Sales.Count();
            repository.Add(sale);
            int countAfter = context.Sales.Count();

            //Assert            
            Assert.AreEqual(countAfter - 1, countBefore);
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
            //Assert 
            Assert.IsTrue(failed);

        }
        [Test]
        public void Add_IncorrectData_IncorrectObject()
        {
            //Arrange
            var sale = new Sale();
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
    }
}