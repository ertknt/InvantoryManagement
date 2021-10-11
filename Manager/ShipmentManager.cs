using DataAccessLayer;
using DataAccessLayer.Model;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Manager
{
    class ShipmentManager : IShipmentRepository<Shipment>
    {
        private readonly Context _shipmentContext;

        public ShipmentManager(Context shipmentContext)
        {
            _shipmentContext = shipmentContext;
        }

        public IEnumerable<Shipment> GetPreviousShipments()
        {
            return _shipmentContext.Shipments.ToList();
        }
    }
}
