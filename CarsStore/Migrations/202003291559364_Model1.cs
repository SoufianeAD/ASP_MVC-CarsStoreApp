namespace CarsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Client_Id = c.Int(),
                        Vehicule_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Vehicules", t => t.Vehicule_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Vehicule_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        IdAccount = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        Model = c.String(),
                        Power = c.String(),
                        Engine = c.String(),
                        Price = c.Double(nullable: false),
                        MainPicture = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Commentaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentText = c.String(),
                        Date = c.DateTime(nullable: false),
                        Client_Id = c.Int(),
                        Publication_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Publications", t => t.Publication_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Publication_Id);
            
            CreateTable(
                "dbo.Publications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublishDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        Vehicule_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicules", t => t.Vehicule_Id)
                .Index(t => t.Vehicule_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commentaires", "Publication_Id", "dbo.Publications");
            DropForeignKey("dbo.Publications", "Vehicule_Id", "dbo.Vehicules");
            DropForeignKey("dbo.Commentaires", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Achats", "Vehicule_Id", "dbo.Vehicules");
            DropForeignKey("dbo.Achats", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Publications", new[] { "Vehicule_Id" });
            DropIndex("dbo.Commentaires", new[] { "Publication_Id" });
            DropIndex("dbo.Commentaires", new[] { "Client_Id" });
            DropIndex("dbo.Achats", new[] { "Vehicule_Id" });
            DropIndex("dbo.Achats", new[] { "Client_Id" });
            DropTable("dbo.Publications");
            DropTable("dbo.Commentaires");
            DropTable("dbo.Vehicules");
            DropTable("dbo.Clients");
            DropTable("dbo.Achats");
        }
    }
}
