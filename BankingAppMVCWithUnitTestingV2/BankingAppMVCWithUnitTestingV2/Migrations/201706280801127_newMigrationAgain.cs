namespace BankingAppMVCWithUnitTestingV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigrationAgain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Balance", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "Balance", c => c.Double(nullable: false));
        }
    }
}
