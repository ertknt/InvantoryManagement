using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Package
    {
        public int Id { get; set; }
        public float Weight { get; set; }
        public float Price { get; set; }
        public int Status { get; set; }
    }
}
