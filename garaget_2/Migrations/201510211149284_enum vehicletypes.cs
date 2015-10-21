
namespace garaget_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enumvehicletypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "VehicleType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "VehicleType", c => c.String());
        }
    }
}
