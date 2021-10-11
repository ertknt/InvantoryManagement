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
            List<Package> packageListOrderedByDescendingUnitPrice = (from p in _packageContext.Packages where p.Status == 1 orderby p.Price/p.Weight descending select p).ToList();

            foreach (var package in packageListOrderedByDescendingUnitPrice)
            {
                if (totalWeight + package.Weight <= capacity)
                {
                    packageList.Add(package);
                    totalWeight += package.Weight;
                    package.Status = 2;
                    _packageContext.SaveChanges();
                }
            }

            return packageList;
        }
        public int InsertPackage(Package entity)
        {
            entity.Status = 1;

            _packageContext.Packages.Add(entity);

            return _packageContext.SaveChanges();
        }
    }
}
