using EmployeeDetails.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace EmployeeDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpoyeeController : ControllerBase
    {
        private readonly EmployeeDbContext _httpClient;

        public EmpoyeeController(EmployeeDbContext httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeEntities>>> GetEmpoyees()
        {
            return await _httpClient.Employees.ToListAsync();
        }

        [HttpGet("{EmpId}")]
        public async Task<ActionResult<EmployeEntities>> GetEmployee(int EmpId)
        {
            var EmpoyeeData = await _httpClient.Employees.FindAsync(EmpId);

            if (EmpoyeeData == null)
            {
                return NotFound();
            }

            return EmpoyeeData;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeEntities>> PostEmployee(EmployeEntities Empoyee)
        {
            _httpClient.Employees.Add(Empoyee);
            await _httpClient.SaveChangesAsync();

            return Ok("Data Add Sucessfully");
        }

        [HttpPut("{EmpId}")]
        public async Task<IActionResult> PutEmployee(int EmpId, EmployeEntities Employee)
        {
            if (EmpId != Employee.EmployeEntitiesId)
            {
                return BadRequest();
            }

            _httpClient.Entry(Employee).State = EntityState.Modified;

            try
            {
                await _httpClient.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(EmpId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{EmpId}")]
        public async Task<IActionResult> DeleteEmployee(int EmpId)
        {
            var EmpoyeeData = await _httpClient.Employees.FindAsync(EmpId);
            if (EmpoyeeData == null)
            {
                return NotFound();
            }

            _httpClient.Employees.Remove(EmpoyeeData);
            await _httpClient.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _httpClient.Employees.Any(e => e.EmployeEntitiesId == id);
        }

    }
}


