using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace HIMS.Models
{
    public class Dashboard
    {
        [Key]
        [DisplayName("Reservation ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required ")]
        public string First_Name { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is required ")]
        public string Last_Name { get; set; }

        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birth_Date { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Phone Number is required ")]
        public long Phone_Number { get; set; }

        [DisplayName("Room Number")]
        [Required(ErrorMessage = "Room Number is required ")]
        public int Room_Number { get; set; }

        [DisplayName("Check in Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Check_In_Date { get; set; }

        [DisplayName("Check out Date ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Check_Out_Date { get; set; }

        [DisplayName("Total Payment Due")]
        public Decimal Total_Payment_Due{ get; set; }

        [DisplayName("Advanced Payment")]
        [Required(ErrorMessage = "Advanced Payment is required")]
        public Decimal Advanced_Payment { get; set; }

    }
}