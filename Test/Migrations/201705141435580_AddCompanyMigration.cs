namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Phone_ID = c.Short(nullable: false, identity: true),
                        Phone = c.Int(),
                        User_ID = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Phone_ID)
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_ID = c.Short(nullable: false, identity: true),
                        UserName = c.String(),
                        UserSname = c.String(),
                        UserEmail = c.String(),
                    })
                .PrimaryKey(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "User_ID", "dbo.Users");
            DropIndex("dbo.Phones", new[] { "User_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Phones");
        }
    }
}
