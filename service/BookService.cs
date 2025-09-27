using _EF_Exam_Project_.context;
using _EF_Exam_Project_.entities;
namespace _EF_Exam_Project_.service
{
    public class BookService
    {
        private BookShopDataBase DataBase;
        public BookService(BookShopDataBase database)
        {
            DataBase = database;
        }
        public bool Add(Book book)
        {
            try
            {
                book.Create = DateTime.Now;
                book.Update = DateTime.Now;
                book.IsDeleted = false;
                DataBase.Add(book);
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
            var Book = DataBase.Books.FirstOrDefault(x => x.ID == id && !x.IsDeleted);

            if(Book == null)
            {
                return false;
            }
            else
            {
                Book.IsDeleted = true;
                Book.Delete = DateTime.Now;
                DataBase.SaveChanges();
                return true;
            }
        }
        public bool Update(int id,Book update)
        {
            var Book = DataBase.Books.FirstOrDefault(x => x.ID == id && !x.IsDeleted);

            if(Book == null)
            {
                return false;
            }
            else
            {
                Book.Title = update.Title;
                Book.Price = update.Price;
                Book.ID_Author = update.ID_Author;
                Book.ID_Category = update.ID_Category;
                Book.Update = DateTime.Now;
                DataBase.SaveChanges();
                return true;
            }
        }
        public Book ById(int id)
        {
            return DataBase.Books.FirstOrDefault(x => x.ID == id && !x.IsDeleted);
        }
        public List<Book> GelAll()
        {
            return DataBase.Books.Where(x => !x.IsDeleted).ToList();
        }
    }
}
