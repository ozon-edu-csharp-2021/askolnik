using FluentMigrator;

namespace MerchApi.Migrator.Migrations
{
    [Migration(4)]
    public class ItemsTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE IF NOT EXISTS items(
                    id serial NOT NULL,
                    name character varying NOT NULL,
                    merch_type_id integer NOT NULL,
                    PRIMARY KEY (id));"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS items;");
        }
    }
}