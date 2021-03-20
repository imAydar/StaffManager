using Microsoft.AspNetCore.Mvc;
using StaffManager.Core;
using StaffManager.Core.Services;
using StaffManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManager.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService service;
        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpGet("{departmentId}")]
        public async Task<IActionResult> GetByDepartmentId(int departmentId)
        {
            try
            {
                return Ok(await service.GetByDepartmentId(departmentId));
            }
            catch (Exception ex)
            {
                return BadRequest(PostgreCustomExceptionHandler.Handle(ex));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee entity)
        {
            try
            {
                var result = await service.CreateAsync(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(PostgreCustomExceptionHandler.Handle(ex));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Employee entity)
        {
            try
            {
                var result = await service.UpdateAsync(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(PostgreCustomExceptionHandler.Handle(ex));
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Employee entity)
        {
            try
            {
                var result = await service.DeleteAsync(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message ?? ex.Message);
            }
        }
    }
}
