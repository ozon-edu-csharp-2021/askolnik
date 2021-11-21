using FluentMigrator;

namespace MerchApi.Migrator.Migrations
{
    [Migration(2)]
    public class MerchStatusTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE IF NOT EXISTS merch_statuses(
                    id serial NOT NULL,
                    name character varying NOT NULL,
                    PRIMARY KEY (id));"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS merch_statuses;");
        }
    }
}