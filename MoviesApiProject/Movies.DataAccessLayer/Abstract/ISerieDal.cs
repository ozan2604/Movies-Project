using Movies.DtoLayer.SerieDtos;
using Movies.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccessLayer.Abstract
{
    public interface ISerieDal : IGenericDal<Serie>
    {
        List<Serie> Last3Serie();
        SerieWithCategoryDto SerieWithCategory(int id);

        int SerieCount();   
    }
}
