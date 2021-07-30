using System;
using System.Collections.Generic;
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
            var LinkId1 = new Guid("B13E2756-8228-44FB-9DC2-50AE7C7E6874");
            var LinkId2 = new Guid("B23E2756-8228-44FB-9DC2-50AE7C7E6874");

            var link1 = new Link
                { LinkId = LinkId1, Name = "Link1", LinkType = "company link", Urls = "https://www.google.com" };
            var link2 = new Link
                { LinkId = LinkId2, Name = "link name2", LinkType = "Product link", Urls = "https://mail.google.com" };
            var listLinks = new List<Link> { link1, link2 };


            Context.Companies.Add(new Company { CompanyId = _id, Links = listLinks });


            //Context.Companies.Add(new Company { CompanyId = _id, Name = "test"});
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