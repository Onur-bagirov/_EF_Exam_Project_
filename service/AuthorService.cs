using _EF_Exam_Project_.context;
using _EF_Exam_Project_.entities;
namespace _EF_Exam_Project_.service
{
    public class AuthorService
    {
        private BookShopDataBase DataBase;
        public AuthorService(BookShopDataBase database)
        {
            DataBase = database;
        }
        public bool Add(Author author)
        {
            try
            {
                author.Create = DateTime.Now;
                author.Update = DateTime.Now;
                author.IsDeleted = false;
                DataBase.Add(author);
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
            var Author = DataBase.Authors.FirstOrDefault(x => x.ID ==  id && !x.IsDeleted);

            if (Author == null)
            {
                return false;
            }
            else
            {
                Author.IsDeleted = true;
                Author.Delete = DateTime.Now;
                DataBase.SaveChanges();
                return true;
            }
        }
        public bool Update(int id,Author update)
        {
            var Author = DataBase.Authors.FirstOrDefault(x => x.ID == id && !x.IsDeleted);

            if(Author == null)
            {
                return false;
            }
            else
            {
                Author.Name = update.Name;
                Author.Surname = update.Surname;
                Author.Update = DateTime.Now;
                DataBase.SaveChanges();
                return true;
            }
        }
        public Author ById(int id)
        {
            return DataBase.Authors.FirstOrDefault(x => x.ID == id && !x.IsDeleted);
        }
        public List<Author> GelAll()
        {
            return DataBase.Authors.Where(x => !x.IsDeleted).ToList();
        }
    }
}