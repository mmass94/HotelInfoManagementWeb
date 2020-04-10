using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace HIMS.Models
{
    public class Adminstration
    {

        public Adminstration()
        {
           this.SetCoustomPattern();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set ;}

        [DisplayName("Admin ID")]
        public string CustomPattern { get; set; }

       public void SetCoustomPattern()
        {
            this.CustomPattern = "Ad-"+ID.ToString()+"-"+ DateTime.Now.ToString("MM-yy");
        }

        public string CustomID { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required ")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is required ")]
        public string LastName { get; set; }

        //[Remote("CheckForDuplication", "Validation")]
        [DisplayName("Username")]
        [Required(ErrorMessage = "Username is required ")]
        public string UserName  { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Compare("Password",ErrorMessage = "Please Confirm Your Password correctly ")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }



    }
}