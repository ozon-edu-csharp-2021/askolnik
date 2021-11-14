using FluentMigrator;

namespace MerchApi.Migrator.Migrations
{
    [Migration(2)]
    public class MerchStatusesTable : Migration
    {
        public override void Up()
        {
            Create
             .Table("merch_statuses")
             .WithColumn("id").AsInt32().PrimaryKey()
             .WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_statuses");
        }
    }
}