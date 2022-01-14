using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        //      Set up a private DbContext variable so you can perform CRUD operations on the database.
        private JobDbContext context;

        //      DONE Pass it into a EmployerController constructor.
        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        //  Complete Index() so that it passes all of the Employer objects in
        //  the database to the view. ch19...eager loading on 20.3
        //  public IActionResult Index()
        //  {
        //  List<Event> events = context.Events.ToList();
        //    return View(events);
            //  }

        {
            List<Employer> employerList = context.Employers.ToList();
            return View(employerList);
        }

        public IActionResult Add()
        //      Create an instance of AddEmployerViewModel inside of the Add() method
        //          and pass the instance into the View() return method.
       {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            return View(addEmployerViewModel);
        }

        //[HttpPost] ?????
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
            //  Add the appropriate code to ProcessAddEmployerForm() so that it will process form submissions
            //      and make sure that only valid Employer objects are being saved to the database. SEARCH ADDEVENTVIEWMODEL 15.4

        //public IActionResult Add(AddEventViewModel addEventViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Event newEvent = new Event
        //        {
        //            Name = addEventViewModel.Name,
        //            Description = addEventViewModel.Description,
        //            ContactEmail = addEventViewModel.ContactEmail
        //        };

        //        EventData.Add(newEvent);
        //          USE DBCONTEXT INSTEAD OF EVENTDATA... ch19?
        //        context.Events.Add(newEvent);
        //          context.SaveChanges(); <<pushes to DB

        //        return Redirect("/Events");
        //          }

        //          return View(addEventViewModel);
        //          }
        {
            if (ModelState.IsValid)
            {
                Employer employer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };

                context.Employers.Add(employer);
                context.SaveChanges();
                return Redirect("/Employer");
            }

            return View(addEmployerViewModel);
        }

        public IActionResult About(int id)
        //      About() currently returns a view with vital information about each employer such as their name and location.
        //      Make sure that the method is actually passing an Employer object to the view for display.
        {
            Employer employer = context.Employers.Find(id);
            return View(employer);
        }
       
    }
}

