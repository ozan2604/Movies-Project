using Movies.DtoLayer.SerieDtos;
using Movies.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BusinessLayer.Abstract
{
    public interface ISerieService : IGenericService<Serie>
    {
        List<Serie> TLast3Serie();
        SerieWithCategoryDto TSerieWithCategory(int id);
        int SerieCount();
    }
}
