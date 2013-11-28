namespace MarsRover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Positions", "RoverId", "dbo.Rovers");
            DropForeignKey("dbo.Coordinates", "PositionId", "dbo.Positions");
            DropIndex("dbo.Positions", new[] { "RoverId" });
            DropIndex("dbo.Coordinates", new[] { "PositionId" });
            AddColumn("dbo.Positions", "Step", c => c.Int(nullable: false));
            AlterColumn("dbo.Rovers", "RoverID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Positions", "RoverID", c => c.Int(nullable: false));
            AlterColumn("dbo.Positions", "PositionID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Coordinates", "PositionID", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Rovers", new[] { "RoverId" });
            AddPrimaryKey("dbo.Rovers", "RoverID");
            DropPrimaryKey("dbo.Positions", new[] { "RoverId" });
            AddPrimaryKey("dbo.Positions", "PositionID");
            DropPrimaryKey("dbo.Coordinates", new[] { "PositionId" });
            AddPrimaryKey("dbo.Coordinates", "PositionID");
            AddForeignKey("dbo.Positions", "RoverID", "dbo.Rovers", "RoverID", cascadeDelete: true);
            AddForeignKey("dbo.Coordinates", "PositionID", "dbo.Positions", "PositionID");
            CreateIndex("dbo.Positions", "RoverID");
            CreateIndex("dbo.Coordinates", "PositionID");
            DropColumn("dbo.Rovers", "Step");
            DropColumn("dbo.Coordinates", "CoordinatesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coordinates", "CoordinatesId", c => c.Int(nullable: false));
            AddColumn("dbo.Rovers", "Step", c => c.Int(nullable: false));
            DropIndex("dbo.Coordinates", new[] { "PositionID" });
            DropIndex("dbo.Positions", new[] { "RoverID" });
            DropForeignKey("dbo.Coordinates", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.Positions", "RoverID", "dbo.Rovers");
            DropPrimaryKey("dbo.Coordinates", new[] { "PositionID" });
            AddPrimaryKey("dbo.Coordinates", "PositionId");
            DropPrimaryKey("dbo.Positions", new[] { "PositionID" });
            AddPrimaryKey("dbo.Positions", "RoverId");
            DropPrimaryKey("dbo.Rovers", new[] { "RoverID" });
            AddPrimaryKey("dbo.Rovers", "RoverId");
            AlterColumn("dbo.Coordinates", "PositionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Positions", "PositionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Positions", "RoverId", c => c.Int(nullable: false));
            AlterColumn("dbo.Rovers", "RoverId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Positions", "Step");
            CreateIndex("dbo.Coordinates", "PositionId");
            CreateIndex("dbo.Positions", "RoverId");
            AddForeignKey("dbo.Coordinates", "PositionId", "dbo.Positions", "RoverId");
            AddForeignKey("dbo.Positions", "RoverId", "dbo.Rovers", "RoverId");
        }
    }
}
