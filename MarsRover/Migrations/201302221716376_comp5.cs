namespace MarsRover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comp5 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Positions", name: "Coordinates_X", newName: "X");
            RenameColumn(table: "dbo.Positions", name: "Coordinates_Y", newName: "Y");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Positions", name: "Y", newName: "Coordinates_Y");
            RenameColumn(table: "dbo.Positions", name: "X", newName: "Coordinates_X");
        }
    }
}
