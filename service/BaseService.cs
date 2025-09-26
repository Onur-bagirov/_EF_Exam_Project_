using _EF_Exam_Project_.context;
namespace _EF_Exam_Project_.Services
{
    public abstract class BaseService
    {
        protected BookShopDataBase Database;
        public BaseService(BookShopDataBase database)
        {
            Database = database;
        }
    }
}
