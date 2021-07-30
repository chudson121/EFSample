using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFSample.Repository
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable(nameof(Company));

            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);

            
            builder.HasKey(x => x.CompanyId);// Make the Primary Key associated with this property

            builder.HasMany(f => f.Links).WithOne();

            builder.OwnsOne(f => f.HeadquarterAddress);
          
            
            //Column Attributes
            builder.Property(e => e.CompanyId).HasDefaultValueSql("NEWID()");

            builder.Property(e => e.IsActive).HasConversion<int>();

            builder.Property(e => e.CreatedDate).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(e => e.UpdatedDate).HasDefaultValueSql("GETUTCDATE()");
            
        }
    }
}