namespace MarsRover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orientation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Positions", "Orientation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Positions", "Orientation");
        }
    }
}
