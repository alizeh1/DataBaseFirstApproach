using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDFA_EF.Models;
using WebApiDFA_EF.Services;

namespace WebApiDFA_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService service)
        {
            _employeeService = service;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var EmployeeRequestBody = _employeeService.GetEmployeesList();
                if (EmployeeRequestBody == null) return NotFound();
                return Ok(EmployeeRequestBody);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveEmployees([FromBody] EmployeeRequestBody requestBody)
        {
            try
            {
                var model = _employeeService.SaveEmployee(requestBody);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        //[HttpDelete]
        //[Route("[action]")]
        //public IActionResult DeleteEmployee(int id)
        //{
        //    try
        //    {
        //        var model = _employeeService.DeleteEmployee(id);
        //        return Ok(model);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}


    }
}
