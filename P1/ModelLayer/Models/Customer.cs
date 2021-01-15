using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    
        public class Customer
        {


            [Key]
            public Guid CustomerId { get; set; } = Guid.NewGuid();

            [Required]
            [StringLength(15, ErrorMessage = "The firs name can only be 15 characters long")]
            [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
            [Display(Name = "First Name")]
            public string firstName { get; set; }

            [Required]
            [StringLength(15, ErrorMessage = "The firs name can only be 15 characters long")]
            [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
            [Display(Name = "Last Name")]
            public string lastName { get; set; }

        public string defaultStore { get; set; } = null;

            /// <summary>
            /// customer constructor with first and last name prams to be passed in
            /// </summary>
            /// <param name="fName"></param>
            /// <param name="lName"></param>
            public Customer(string fName, string lName)
            {
                this.firstName = fName;
                this.lastName = lName;
                //this.defaultStore = null;
            }
            /// <summary>
            /// empty customer constructor
            /// </summary>
            public Customer()
            {

            }


        }
    
}
