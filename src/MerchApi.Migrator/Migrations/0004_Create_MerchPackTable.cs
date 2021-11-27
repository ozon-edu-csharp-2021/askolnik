using FluentMigrator;

namespace MerchApi.Migrator.Migrations
{
    [Migration(4)]
    public class MerchPackTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE IF NOT EXISTS merch_packes(
                    id serial NOT NULL,
                    merch_type_id integer NOT NULL,
                    can_be_reissued boolean NOT NULL,
                    can_be_reissued_after_days integer,
                    PRIMARY KEY (id));"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS merch_packes;");
        }
    }
}