using _EF_Exam_Project_.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace _EF_Exam_Project_.entitiesConfiguration
{
    public class OrderBookConfiguration : IEntityTypeConfiguration<OrderBook>
    {
        public void Configure(EntityTypeBuilder<OrderBook> builder)
        {
            builder.ToTable("OrderBook");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.ID_Book).IsRequired();
            builder.Property(x => x.ID_Order).IsRequired();
            builder.Property(x => x.ID_User).IsRequired();
            builder.Property(x => x.ID_Author).IsRequired();
            builder.Property(x => x.ID_Category).IsRequired();

            builder.HasOne(x => x.Book).WithMany(x => x.OrderBook).HasForeignKey(x => x.ID_Book);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderBook).HasForeignKey(x => x.ID_Order);
        }
    }
}