using ChocolateStoreClassLibrary.Models;
using ChocolateStoreClassLibrary.Repositorys;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace ChocolateStoreNUnitTestProject
{
    public class ItemsRepositoryTests
    {
        private TransactionScope transactionScope;
        private IItemsDBRepository repository;
        private StoreContext context;
        [SetUp]
        public void Setup()
        {
            context = new StoreContext();
            repository = new ItemDBRepository(context);
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
            //Act
            int countBefore = context.Items.Count();
            await repository.Add(item);
            int countAfter = context.Items.Count();

            //Assert            
            Assert.AreEqual(countAfter - 1, countBefore);
        }

        [Test]
        public async Task Add_IncorrectData_NullObject()
        {
            //Arrange         
            Item item = null;
            bool failed = false;
            //Act
            try
            {
                await repository.Add(item);
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
            var item = new Item();
            bool failed = false;
            //Act
            try
            {
                await repository.Add(item);
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
            bool failed = false;
            //Act
            try
            {
                var sale = await repository.Find(1);
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
            int id = context.Items.FirstOrDefault(x => x != null).Id;
            var sale = await repository.Find(id);

            //Assert 
            Assert.IsNotNull(sale);
        }

        [Test]
        public async Task Update_CorrectData()
        {
            //Arrange
            var item = new Item { Name = "Тестовый продукт", Price = 1 };
            int id = context.Items.FirstOrDefault(x => x != null).Id;
            //Act
            int countBefore = context.Items.Count();
            await repository.Update(item, id);
            int countAfter = context.Items.Count();
            Item item2 = await repository.Find(id);
            //Assert            
            Assert.AreEqual(item2.Name, item.Name);
            Assert.AreEqual(countBefore, countAfter);
        }

        [Test]
        public async Task Update_IncorrectData_IncorrectID()
        {
            //Arrange         
            var item = new Item { Name = "Тестовый продукт", Price = 1 };
            bool failed = false;
            //Act
            try
            {
                await repository.Update(item, -1);
            }
            catch
            {
                failed = true;
            }
            //Assert 
            Assert.IsTrue(failed);
        }

        [Test]
        public async Task Update_IncorrectData_IncorrectObject()
        {
            //Arrange
            var item = new Item();
            bool failed = false;
            //Act
            try
            {
                await repository.Update(item, 1);
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
