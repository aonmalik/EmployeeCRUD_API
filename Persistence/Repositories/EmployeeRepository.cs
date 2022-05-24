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

        public string editEmployee(int Id)
        {
            var em = _empDbContext.Employees.Where(x=>x.EmployeeId==Id).FirstOrDefault();
            em.EmployeeName = em.EmployeeName;
            em.EmployeeAddress = em.EmployeeAddress;
            em.EmployeeEmail = em.EmployeeEmail;
            em.EmployeeSalary = em.EmployeeSalary;
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
