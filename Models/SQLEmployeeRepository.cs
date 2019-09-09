using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {

        private readonly AppDbContext context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }


        public Employee Add(Employee e)
        {
            context.Employees.Add(e);
            context.SaveChanges();
            return e;
        }

        public Employee Delete(int id)
        {
           Employee em = context.Employees.Find(id);
           if(em != null)
            {
                context.Employees.Remove(em);
                context.SaveChanges();
            }
            return em;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return context.Employees;
        }

        public Employee GetEmployee(int id)
        {
            return context.Employees.Find(id);
        }

        public Employee Update(Employee e)
        {
            var emp = context.Employees.Attach(e);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return e;
        }
    }
}
