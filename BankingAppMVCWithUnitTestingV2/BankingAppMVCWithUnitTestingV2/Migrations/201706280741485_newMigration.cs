namespace BankingAppMVCWithUnitTestingV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Balance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "Balance", c => c.Int(nullable: false));
        }
    }
}
