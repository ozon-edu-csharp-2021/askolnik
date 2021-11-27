using FluentMigrator;

namespace MerchApi.Migrator.Migrations
{
    [Migration(5)]
    public class SkuTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE IF NOT EXISTS skus(
                    id serial NOT NULL,
                    merch_pack_id integer NOT NULL,
                    value integer NOT NULL,
                    PRIMARY KEY (id));"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS skus;");
        }
    }
}