using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvantoryManagement.Models
{
    public class PackageVM
    {
        public int Id { get; set; }
        public float Weight { get; set; }
        public float Price { get; set; }
        public float UnitPrice { get; set; }
    }
}