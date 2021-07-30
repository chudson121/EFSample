using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            _id = new Guid("A53E2756-8228-44FB-9DC2-50AE7C7E6874");
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

        [Fact]
        public async Task ItReturnsItemWithLinks()
        {
            // Arrange
            // Act
            var item = await Repository.Get(new CompanyQuery(_id));

            // Assert
            Assert.IsAssignableFrom<Company>(item);
            Assert.True(item.Links.Count > 0);
        }
    }
}