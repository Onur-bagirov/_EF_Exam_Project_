using _EF_Exam_Project_.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace _EF_Exam_Project_.entitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();

            builder.HasMany(x => x.Book).WithOne(x => x.Category).HasForeignKey(x => x.ID_Category);
        }
    }
}