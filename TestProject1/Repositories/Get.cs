using System;
using System.Threading.Tasks;
using EFSample;
using TechRadar.Infrastructure.Tests.Data;
using Xunit;

namespace TestProject1.Repositories
{
    [Collection("ContextFixture")]
    [Trait("Category", "TripleDerbyRepository")]
    public class Get : ApplicationRepositoryTestBase
    {
        private readonly Guid _id;

        public Get(ContextFixture fixture) : base(fixture)
        {
            _id = Guid.NewGuid();

            Context.Companies.Add(new Company { CompanyId = _id, Name = "test"});
            Context.SaveChanges();
        }

        [Fact]
        public async Task ItReturnsItem()
        {
            // Arrange
            // Act
            var item = await Repository.Get(new CompanyQuery(_id));

            // Assert
            Assert.IsAssignableFrom<Company>(item);
        }
    }
}