using DummyApi.Models;
using System.Collections.Generic;

namespace DummyServic
{
    internal class Responses
    {
        public object meta { get; set; }
        public List<Employee> data { get; set; }
    }
    internal class Response
    {
        public object meta { get; set; }
        public Employee data { get; set; }
    }
}