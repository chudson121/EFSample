using EFSample;
using System;
using System.Collections.Generic;
using EFSample.Repository;
using TechRadar.Infrastructure.Tests.Data;
using Xunit;

namespace TestProject1.Repositories
{
    public class ApplicationRepositoryTestBase : IClassFixture<ContextFixture>
    {
        protected readonly DataContext Context;
        protected readonly ApplicationRepository Repository;

        public ApplicationRepositoryTestBase(ContextFixture fixture)
        {
            Context = fixture.Context;

            var testCompanyId = new Guid();
            var LinkId1 = new Guid();
            var LinkId2 = new Guid();

            var link1 = new Link
                { LinkId = LinkId1, Name = "Link1", LinkType = "company link", Urls = "https://www.google.com" };
            var link2 = new Link
                { LinkId = LinkId2, Name = "link name2", LinkType = "Product link", Urls = "https://mail.google.com" };
            var listLinks = new List<Link> { link1, link2 };


            Context.Companies.Add(new Company { CompanyId = testCompanyId, Links = listLinks});
            Context.Companies.Add(new Company { CompanyId = Guid.NewGuid() });
            Context.Companies.Add(new Company { CompanyId = Guid.NewGuid() });
            Context.SaveChanges();

            Repository = new ApplicationRepository(Context);
        }
    }
}
