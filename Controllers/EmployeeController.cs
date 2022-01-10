using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Models;

namespace webApi.Controllers
{
    [ApiController]
    [Route("v1/employees")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Employee>>> GetEmployees([FromServices] DataContext context)
        {
            var employees = await context.Employees.ToListAsync();
            return employees;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Employee>> Post(
            [FromServices] DataContext context,
            [FromBody] Employee model)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}