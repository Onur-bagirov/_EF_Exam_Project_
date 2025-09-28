using _EF_Exam_Project_.context;
using _EF_Exam_Project_.entities;
using Microsoft.EntityFrameworkCore;
namespace _EF_Exam_Project_.service
{
    public class OrderService
    {
        private BookShopDataBase DataBase;
        public OrderService(BookShopDataBase database)
        {
            DataBase = database;
        }
        public bool Add(Order order,User user)
        {
            if(order == null)
            {
                return false;
            }
            else
            {
                order.Create = DateTime.Now;
                order.Update = DateTime.Now;
                order.IsDeleted = false;
                order.ID_User = user.ID;
                DataBase.Orders.Add(order);
                DataBase.SaveChanges();
                return true;
            }
        }
        public bool Delete(int id)
        {
            var Order = DataBase.Orders.FirstOrDefault(x => x.ID == id);

            if(Order != null)
            {
                Order.IsDeleted = true;
                Order.Delete = DateTime.Now;
                DataBase.SaveChanges();
                return true;
            }
            return false;
        }
        public void Update(Order order)
        {
            var Order = DataBase.Orders.FirstOrDefault(x => x.ID == order.ID);

            if (Order != null)
            {
                Order.Price = order.Price;
                Order.ID_User = order.ID_User;
                Order.Update = DateTime.Now;
                DataBase.SaveChanges();
            }
        }
        public Order ById(int id)
        {
            return DataBase.Orders.Include(o => o.OrderBook).FirstOrDefault(x => x.ID == id && !x.IsDeleted);
        }
        public List<OrderBook> GetAll()
        {
            return DataBase.OrderBook.Include(ob => ob.Book).Include(ob => ob.Order).Where(ob => !ob.IsDeleted).ToList();
        }
    }
}
