using Microsoft.AspNetCore.Mvc;
using FirstCRUD.Models;

namespace FirstCRUD.Controllers;

public class EmployeeController : Controller
{
    private readonly ILogger<EmployeeController> _logger;
    public EmployeeController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View(Repository.AllEmployees);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        Repository.Create(employee);

        if(ModelState.IsValid)
            return View("Thanks", employee);
        else
            return View();
    }
    public IActionResult Update(string empname)
    {
        Employee? emp = (from employee in Repository.AllEmployees
        where employee.Name == empname
        select employee).FirstOrDefault();
        return View(emp);
    }

    [HttpPost]
    public IActionResult Update(Employee employee)
    {
        if(ModelState.IsValid){
        List<Employee> toUpdate  = (from emp in Repository.AllEmployees
                         where emp.Name == employee.Name
                         select emp).ToList<Employee>();
        
        foreach(var e in toUpdate){
            e.Age = employee.Age;
            e.Salary = employee.Salary;
            e.Department = employee.Department;
            e.Sex = employee.Sex;
        }

            return RedirectToAction("Index");
        }
        else {
            return View(employee);
        }

    }

    [HttpPost]
    public IActionResult Delete(string empname)
    {
        Console.Write(empname);
        Employee? toDelete = (from emp in Repository.AllEmployees
                              where emp.Name == empname
                              select emp).FirstOrDefault();
        Repository.Delete(toDelete);


        return RedirectToAction("Index");
    }

}