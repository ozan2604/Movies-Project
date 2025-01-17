using Movies.DataAccessLayer.Abstract;
using Movies.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Movies.DataAccessLayer.Repositories
{
    public class GenericRepositories<T> : IGenericDal<T> where T : class
    {
        //public??
        public ApiContext _context; 

        public GenericRepositories(ApiContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            //var value = _context.Set<T>().Find(id);
            //_context.Set<T>().Remove(value);
            //_context.SaveChanges();

            var value = _context.Set<T>().Find(id);

            if (value == null)
            {
                throw new Exception($"Entity with ID {id} not found.");
            }

            _context.Set<T>().Remove(value);
            _context.SaveChanges();

            Console.WriteLine($"Entity with ID {id} has been deleted.");
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
