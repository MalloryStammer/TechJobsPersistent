using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    //    Create a new ViewModel called AddJobViewModel.
    //    You will need properties for the job’s name,
    //    the selected employer’s ID,
    //    and a list of all employers as SelectListItem.>>


    //Add a property for a list of each Skill object in the database.
    //Previously, in an AddJobViewModel constructor,
    //you probably set up a SelectListItem list of Employer information.
    //Pass another parameter of a list of Skill objects.
    //Set the List<Skill> property equal to the parameter you have just passed in.


    {
        [Required(ErrorMessage = "Job name is required.")]
        [StringLength(100, ErrorMessage = "Womp Womp")]
        public string Name { get; set; }
        public int EmployerId { get; set; }
        public List<SelectListItem> Employers { get; set; }

        //[Required(ErrorMessage = "Skill is required.")]
        public List <Skill> Skills { get; set; }

        public AddJobViewModel() { }
        public AddJobViewModel(List<Employer> listPotentialEmployers, List<Skill> skills)
        {
            Employers = new List<SelectListItem>();
            Skills = skills;

            foreach (Employer employer in listPotentialEmployers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                });
            }
        }
    }
}