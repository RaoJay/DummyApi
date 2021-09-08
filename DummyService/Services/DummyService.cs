using System;
using System.Threading.Tasks;

namespace DummyService.Services
{
    public class DummyService : IDummyService
    {
        public async  Task<string> Get()
        {
            return "Rachana Shivegowda";
        }
    }
}
