using System;
using System.Collections.Generic;
using System.Linq;
using EFSample;
using EFSample.Repository;
using Microsoft.EntityFrameworkCore;

namespace TechRadar.Infrastructure.Tests.Data
{
    public class ContextFixture : IDisposable
    {
        public DataContext Context { get; }

        public ContextFixture()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("MemoryDatastore")
                .EnableSensitiveDataLogging(true)
                .Options;

            Context = new DataContext(options);

            //var testCompanyId = new Guid();
            //var LinkId1 = new Guid();
            //var LinkId2 = new Guid();
            var testCompanyId = new Guid("A53E2756-8228-44FB-9DC2-50AE7C7E6874");
            var LinkId1 = new Guid("B13E2756-8228-44FB-9DC2-50AE7C7E6874");
            var LinkId2 = new Guid("B23E2756-8228-44FB-9DC2-50AE7C7E6874");
            var addyId1 = new Guid("A33E2756-8228-44FB-9DC2-50AE7C7E6874");

            if (Context.Companies.Any(x => x.CompanyId == testCompanyId))
                return;

            var link1 = new Link
                { LinkId = LinkId1, Name = "Link1", LinkType = "company link", Urls = "https://www.google.com" };
            var link2 = new Link
                { LinkId = LinkId2, Name = "link name2", LinkType = "Product link", Urls = "https://mail.google.com" };
            var listLinks = new List<Link> { link1, link2 };
            //Address hqAddy = new Address { };

            
            Context.Companies.Add(new Company { CompanyId = testCompanyId, Links = listLinks, HeadquarterAddress = new Address("street", "city", "FL","USA", "33547", AddressType.Mailing)});
            Context.Companies.Add(new Company { CompanyId = Guid.NewGuid() });
            Context.Companies.Add(new Company { CompanyId = Guid.NewGuid() });
            Context.SaveChanges();

            

        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
