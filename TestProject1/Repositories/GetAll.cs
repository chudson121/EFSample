using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFSample;
using TechRadar.Infrastructure.Tests.Data;
using Xunit;

namespace TestProject1.Repositories
{
    [Collection("ContextFixture")]
    [Trait("Category", "TripleDerbyRepository")]
    public class GetAll : ApplicationRepositoryTestBase
    {
        public GetAll(ContextFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task ItReturnsAllItems()
        {
            // Arrange
            var spec = new CompanyQuery(0, 100, null);

            var items = await Repository.List(spec);
            // Act
            

            // Assert
            Assert.IsAssignableFrom<IEnumerable<Company>>(items);
            Assert.Equal(Context.Companies.Count(), items.Count);
        }
    }
}