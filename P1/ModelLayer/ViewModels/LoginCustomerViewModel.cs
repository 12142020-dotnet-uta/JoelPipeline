using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer.ViewModels
{
    public class LoginCustomerViewModel
    {

        [Required]
        [StringLength(15, ErrorMessage = "The firs name can only be 15 characters long")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "The firs name can only be 15 characters long")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Display(Name = "Last Name")]
        [DataType(DataType.Password)]
        public string lastName { get; set; }
    }
}
