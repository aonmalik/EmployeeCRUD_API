using Contracts;
using Domain;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public string addEmployee(Employee emp)
        {
            _employeeDbContext.Employees.Add(emp);
            _employeeDbContext.SaveChanges();
            return "success";
        }

        public string editEmployee(Employee emp)
        {
            var em = _employeeDbContext.Employees.Where(x=>x.EmployeeId==emp.EmployeeId).FirstOrDefault();
            em.EmployeeName = emp.EmployeeName;
            em.EmployeePassword = emp.EmployeePassword;
            em.UserTypeId = emp.UserTypeId;
            em.EmployeeAddress = emp.EmployeeAddress;
            em.EmployeeEmail = emp.EmployeeEmail;
            _employeeDbContext.SaveChanges();
            return "Employee updated!";
        }

        public List<Employee> GetAllEmployees()
        {
           var empall= _employeeDbContext.Employees.ToList();
            return empall; 
        }

        public Employee getEmployeeById(int Id)
        {
           var m= _employeeDbContext.Employees.Where(x => x.EmployeeId == Id).FirstOrDefault();
            return m;
        }

        public Employee GetUserByIdandPassword(string username, string password)
        {
            var employee = _employeeDbContext.Employees.Where(x => x.EmployeeName == username && x.EmployeePassword == password).FirstOrDefault();
            return employee;
        }

        public string removeEmployee(int Id)
        {
          var em=  _employeeDbContext.Employees.Where(y=>y.EmployeeId==Id).FirstOrDefault();
            if (em != null)
            {
               _employeeDbContext.Employees.Remove(em);
                _employeeDbContext.SaveChanges();
                return "Successfully Removed";
            }
            else
            
             return "Record Not Found";
            
            
        }


    }
}
