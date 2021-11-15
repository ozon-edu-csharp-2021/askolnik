using FluentMigrator;

namespace MerchApi.Migrator.Migrations
{
    [Migration(1)]
    public class MerchRequestsTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE IF NOT EXISTS merch_requests(
                    id serial NOT NULL,
                    employee_id integer NOT NULL,
                    merch_type_id integer NOT NULL,
                    merch_status_id integer NOT NULL,
                    issue_date time without time zone,
                    PRIMARY KEY (id));"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS merch_requests;");
        }
    }
}