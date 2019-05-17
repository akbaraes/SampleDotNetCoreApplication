using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DALLayer;
using DALLayer.Domain;
using ServiceLayer.EmployeeService;
using CodeSnippetSample.Models;
using AutoMapper;

namespace CodeSnippetSample.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: Employees
        public ActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees().Select(x => _mapper.Map<EmployeeModel>(x)).ToList();
            return View(employees);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var employee = _mapper.Map<EmployeeModel>(_employeeService.GetEmployeeById(id));
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.AddEmmployee(_mapper.Map<Employee>(employee));
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var employee = _mapper.Map<EmployeeModel>(_employeeService.GetEmployeeById(id));
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeModel employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var data = _employeeService.GetEmployeeById(id);
                    var emp = _mapper.Map<EmployeeModel, Employee>(employee, data);

                    _employeeService.UpdateEmployee(emp);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var employee = _mapper.Map<EmployeeModel>(_employeeService.GetEmployeeById(id));
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            _employeeService.DeleteEmploye(employee);
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _employeeService.GetEmployeeById(id) != null;
        }
    }
}
