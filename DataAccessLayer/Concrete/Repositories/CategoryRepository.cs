using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context _context = new Context();
        DbSet<Category> _object; // kategori sınıfının değerlerini tutuyor

        public void Delete(Category category)
        {
            _object.Remove(category);
            _context.SaveChanges();
        }

        public void Insert(Category category)
        {
            _object.Add(category);
            _context.SaveChanges(); // değişiklikleri kaydet
        }

        public List<Category> List()
        {
            return _object.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(Category category)
        {
            _context.SaveChanges();
        }
    }
}
