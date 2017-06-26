namespace BankingAppMVCWithUnitTestingV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Balance = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.PersonID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fname = c.String(nullable: false, maxLength: 140),
                        Lname = c.String(nullable: false, maxLength: 140),
                        PersonNum = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventTime = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TransactionAccounts",
                c => new
                    {
                        Transaction_ID = c.Int(nullable: false),
                        Account_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Transaction_ID, t.Account_ID })
                .ForeignKey("dbo.Transactions", t => t.Transaction_ID, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.Account_ID, cascadeDelete: true)
                .Index(t => t.Transaction_ID)
                .Index(t => t.Account_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionAccounts", "Account_ID", "dbo.Accounts");
            DropForeignKey("dbo.TransactionAccounts", "Transaction_ID", "dbo.Transactions");
            DropForeignKey("dbo.Accounts", "PersonID", "dbo.People");
            DropIndex("dbo.TransactionAccounts", new[] { "Account_ID" });
            DropIndex("dbo.TransactionAccounts", new[] { "Transaction_ID" });
            DropIndex("dbo.Accounts", new[] { "PersonID" });
            DropTable("dbo.TransactionAccounts");
            DropTable("dbo.Transactions");
            DropTable("dbo.People");
            DropTable("dbo.Accounts");
        }
    }
}
