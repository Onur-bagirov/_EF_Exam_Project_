using _EF_Exam_Project_.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace _EF_Exam_Project_.entitiesConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.ID_Author).IsRequired();
            builder.Property(x => x.ID_Category).IsRequired();

            builder.HasOne(x => x.Author).WithMany(x => x.Book).HasForeignKey(x => x.ID_Author);
            builder.HasOne(x => x.Category).WithMany(x => x.Book).HasForeignKey(x => x.ID_Category);
        }
    }
}
