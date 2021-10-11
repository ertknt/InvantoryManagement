using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetPreviousShipments();
        IEnumerable<TEntity> GetOptimalShipment();
        int InsertPackage(TEntity entity);
    }
}
