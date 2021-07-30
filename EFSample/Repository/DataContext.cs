using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace EFSample.Repository
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Company> Companies { get; set; } = null!; 

        public DbSet<Link> Links { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());

            modelBuilder.Entity<Link>()
                .Property(e => e.LinkId)
                .HasDefaultValueSql("NEWID()");

            //modelBuilder.Entity<Link>()
            //    .HasOne<Company>(x => x.Company).WithMany<Link>();
            
            //GenerateSeedData(modelBuilder);
        }
       
        //move this to startup after ensuredb
        //private static void GenerateSeedData(ModelBuilder modelBuilder)
        //{
        //    var testCompanyId = new Guid("A53E2756-8228-44FB-9DC2-50AE7C7E6874");
        //    var LinkId1 = new Guid("B13E2756-8228-44FB-9DC2-50AE7C7E6874");
        //    var LinkId2 = new Guid("B23E2756-8228-44FB-9DC2-50AE7C7E6874");

        //    var link1 = new Link
        //        {LinkId = LinkId1, Name = "Link1", LinkType = "company link", Urls = "https://www.google.com"};
        //    var link2 = new Link
        //        {LinkId = LinkId2, Name = "link name2", LinkType = "Product link", Urls = "https://mail.google.com"};
        //    var listLinks = new List<Link> { link1, link2 };

        //    //modelBuilder.Entity<Link>().HasData(listLinks);

        //    modelBuilder.Entity<Company>().HasData(
        //        new Company
        //        {
        //            CompanyId = testCompanyId,
        //            Name = "Test Company"
        //            //, Links = listLinks //            //System.InvalidOperationException : The seed entity for entity type 'Link' cannot be added because a default value was provided for the required property 'LinkId'. Please provide a value different from '00000000-0000-0000-0000-000000000000'.   
        //        }
        //    );
        //}


    }
}


