using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAssignment.Models;

namespace WebApiAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> list = null;
        public EmployeeController()
        {
            if(list == null)
            {
                list = new List<Employee>()
                {
                    new Employee() {Id = 1, Name = "Vishal Sngh", Email = "vishal@gmail.com", Dept = "IT", Salary = "10000", Address = "Mumbai"},
                    new Employee() {Id = 2, Name = "Anshuman", Email = "Anshuman123@gmail.com", Dept = "HR", Salary = "10000", Address = "Lucknow"},
                    new Employee() {Id = 3, Name = "Raj", Email = "Raj34@gmail.com", Dept = "ACCT", Salary = "10000", Address = "Banglore"},
                    new Employee() {Id = 4, Name = "Shashwat", Email = "Shash243@gmail.com", Dept = "HR", Salary = "10000", Address = "Tamil nadu"}
                };
            }
        }

        [HttpGet]
        public List<Employee> Get()
        {
            return list;
        }

        [HttpGet]
        [Route("{id}")]
        public Employee Get(int id)
        {
            return list.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public void AddEmployee(Employee employee)
        {
            list.Add(employee);
        }

        [HttpPut]
        [Route("{id}")]
        public void EditEmployee(int id, Employee employee)
        {
            foreach(Employee emp in list)
            {
                if(emp.Id == id)
                {
                    emp.Email = employee.Email;
                    emp.Salary = employee.Salary;
                    emp.Address = employee.Address;
                    break;
                }
            }
        }

        [HttpDelete("{id}")]
        public void DeleteEmployee(int id)
        {
            var obj = list.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                list.Remove(obj);
            }
        }
    }   
}
