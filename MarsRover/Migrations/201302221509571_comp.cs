namespace MarsRover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coordinates", "PositionID", "dbo.Positions");
            DropIndex("dbo.Coordinates", new[] { "PositionID" });
            AddColumn("dbo.Positions", "Coordinates_X", c => c.Int(nullable: false));
            AddColumn("dbo.Positions", "Coordinates_Y", c => c.Int(nullable: false));
            DropTable("dbo.Coordinates");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Coordinates",
                c => new
                    {
                        PositionID = c.Int(nullable: false),
                        X = c.Int(nullable: false),
                        Y = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PositionID);
            
            DropColumn("dbo.Positions", "Coordinates_Y");
            DropColumn("dbo.Positions", "Coordinates_X");
            CreateIndex("dbo.Coordinates", "PositionID");
            AddForeignKey("dbo.Coordinates", "PositionID", "dbo.Positions", "RoverID");
        }
    }
}
