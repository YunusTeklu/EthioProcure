using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EthioProcure.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public String firstName { get; set; }
        public String fathrName { get; set; }
        public String gFatherName { get; set; }
        public String role { get; set; }
        public byte[] employementContract { get; set; }
        public String password { get; set; }
        public String email { get; set; }
        public String telephone { get; set; }

        public int OrganizationId { get; set; }
        public Organization org { get; set; }
    }
}