namespace HIMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCustomPtternToAdminstrationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adminstrations", "CustomID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adminstrations", "CustomID");
        }
    }
}
