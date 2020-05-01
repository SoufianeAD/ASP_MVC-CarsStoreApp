namespace CarsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model15 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Commentaires", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Commentaires", "Date", c => c.DateTime(nullable: false));
        }
    }
}
