using HotDesks.DTOs;
using HotDesks.Models;
using Microsoft.EntityFrameworkCore;

namespace HotDesks.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HotDeskContext _context;

        public EmployeeService(HotDeskContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.Include(e => e.Reservations).ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Include(e => e.Reservations).FirstOrDefault(e => e.Id == id);
        }

        public void AddEmployee(EmployeeDTO employeeDto)
        {
            var employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email
            };
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(int id, EmployeeDTO employeeDto)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                employee.FirstName = employeeDto.FirstName;
                employee.LastName = employeeDto.LastName;
                employee.Email = employeeDto.Email;
                _context.SaveChanges();
            }
        }

        public void RemoveEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
    }

}
