namespace CarsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Picture");
        }
    }
}
