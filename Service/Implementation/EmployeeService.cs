using Contracts;
using Domain;
using Domain.Repositories;
using Mapster;
using Persistence;
using Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

       

        public string AddEmployee(EmployeeDTO empdto)
        {
            var emp = empdto.Adapt<Employee>();
            emp.UserTypeId = empdto.UserTypeId;
            _employeeRepository.addEmployee(emp);
            return "record is added successfully";  
        }

        public List<EmployeeDTO> getAll()
        {
            List<EmployeeDTO> empdto = new List<EmployeeDTO>();
            List<Employee> emp = _employeeRepository.GetAllEmployees();
            foreach(var e in emp)
            {
                empdto.Add(e.Adapt<EmployeeDTO>());
            }
            return empdto;
        }

        public EmployeeDTO GetEmployeeById(int Id)
        {
            var emp = _employeeRepository.getEmployeeById(Id);
           var empdto= emp.Adapt<EmployeeDTO>();
           return empdto;
        }

        public EmployeeDispDTOS GetUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public string RemoveEmployee(int Id)
        {
            _employeeRepository.removeEmployee(Id);
            return "success";
        }

        public string UpdateEmployee(EmployeeDTO emp)
        {
            _employeeRepository.editEmployee(emp.EmployeeId);
            return "Record is Added Successfully";
        }
    }
}
