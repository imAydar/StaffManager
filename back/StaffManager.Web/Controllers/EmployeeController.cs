using Microsoft.AspNetCore.Mvc;
using StaffManager.Core;
using StaffManager.Core.Services;
using StaffManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StaffManager.Infrastructure.Models;

namespace StaffManager.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService service;
        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }
        
        /// <summary>
        /// Gets collection of EmployeeDtos who works in department.
        /// </summary>
        /// <param name="departmentId">Deparment id.</param>
        /// <returns>Collection of EmployeeDtos.</returns>
        [HttpGet("{departmentId}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetByDepartmentId(int departmentId)
        {
            try
            {
                return Ok(await service.GetByDepartmentId(departmentId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        /// <summary>
        /// Create EmployeeDto.
        /// </summary>
        /// <param name="EmployeeDto">EmployeeDto to create.</param>
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> Create(EmployeeDto EmployeeDto)
        {
            try
            {
                var result = await service.CreateAsync(EmployeeDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        /// <summary>
        /// Update EmployeeDto.
        /// </summary>
        /// <param name="EmployeeDto">EmployeeDto to update.</param>
        [HttpPut]
        public async Task<ActionResult<EmployeeDto>> Update(EmployeeDto EmployeeDto)
        {
            try
            {
                var result = await service.UpdateAsync(EmployeeDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        /// <summary>
        /// Delete EmployeeDto.
        /// </summary>
        /// <param name="EmployeeDto">EmployeeDto to delete.</param>
        [HttpDelete]
        public async Task<ActionResult<EmployeeDto>> Delete(EmployeeDto EmployeeDto)
        {
            try
            {
                var result = await service.DeleteAsync(EmployeeDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
