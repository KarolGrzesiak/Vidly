namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDeliquentOnPaymentToCustomersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsDeliquentOnPayment", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsDeliquentOnPayment");
        }
    }
}
