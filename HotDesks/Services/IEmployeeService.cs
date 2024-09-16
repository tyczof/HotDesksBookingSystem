using HotDesks.DTOs;
using HotDesks.Models;

namespace HotDesks.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        void AddEmployee(EmployeeDTO employeeDto);
        void UpdateEmployee(int id, EmployeeDTO employeeDto);
        void RemoveEmployee(int id);
    }

}
