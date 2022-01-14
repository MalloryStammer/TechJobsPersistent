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
    {
        [Required(ErrorMessage = "Job name is required.")]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "Womp Womp") ]
        public string Name { get; set; }

        public int EmployerId { get; set; }

        public List<SelectListItem> Employers { get; set; }

        public AddJobViewModel() { }
        public AddJobViewModel(List<Employer> listPotentialEmployers)
        {
            Employers = new List<SelectListItem>();

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