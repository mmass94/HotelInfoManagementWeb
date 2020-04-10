namespace HIMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CEOs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Dashboards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        First_Name = c.String(nullable: false),
                        Last_Name = c.String(nullable: false),
                        Birth_Date = c.DateTime(nullable: false),
                        Phone_Number = c.Long(nullable: false),
                        Room_Number = c.Int(nullable: false),
                        Check_In_Date = c.DateTime(nullable: false),
                        Check_Out_Date = c.DateTime(nullable: false),
                        Total_Payment_Due = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Advanced_Payment = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReservationDashboards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Room_type = c.String(nullable: false),
                        First_Name = c.String(nullable: false),
                        Last_Name = c.String(nullable: false),
                        Birth_Date = c.DateTime(nullable: false),
                        Email = c.String(),
                        Phone_Number = c.Long(nullable: false),
                        Check_In_Date = c.DateTime(nullable: false),
                        Check_Out_Date = c.DateTime(nullable: false),
                        Total_Payment_Due = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Adminstrations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomPattern = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Adminstrations");
            DropTable("dbo.ReservationDashboards");
            DropTable("dbo.Dashboards");
            DropTable("dbo.CEOs");
        }
    }
}
