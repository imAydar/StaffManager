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
        
        /// <summary>
        /// Gets collection of employees who works in department.
        /// </summary>
        /// <param name="departmentId">Deparment id.</param>
        /// <returns>Collection of employees.</returns>
        [HttpGet("{departmentId}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetByDepartmentId(int departmentId)
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
        
        /// <summary>
        /// Create employee.
        /// </summary>
        /// <param name="employee">Employee to create.</param>
        [HttpPost]
        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            try
            {
                var result = await service.CreateAsync(employee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(PostgreCustomExceptionHandler.Handle(ex));
            }
        }
        
        /// <summary>
        /// Update employee.
        /// </summary>
        /// <param name="employee">Employee to update.</param>
        [HttpPut]
        public async Task<ActionResult<Employee>> Update(Employee employee)
        {
            try
            {
                var result = await service.UpdateAsync(employee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(PostgreCustomExceptionHandler.Handle(ex));
            }
        }
        
        /// <summary>
        /// Delete employee.
        /// </summary>
        /// <param name="employee">Employee to delete.</param>
        [HttpDelete]
        public async Task<ActionResult<Employee>> Delete(Employee employee)
        {
            try
            {
                var result = await service.DeleteAsync(employee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message ?? ex.Message);
            }
        }
    }
}
