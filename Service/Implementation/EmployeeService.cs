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
        private readonly IRepositoryManager _repositoryManager;
        public EmployeeService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

       

        public string AddEmployee(EmployeeDTO empdto)
        {
            var emp = empdto.Adapt<Employee>();
            emp.UserTypeId = empdto.UserTypeId;
            _repositoryManager.employeeRepository.addEmployee(emp);
            return "record is added successfully";  
        }

        public List<EmployeeDTO> getAll()
        {
            List<EmployeeDTO> empdto = new List<EmployeeDTO>();
            List<Employee> emp = _repositoryManager.employeeRepository.GetAllEmployees();
            foreach(var e in emp)
            {
                empdto.Add(e.Adapt<EmployeeDTO>());
            }
            return empdto;
        }

        public EmployeeDTO GetEmployeeById(int Id)
        {
            var emp = _repositoryManager.employeeRepository.getEmployeeById(Id);
           var empdto= emp.Adapt<EmployeeDTO>();
           return empdto;
        }

        public EmployeeDTO GetEmployeeByIdandPassword(string userName, string password)
        {
           var user= _repositoryManager.employeeRepository.GetUserByIdandPassword(userName, password);
            var userdto = user.Adapt<EmployeeDTO>();
            return userdto;
        }

        public string RemoveEmployee(int Id)
        {
            _repositoryManager.employeeRepository.removeEmployee(Id);
            return "success";
        }

        public string UpdateEmployee(EmployeeDTO emp)
        {
            _repositoryManager.employeeRepository.editEmployee(emp);
            return "Record is Added Successfully";
        }
    }
}
