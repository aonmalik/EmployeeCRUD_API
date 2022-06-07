using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
  public  interface IEmployeeRepository
    {
        public List<Employee> GetAllEmployees();
        public Employee getEmployeeById(int Id);
        public string addEmployee(Employee emp);
        public string removeEmployee(int Id);
        public string editEmployee(Employee emp);
        public Employee GetUserByIdandPassword(string username, string password);
      

    }
}
