using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Migrations
{
    [Migration(202407020001)]
    public class InitialTables_202407020001 : Migration
    {
        public override void Down()
        {
            Delete.Table("Companies");
        }
        public override void Up()
        {
            Create.Table("Companies")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Address").AsString(60).NotNullable()
                .WithColumn("Country").AsString(50).NotNullable();

        }
    }
}
