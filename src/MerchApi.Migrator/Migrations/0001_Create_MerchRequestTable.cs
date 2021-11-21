using FluentMigrator;

namespace MerchApi.Migrator.Migrations
{
    [Migration(1)]
    public class MerchRequestTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE IF NOT EXISTS merch_requests(
                    id serial NOT NULL,
                    merch_status_id integer NOT NULL,
                    employee_email varchar NOT NULL,
                    merch_pack_id integer NOT NULL,
                    create_date time without time zone NOT NULL,
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