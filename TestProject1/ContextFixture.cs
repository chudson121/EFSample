using System;
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
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
