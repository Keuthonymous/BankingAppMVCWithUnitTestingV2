namespace BankingAppMVCWithUnitTestingV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonNummerToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "PersonNum", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "PersonNum", c => c.Int(nullable: false));
        }
    }
}
