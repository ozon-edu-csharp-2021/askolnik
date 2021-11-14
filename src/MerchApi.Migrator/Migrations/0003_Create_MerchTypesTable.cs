using FluentMigrator;

namespace MerchApi.Migrator.Migrations
{
    [Migration(3)]
    public class MerchTypesTable : Migration
    {
        public override void Up()
        {
            Create
             .Table("merch_types")
             .WithColumn("id").AsInt32().PrimaryKey()
             .WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_types");
        }
    }
}