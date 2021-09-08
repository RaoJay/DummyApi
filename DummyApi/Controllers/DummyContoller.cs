using DummyServic;
using System.Threading.Tasks;
using System.Web.Http;

namespace DummyApi.Controllers
{
    [Route("api/Dummy")]
    public class DummyController : ApiController
    {
        private readonly IDummyServic _dummyServic;
        public DummyController(IDummyServic dummyServic)
        {
            _dummyServic = dummyServic;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get() {

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

        [HttpGet]
        public async Task<IHttpActionResult> Get(int? id) {
            try
            {
                if (id != null) {
                    var employee = await _dummyServic.GetEmployee(id).ConfigureAwait(false);
                    if (employee != null)
                    {
                        return Ok(employee);
                    }
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