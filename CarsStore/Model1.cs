namespace CarsStore
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CarsStore.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Model1()
            : base("name=Model1")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Vehicule> Vehicules { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Commentaire> Commentaires { get; set; }
        public virtual DbSet<Achat> Achats { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}