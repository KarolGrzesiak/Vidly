namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAmountOfRentedMoviesToCustomersTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "AmountOfRentedMovies", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "AmountOfRentedMovies");
        }
    }
}
