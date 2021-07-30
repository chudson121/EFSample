using System;
using EFSample;
using TechRadar.Infrastructure.Tests.Data;
using Xunit;

namespace TestProject1.Repositories
{
    [Collection("ContextFixture")]
    [Trait("Category", "TripleDerbyRepository")]
    public class Update : ApplicationRepositoryTestBase
    {
        private readonly Company _items;

        public Update(ContextFixture fixture) : base(fixture)
        {
            _items = new Company{CompanyId = new Guid("5FD2E324-A935-484E-8F9F-F52E7921EF21")};
            Context.Companies.Add(_items);
            Context.SaveChanges();
        }

        [Fact]
        public void ItUpdatesItem()
        {
            // Arrange
            _items.Name = "Updated";
            
            // Act
            Repository.Update(_items);

            // Assert
            Assert.Contains(Context.Companies, x => x.Name == "Updated");
        }
    }
}