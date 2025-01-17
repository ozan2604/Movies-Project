using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T item);    
        void Update(T item);    
        void Delete(int id);  
        T GetById(int id);

        List<T> GetAll();

    }
}
