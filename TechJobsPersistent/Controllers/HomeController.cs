using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext context;

        public HomeController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            //In AddJob() pass an instance of AddJobViewModel to the view.
            //n the AddJob() method, update the AddJobViewModel object so that you
            //pass all of the Skill objects in the database to the constructor
            List<Employer> employers = context.Employers.ToList();
            List<Skill> skills = context.Skills.ToList();

            AddJobViewModel addJobViewModel = new AddJobViewModel(employers, skills);
            return View(addJobViewModel);
        }


        //In ProcessAddJobForm(), you need to take in an instance of AddJobViewModel
        //and make sure that any validation conditions you want to add are met
        //before creating a new Job object and saving it to the database
        //In the ProcessAddJobForm() method, pass in a new parameter: an array of strings called selectedSkills

       // you want to set up a loop to go through each item in selectedSkills.
       // right after you create a new Job object and before you add that Job object to the database.
       //Inside the loop, you will create a new JobSkill object with the newly-created Job object.
       //You will also need to parse each item in selectedSkills as an integer to use for SkillId.
       //Add each new JobSkill object to the DbContext object,
       //but do not add an additional call to SaveChanges() inside the loop!
       //One call at the end of the method is enough to get the updated info to the database.

        public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, string[] selectedSkills)
        {
            if (ModelState.IsValid)
            {
                Job job = new Job
                {
                    Name = addJobViewModel.Name,
                    EmployerId = addJobViewModel.EmployerId,
                };

                foreach (string skill in selectedSkills)
                {
                    JobSkill jobSkill = new JobSkill
                    {
                        Job = job,
                        JobId= job.Id,
                        SkillId = Int32.Parse(skill)
                    };

                    context.JobSkills.Add(jobSkill);
                }


                context.Jobs.Add(job);
                context.SaveChanges(); 
                return Redirect("Index");
            }

            return RedirectToAction("AddJob", addJobViewModel);
            }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs
                .Include(j => j.Employer)
                .Single(j => j.Id == id);

            List<JobSkill> jobSkills = context.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}
