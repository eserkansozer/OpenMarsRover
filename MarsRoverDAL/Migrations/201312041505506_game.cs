namespace MarsRoverDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class game : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameID);
            
            AddColumn("dbo.Rovers", "GameID", c => c.Int(nullable: false));
            AddColumn("dbo.Rovers", "Mileage", c => c.Int(nullable: false));
            CreateIndex("dbo.Rovers", "GameID");
            AddForeignKey("dbo.Rovers", "GameID", "dbo.Games", "GameID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rovers", "GameID", "dbo.Games");
            DropIndex("dbo.Rovers", new[] { "GameID" });
            DropColumn("dbo.Rovers", "Mileage");
            DropColumn("dbo.Rovers", "GameID");
            DropTable("dbo.Games");
        }
    }
}
