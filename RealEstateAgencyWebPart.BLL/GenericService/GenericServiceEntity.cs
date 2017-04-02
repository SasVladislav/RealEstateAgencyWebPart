using RealEstateAgencyWebPart.DAL.EF;
using RealEstateAgencyWebPart.DAL.RepositoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.GenericService
{
    public class GenericServiceEntity<TClass> where TClass:class
    {
        private Repository<TClass> repository;
        public GenericServiceEntity()
        {
            repository = new Repository<TClass>();
        }
        public TClass CreateItem(TClass item, Expression<Func<TClass, bool>> where)
        {
            if (item != null && repository.FindOne(where) == null)
            {
               TClass result = repository.Create(item);
                repository.SaveChanges();
                return result;
            }
            else return repository.FindOne(where);
        }

        public bool UpdateItem(TClass item)
        {
            if (item != null)
            {
                repository.Update(item);
                repository.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteItem(int id)
        {
            if (id != 0 && repository.FindById(id) != null)
            {
                repository.Delete(id);
                repository.SaveChanges();
                return true;
            }
            else return false;
        }

        public TClass FindById(int id)
        {
            if (id!=0)
            {
                return repository.FindById(id);
            }
            return null;
        }

        public TClass FindOne(Expression<Func<TClass, bool>> where = null)
        {
            return repository.FindOne(where);
        }

        public ICollection<TClass> FindAll(Expression<Func<TClass, bool>> where = null)
        {
            return null != where ? repository.FindAll(where) : repository.FindAll();//predicate
        }
    }
}
