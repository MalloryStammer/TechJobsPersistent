using System;
using System.ComponentModel.DataAnnotations;

namespace TechJobsPersistent.ViewModels
{
    public class AddEmployerViewModel
    {
        //public int EmployerId { get; set }

        [Required(ErrorMessage = "Employer is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Employer location is required")]
        public string Location { get; set; }

    }
}
