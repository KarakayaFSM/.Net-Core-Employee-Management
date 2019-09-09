using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _Employees;
        public MockEmployeeRepository()
        {
            _Employees = new List<Employee>()
            {
                new Employee(){Id=1,Department=Dept.HR,Email="email1",Name="Ahmad"},
                new Employee(){Id=2,Department=Dept.IT,Email="email12",Name="Mehmet"},
                new Employee(){Id=3,Department=Dept.Payroll,Email="email3",Name="Kemal"}
            };
        }

        public Employee Add(Employee e)
        {
            e.Id = _Employees.Max(em => em.Id) + 1;
            _Employees.Add(e);
            return e;
        }

        public Employee Delete(int id)
        {
            Employee e = _Employees.FirstOrDefault(em => em.Id == id);
            if (e != null)
            {
                _Employees.Remove(e);
            }
            return e;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _Employees;
        }

        public Employee GetEmployee(int id)
        {
            return _Employees.FirstOrDefault(em => em.Id == id);
        }

        public Employee Update(Employee eNew)
        {
            Employee emp = _Employees.FirstOrDefault(em => em.Id == eNew.Id);
            if (emp != null)
            {
                emp.Name = eNew.Name;
                emp.Email = eNew.Email;
                emp.Department = eNew.Department;
            }
            return emp;
        }
    }
}