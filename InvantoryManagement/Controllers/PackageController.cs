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
    public class PackageController : ApiController
    {
        private readonly IDataRepository<Package> _dataRepository;

        public PackageController(IDataRepository<Package> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        /*
         Hava yolu şirketinin bir gönderim için kargo uçağında sahip olduğu kapasite 
        maksimum 104 kg ‘dir. Bu web servis; depo envanterinde bulunan paketlerden 104 kg’i 
        geçmeyecek şekilde toplam fiyat değeri en yüksek paket listesini oluşturur ve bu listeyi döner. Bu 
        servis aynı zamanda söz konusu paketleri envanterden düşmelidir. Tekrar çağrıldığında yalnızca 
        depoda kalan paketler için çalışmalıdır.
         */
        [Route("api/package/getOptimalShipment")]
        [HttpGet]
        public ResultModel<List<Package>> GetOptimalShipment(int id)
        {
            IEnumerable<Package> packageList = _dataRepository.GetOptimalShipment();

            return new ResultModel<List<Package>>
            {
                Data = packageList.ToList(),
                StatusCode = 200,
                Status = true,
            };
        }

        //Ağırlık ve fiyat değerlerine sahip pake6 depo envanterine kaydeder.
        [Route("api/package/post")]
        [HttpPost]
        public ResultModel InsertPackage([FromBody] Package package)
        {
            int result = _dataRepository.InsertPackage(package);

            if (result > 0)
            {
                return new ResultModel()
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Successfully saved."
                };
            }
            else
            {
                return new ResultModel()
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Failed."
                };
            }
        }
    }
}
