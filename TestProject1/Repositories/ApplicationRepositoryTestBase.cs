using EFSample;
using System;
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
            Context.Companies.Add(new Company { CompanyId = Guid.NewGuid() });
            Context.Companies.Add(new Company { CompanyId = Guid.NewGuid() });
            Context.Companies.Add(new Company { CompanyId = Guid.NewGuid() });
            Context.SaveChanges();

            Repository = new ApplicationRepository(Context);
        }
    }
}
