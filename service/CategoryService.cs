using _EF_Exam_Project_.context;
using _EF_Exam_Project_.entities;
namespace _EF_Exam_Project_.service
{
    public class CategoryService
    {
        private BookShopDataBase DataBase;
        public CategoryService(BookShopDataBase database)
        {
            DataBase = database;
        }
        public bool Add(Category category)
        {
            try
            {
                category.Create = DateTime.Now;
                category.Update = DateTime.Now;
                category.IsDeleted = false;
                DataBase.Add(category);
                DataBase.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            var Category = DataBase.Categories.FirstOrDefault(x => x.ID == id && !x.IsDeleted);

            if (Category == null)
            {
                return false;
            }
            else
            {
                Category.IsDeleted = true;
                Category.Delete = DateTime.Now;
                DataBase.SaveChanges();
                return true;
            }
        }
        public bool Update(int id,Category update)
        {
            var Category = DataBase.Categories.FirstOrDefault(x => x.ID == id && !x.IsDeleted);

            if(Category == null)
            {
                return false;
            }
            else
            {
                Category.Name = update.Name;
                Category.Update = DateTime.Now;
                DataBase.SaveChanges();
                return true;
            }
        }
        public Category ById(int id)
        {
            return DataBase.Categories.FirstOrDefault(x => x.ID == id && !x.IsDeleted);
        }
        public List<Category> GetAll()
        {
            return DataBase.Categories.Where(x => !x.IsDeleted).ToList();
        }
    }
}
