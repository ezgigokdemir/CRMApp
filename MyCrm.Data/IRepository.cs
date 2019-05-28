using MyCrm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCrm.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T entitiy);
        void Update(T entitiy);
        void Delete(T entity);
        T Find(Guid id);
        IEnumerable<T> GetAll();
    }
}
