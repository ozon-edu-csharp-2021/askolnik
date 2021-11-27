using FluentMigrator;

namespace MerchApi.Migrator.Migrations
{
    [Migration(3)]
    public class MerchTypeTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE IF NOT EXISTS merch_types(
                    id serial NOT NULL,
                    name character varying NOT NULL,
                    PRIMARY KEY (id));"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS merch_types;");
        }
    }
}