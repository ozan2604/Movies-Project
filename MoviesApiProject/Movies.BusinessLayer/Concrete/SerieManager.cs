using Movies.BusinessLayer.Abstract;
using Movies.DataAccessLayer.Abstract;
using Movies.DtoLayer.SerieDtos;
using Movies.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BusinessLayer.Concrete
{
    public class SerieManager : GenericManager<Serie>, ISerieService
    {
            private readonly ISerieDal _serieDal;
            public SerieManager(IGenericDal<Serie> genericDal, ISerieDal serieDal) : base(genericDal)
            {
                _serieDal = serieDal;
            }

            public int SerieCount()
            {
                return _serieDal.SerieCount();
            }

            public List<Serie> TLast3Serie()
            {
                return _serieDal.Last3Serie();
            }

            public SerieWithCategoryDto TSerieWithCategory(int id)
            {
                return _serieDal.SerieWithCategory(id);
            }
        }

    }

