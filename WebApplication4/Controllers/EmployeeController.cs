using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            using (EMPcontext context = new EMPcontext())
            {
                var employees = context.Employees.ToList();
                return View(employees);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            using (EMPcontext context = new EMPcontext())
            {
                context.Employees.Add(model);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (EMPcontext context = new EMPcontext())
            {
                Employee employee = context.Employees.Where(x => x.Id == id).SingleOrDefault();
                return View(employee);
            }
        }

        [HttpPost]
        public ActionResult Edit(Employee model)
        {
            using (EMPcontext context = new EMPcontext())
            {
                Employee employee = context.Employees.Where(x => x.Id == model.Id).SingleOrDefault();

                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.PhoneNumber = model.PhoneNumber;
                employee.EmailAddress = model.EmailAddress;

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            using (EMPcontext context = new EMPcontext())
            {
                Employee employee = context.Employees.Where(x => x.Id == id).SingleOrDefault();
                return View(employee);
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (EMPcontext context = new EMPcontext())
            {
                Employee employee = context.Employees.Where(x => x.Id == id).SingleOrDefault();
                return View(employee);
            }
        }

        [HttpPost]
        public ActionResult Delete(Employee emp)
        {
            using (EMPcontext context = new EMPcontext())
            {
                Employee employee = context.Employees.Where(x => x.Id == emp.Id).SingleOrDefault();
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }

}