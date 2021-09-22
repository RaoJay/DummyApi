using DummyServic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DummyWrapper
{
    public interface ICaller
    {
        Task<List<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int? id);
    }
}
