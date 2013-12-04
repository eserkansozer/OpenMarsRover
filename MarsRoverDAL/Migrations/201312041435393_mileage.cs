namespace MarsRoverDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mileage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rovers", "Mileage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rovers", "Mileage", c => c.Int(nullable: false));
        }
    }
}
