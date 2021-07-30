using System;
using System.Threading.Tasks;
using EFSample;
using TechRadar.Infrastructure.Tests.Data;
using Xunit;

namespace TestProject1.Repositories
{
    [Collection("ContextFixture")]
    [Trait("Category", "TripleDerbyRepository")]
    public class Delete : ApplicationRepositoryTestBase
    {
        private readonly Company _item;

        public Delete(ContextFixture fixture) : base(fixture)
        {
            _item = new Company { CompanyId = new Guid("D6012CB6-6184-4AB4-BE14-B29C61F2CB32") };
            Context.Companies.Add(_item);
            Context.SaveChanges();
        }

        [Fact]
        public async Task ItRemovesItem()
        {
            // Arrange
            // Act
            Repository.Delete(_item);
            //await Repository.Save();

            // Assert
            Assert.DoesNotContain(Context.Companies, x => x == _item);
        }
    }
}