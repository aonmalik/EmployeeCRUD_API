using Domain.Repositories;
using Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
   public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IEmployeeService> _employeeService;
        public ServiceManager(IRepositoryManager employeeRepository)
        {
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(employeeRepository));

        }

        public IEmployeeService employeeService =>_employeeService.Value;
    }
}
