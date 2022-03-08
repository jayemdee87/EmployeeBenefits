using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeBenefitsAPICore.Models;
using EmployeeBenefitsAPICore.Interfaces;
using EmployeeBenefitsAPICore.Models.Dtos;
using AutoMapper;

namespace EmployeeBenefitsAPICore.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [Route("GetEmployees")]
        [HttpGet]
        public List<EmployeeDto> GetEmployees()
        {
            return _mapper.Map<List<EmployeeDto>>(_employeeService.GetEmployees());
        }

        [Route("GetEmployee/{id}")]
        [HttpGet]
        public EmployeeDto GetEmployee(long id)
        {
            return _mapper.Map<EmployeeDto>(_employeeService.GetEmployee(id));
        }

        [Route("AddOrUpdateEmployee")]
        [HttpPost]
        public EmployeeDto AddOrUpdateEmployee(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);

            if (employee.Id == 0)
            {
                employeeDto = _mapper.Map<EmployeeDto>(_employeeService.AddEmployee(employee));
            }
            else
            {
                employeeDto = _mapper.Map<EmployeeDto>(_employeeService.UpdateEmployee(employee));
            }

            return employeeDto;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
