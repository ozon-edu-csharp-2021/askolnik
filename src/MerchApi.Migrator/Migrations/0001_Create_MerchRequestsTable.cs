using FluentMigrator;

namespace MerchApi.Migrator.Migrations
{
    [Migration(1)]
    public class MerchRequestsTable : Migration
    {
        public override void Up()
        {
            Create.Table("merch_requests")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("employee_id").AsInt32().NotNullable()
                .WithColumn("merch_type_id").AsInt32().NotNullable()
                .WithColumn("merch_status_id").AsInt32().NotNullable()
                .WithColumn("issue_date").AsDateTime2().Nullable();
        }

        public override void Down()
        {
            Delete.Table("merch_requests");
        }
    }
}