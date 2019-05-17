using System;
using System.Collections.Generic;
using System.Text;
using DALLayer;
using DALLayer.Domain;
using DALLayer.Repositoy;
using System.Linq;

namespace ServiceLayer.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int AddEmmployee(Employee employee)
        {
            _employeeRepository.Insert(employee);
            return employee.Id;
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="employee"></param>
        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.Update(employee);
        }


        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="employee"></param>
        public void DeleteEmploye(Employee employee)
        {
            _employeeRepository.Delete(employee);
        }


        /// <summary>
        /// Get Employee by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetEmployeeById(int id)
        {
           return _employeeRepository.GetById(id);
        }

        /// <summary>
        /// Get All Employees
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployees()
        {
            var query = (from cr in _employeeRepository.Table
                         select cr);

            return query.ToList();
        }

       
    }
}
