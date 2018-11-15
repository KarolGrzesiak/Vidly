namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddNumberAvailableColumnToMoviesTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
            Sql("update movies set NumberAvailable = NumberInStock");
        }

        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
