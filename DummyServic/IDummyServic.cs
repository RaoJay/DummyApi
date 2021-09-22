using DummyServic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DummyServic
{
    public interface IDummyServic
    {
        Task<List<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int? id);
    }
}
