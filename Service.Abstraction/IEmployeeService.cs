using Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction
{
    public interface IEmployeeService
    {
        //getall
        public List<EmployeeDTO> getAll();
        //get by id
        public EmployeeDTO GetEmployeeById(int Id);
        //add employee
        public string AddEmployee(EmployeeDTO emp);
        //remove employee
        public string RemoveEmployee(int Id);
        //update employee
        public string UpdateEmployee(EmployeeDTO emp);

        public EmployeeDispDTOS GetUser(string userName, string password);      

       
    }
}
