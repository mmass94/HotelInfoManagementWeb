using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HIMS.Models
{
    public class CEO
    {


        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "First Name is required ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }




    }
}