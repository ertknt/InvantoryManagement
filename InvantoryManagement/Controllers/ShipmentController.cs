using DataAccessLayer.Model;
using InvantoryManagement.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InvantoryManagement.Controllers
{
    public class ShipmentController : ApiController
    {
        private readonly IShipmentRepository<Shipment> _shipmentRepository;

        public ShipmentController(IShipmentRepository<Shipment> shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        [Route("api/shipment/getPreviousShipment")]
        [HttpGet]
        public ResultModel<List<Shipment>> GetPreviousShipment(int id)
        {
            IEnumerable<Shipment> shipmentList = _shipmentRepository.GetPreviousShipments();

            return new ResultModel<List<Shipment>>
            {
                Data = shipmentList.ToList(),
                StatusCode = 200,
                Status = true,
            };
        }
    }
}
