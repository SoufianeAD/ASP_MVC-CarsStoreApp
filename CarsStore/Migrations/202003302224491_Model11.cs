namespace CarsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicules", "Pictures", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicules", "Pictures");
        }
    }
}
