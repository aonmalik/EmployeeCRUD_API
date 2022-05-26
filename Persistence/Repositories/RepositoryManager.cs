using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
   public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IEmployeeRepository> _repositorymanager;
        public RepositoryManager(EmployeeDbContext empDbContext)
        {
            _repositorymanager = new Lazy<IEmployeeRepository>(() =>new EmployeeRepository(empDbContext));

        }

        public IEmployeeRepository employeeRepository => _repositorymanager.Value;
    }
}
