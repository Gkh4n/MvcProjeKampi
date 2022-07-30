using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context _context = new Context();
        DbSet<T> _object; // kategori sınıfının değerlerini tutuyor


        public GenericRepository()
        {
            _object = _context.Set<T>(); // dışarıdan gelen entity ne olursa objectin generiği o olacak
        }


        public void Delete(T p)
        {
            _object.Remove(p);
            _context.SaveChanges();
        }

        public void Insert(T p)
        {
            _object.Add(p);
            _context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList(); // filterdan gelen değere göre listeleme yapar
        }

        public void Update(T p)
        {
            _context.SaveChanges();
        }
    }
}
