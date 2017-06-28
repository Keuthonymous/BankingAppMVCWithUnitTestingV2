namespace BankingAppMVCWithUnitTestingV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransModelAdjustments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Amount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Amount");
        }
    }
}
