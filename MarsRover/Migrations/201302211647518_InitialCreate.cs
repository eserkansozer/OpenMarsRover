namespace MarsRover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rovers",
                c => new
                    {
                        RoverId = c.Int(nullable: false, identity: true),
                        Step = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoverId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        RoverId = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoverId)
                .ForeignKey("dbo.Rovers", t => t.RoverId)
                .Index(t => t.RoverId);
            
            CreateTable(
                "dbo.Coordinates",
                c => new
                    {
                        PositionId = c.Int(nullable: false),
                        CoordinatesId = c.Int(nullable: false),
                        X = c.Int(nullable: false),
                        Y = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PositionId)
                .ForeignKey("dbo.Positions", t => t.PositionId)
                .Index(t => t.PositionId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Coordinates", new[] { "PositionId" });
            DropIndex("dbo.Positions", new[] { "RoverId" });
            DropForeignKey("dbo.Coordinates", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Positions", "RoverId", "dbo.Rovers");
            DropTable("dbo.Coordinates");
            DropTable("dbo.Positions");
            DropTable("dbo.Rovers");
        }
    }
}
