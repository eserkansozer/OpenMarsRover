namespace MarsRoverDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        RoverID = c.Int(nullable: false),
                        Step = c.Int(nullable: false),
                        X = c.Int(nullable: false),
                        Y = c.Int(nullable: false),
                        Orientation = c.String(),
                    })
                .PrimaryKey(t => t.PositionID)
                .ForeignKey("dbo.Rovers", t => t.RoverID, cascadeDelete: true)
                .Index(t => t.RoverID);
            
            CreateTable(
                "dbo.Rovers",
                c => new
                    {
                        RoverID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.RoverID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "RoverID", "dbo.Rovers");
            DropIndex("dbo.Positions", new[] { "RoverID" });
            DropTable("dbo.Rovers");
            DropTable("dbo.Positions");
        }
    }
}
