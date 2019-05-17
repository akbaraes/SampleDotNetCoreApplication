using DALLayer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.EmployeeService
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        int AddEmmployee(Employee employee);

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="employee"></param>
        void UpdateEmployee(Employee employee);


        /// <summary>
        /// Get Employee by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetEmployeeById(int id);

        /// <summary>
        /// Get All Employees
        /// </summary>
        /// <returns></returns>
        List<Employee> GetAllEmployees();


        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="employee"></param>
        void DeleteEmploye(Employee employee);
    }
}
