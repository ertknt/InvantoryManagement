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
            List<Package> packageListOrderedByDescendingWeight = (from p in _packageContext.Packages orderby p.Price descending select p).ToList();

            foreach (var package in packageListOrderedByDescendingWeight)
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

        public IEnumerable<Package> GetPreviousShipments()
        {
            return (from p in _packageContext.Packages orderby p.Id descending select p).ToList();
        }

        public int InsertPackage(Package entity)
        {
            _packageContext.Packages.Add(entity);

            return _packageContext.SaveChanges();
        }
    }
}
