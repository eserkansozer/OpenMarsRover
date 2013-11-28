namespace MarsRover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Positions", "RoverID", "dbo.Rovers");
            DropForeignKey("dbo.Coordinates", "PositionID", "dbo.Positions");
            DropIndex("dbo.Positions", new[] { "RoverID" });
            DropIndex("dbo.Coordinates", new[] { "PositionID" });
            DropPrimaryKey("dbo.Positions", new[] { "PositionID" });
            AddPrimaryKey("dbo.Positions", "RoverID");
            AddForeignKey("dbo.Positions", "RoverID", "dbo.Rovers", "RoverID");
            AddForeignKey("dbo.Coordinates", "PositionID", "dbo.Positions", "RoverID");
            CreateIndex("dbo.Positions", "RoverID");
            CreateIndex("dbo.Coordinates", "PositionID");
            DropColumn("dbo.Positions", "PositionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Positions", "PositionID", c => c.Int(nullable: false, identity: true));
            DropIndex("dbo.Coordinates", new[] { "PositionID" });
            DropIndex("dbo.Positions", new[] { "RoverID" });
            DropForeignKey("dbo.Coordinates", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.Positions", "RoverID", "dbo.Rovers");
            DropPrimaryKey("dbo.Positions", new[] { "RoverID" });
            AddPrimaryKey("dbo.Positions", "PositionID");
            CreateIndex("dbo.Coordinates", "PositionID");
            CreateIndex("dbo.Positions", "RoverID");
            AddForeignKey("dbo.Coordinates", "PositionID", "dbo.Positions", "PositionID");
            AddForeignKey("dbo.Positions", "RoverID", "dbo.Rovers", "RoverID", cascadeDelete: true);
        }
    }
}
