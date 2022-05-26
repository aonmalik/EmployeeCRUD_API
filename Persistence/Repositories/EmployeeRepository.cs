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
        private readonly EmployeeDbContext _empDbContext;

        public EmployeeRepository(EmployeeDbContext empDbContext)
        {
            _empDbContext = empDbContext;
        }

        public string addEmployee(Employee emp)
        {
            _empDbContext.Employees.Add(emp);
            _empDbContext.SaveChanges();
            return "success";
        }

        public string editEmployee(EmployeeDTO emp)
        {
            var em = _empDbContext.Employees.Where(x=>x.EmployeeId==emp.EmployeeId).FirstOrDefault();
            em.EmployeeName = emp.EmployeeName;
            em.EmployeePassword = emp.EmployeePassword;
            em.UserTypeId = emp.UserTypeId;
            em.EmployeeAddress = emp.EmployeeAddress;
            em.EmployeeEmail = emp.EmployeeEmail;
            _empDbContext.SaveChanges();
            return "Employee updated!";
        }

        public List<Employee> GetAllEmployees()
        {
           var empall= _empDbContext.Employees.ToList();
            return empall; 
        }

        public Employee getEmployeeById(int Id)
        {
           var m= _empDbContext.Employees.Where(x => x.EmployeeId == Id).FirstOrDefault();
            return m;
        }

        public Employee GetUserByIdandPassword(string username, string password)
        {
            var employee = _empDbContext.Employees.Where(x => x.EmployeeName == username && x.EmployeePassword == password).FirstOrDefault();
            return employee;
        }

        public string removeEmployee(int Id)
        {
          var em=  _empDbContext.Employees.Where(y=>y.EmployeeId==Id).FirstOrDefault();
            if (em != null)
            {
               _empDbContext.Employees.Remove(em);
                _empDbContext.SaveChanges();
                return "Successfully Removed";
            }
            else
            
             return "Record Not Found";
            
            
        }


    }
}
