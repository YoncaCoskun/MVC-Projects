using System.Collections.Generic;
using System.Linq;
using BookyBook.Entity;
using BookyBook.Repository;

namespace BookyBook.Business
{
    public class BusinessBase<TEntity> where TEntity : class, IEntityKey
    {
        RepositoryBase<TEntity> _baseRepository = new RepositoryBase<TEntity>();

        public void Save(TEntity obj)
        {
            if (obj.Id > 0)
            {
                _baseRepository.Update(obj);
            }
            else
            {
                _baseRepository.Insert(obj);
            }
        }

        public void Delete(TEntity obj)
        {
            _baseRepository.Delete(obj);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _baseRepository.GetById(id);
        }

        public List<TEntity> ExecuteSql(string command, params object[] parameters)
        {
            return _baseRepository.ExecuteSql(command, parameters);
        }
    }
}
