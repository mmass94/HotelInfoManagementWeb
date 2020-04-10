using HIMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HIMS.Context
{

 
    public class ModelsContext : DbContext
    {

        public DbSet<ReservationDashboard> reservations { get; set; }
        public DbSet<CEO> ceo { get; set; }
        public DbSet<Dashboard> dashboards { get; set; }
        public DbSet<Adminstration> userAccount { get; set; }
        public ModelsContext() : base("Name=HotelString") { }

       

    }



}