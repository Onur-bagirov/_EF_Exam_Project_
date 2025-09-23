using _EF_Exam_Project_.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace _EF_Exam_Project_.entitiesConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.OrderDateTime).IsRequired();
            builder.Property(x => x.ID_User).IsRequired();
            builder.Property(x => x.ID_Book).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Order).HasForeignKey(x => x.ID_User);
            builder.HasMany(x => x.OrderBook).WithOne(x => x.Order).HasForeignKey(x => x.ID_Order);
        }
    }
}