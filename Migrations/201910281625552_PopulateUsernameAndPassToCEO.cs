namespace HIMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUsernameAndPassToCEO : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CEOs VALUES('MOHAMMAD','AL MASALMA','ce.m.mas.94','m.mass1994')");
        }
        
        public override void Down()
        {
        }
    }
}
