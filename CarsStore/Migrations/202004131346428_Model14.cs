namespace CarsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model14 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Publications", "PublishDate");
            DropColumn("dbo.Publications", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Publications", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Publications", "PublishDate", c => c.DateTime(nullable: false));
        }
    }
}
