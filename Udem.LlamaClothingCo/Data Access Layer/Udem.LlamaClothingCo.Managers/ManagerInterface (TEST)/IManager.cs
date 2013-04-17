using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Udem.LlamaClothingCo.Managers
{
    public interface IManager<T> where T: class
    {
        T GetByID(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> criteria);
        void AddRecord(T record);
        void UpdateRecord(T record);
        void DeleteRecord(T record);
    }
}
