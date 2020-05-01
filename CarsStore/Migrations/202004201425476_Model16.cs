namespace CarsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model16 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Achats", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Achats", "Date", c => c.DateTime(nullable: false));
        }
    }
}
