namespace MarsRover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comp1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Positions", "RoverID", "dbo.Rovers");
            DropIndex("dbo.Positions", new[] { "RoverID" });
            AddColumn("dbo.Positions", "PositionID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Positions", new[] { "RoverID" });
            AddPrimaryKey("dbo.Positions", "PositionID");
            AddForeignKey("dbo.Positions", "RoverID", "dbo.Rovers", "RoverID", cascadeDelete: true);
            CreateIndex("dbo.Positions", "RoverID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Positions", new[] { "RoverID" });
            DropForeignKey("dbo.Positions", "RoverID", "dbo.Rovers");
            DropPrimaryKey("dbo.Positions", new[] { "PositionID" });
            AddPrimaryKey("dbo.Positions", "RoverID");
            DropColumn("dbo.Positions", "PositionID");
            CreateIndex("dbo.Positions", "RoverID");
            AddForeignKey("dbo.Positions", "RoverID", "dbo.Rovers", "RoverID");
        }
    }
}
