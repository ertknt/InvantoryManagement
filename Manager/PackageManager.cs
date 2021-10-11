using DataAccessLayer;
using DataAccessLayer.Model;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Manager
{
    public class PackageManager : IDataRepository<Package>
    {
        private readonly Context _packageContext;

        public PackageManager(Context packageContext)
        {
            _packageContext = packageContext;
        }
        public IEnumerable<Package> GetOptimalShipment()
        {
            float capacity = 104;
            float totalWeight = 0;
            List<Package> packageList = new List<Package>();
            List<Package> packageListOrderedByDescendingUnitPrice = (from p in _packageContext.Packages orderby p.UnitPrice descending select p).ToList();

            foreach (var package in packageListOrderedByDescendingUnitPrice)
            {
                if (totalWeight + package.Weight <= capacity)
                {
                    packageList.Add(package);
                    totalWeight += package.Weight;
                    _packageContext.Packages.Remove(package);
                }
            }

            return packageList;
        }
        public int InsertPackage(Package entity)
        {
            entity.UnitPrice = entity.Price / entity.Weight;

            _packageContext.Packages.Add(entity);

            return _packageContext.SaveChanges();
        }
    }
}
