using DummyServic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace DummyApi.Controllers
{
    [Route("api/Dummy")]
    public class DummyController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private readonly IDummyServic _dummyServic;
        public DummyController(IDummyServic dummyServic)
        {
            _dummyServic = dummyServic;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? id) {
            return await ((id == null) ? GetEmployees() : GetEmployee(id));
        }

    
        private async Task<IActionResult> GetEmployees() {

            try
            {
                var employees = await _dummyServic.GetEmployees().ConfigureAwait(false);
                if (employees != null) {
                    return Ok(employees);
                }
            }
            catch (System.Exception ex)
            {
                //log it
                return BadRequest(ex.Message);
            }
            return Ok("Invalid Response");
        }

      
        private async Task<IActionResult> GetEmployee(int? id) {
            try
            {
   
                    var employee = await _dummyServic.GetEmployee(id).ConfigureAwait(false);
                    if (employee != null)
                    {
                        return Ok(employee);
                    }

            }
            catch (System.Exception ex)
            {
                //log it
                return BadRequest(ex.Message);
            }
            return Ok("No data found");
        }
    }
}