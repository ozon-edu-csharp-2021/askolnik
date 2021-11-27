using FluentMigrator;

namespace MerchApi.Migrator.Migrations
{
    [Migration(2)]
    public class MerchRequestStatusTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE IF NOT EXISTS merch_request_statuses(
                    id serial NOT NULL,
                    name character varying NOT NULL,
                    PRIMARY KEY (id));"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS merch_request_statuses;");
        }
    }
}