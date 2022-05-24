using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int UserTypeId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeAddress { get; set; }
    }
}
