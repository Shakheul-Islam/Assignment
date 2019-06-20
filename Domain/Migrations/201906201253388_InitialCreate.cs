namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessEntities",
                c => new
                    {
                        BusinessId = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 50),
                        Email = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(maxLength: 150),
                        State = c.String(maxLength: 150),
                        Zip = c.String(maxLength: 50),
                        Country = c.String(maxLength: 150),
                        Mobile = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        ContactPerson = c.String(),
                        ReferredBy = c.String(maxLength: 50),
                        Logo = c.String(),
                        Balance = c.Single(nullable: false),
                        LoginUrl = c.String(maxLength: 50),
                        SecurityCode = c.String(maxLength: 50),
                        SMTPServer = c.String(maxLength: 50),
                        SMTPPort = c.Int(nullable: false),
                        SMTPUsername = c.String(maxLength: 50),
                        SMTPPassword = c.String(maxLength: 50),
                        Deleted = c.Boolean(nullable: false),
                        MarkupPlanId = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(),
                        UpdatedOnUtc = c.DateTime(),
                        CurrentBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                        RegentAPI = c.String(),
                        NovoAPI = c.String(),
                        GalileoAPI = c.String(),
                        USBSAPI = c.String(),
                        IndigoAPI = c.String(),
                        AgentType = c.String(),
                    })
                .PrimaryKey(t => t.BusinessId)
                .ForeignKey("dbo.MarkupPlans", t => t.MarkupPlanId, cascadeDelete: true)
                .Index(t => t.MarkupPlanId);
            
            CreateTable(
                "dbo.MarkupPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BusinessEntities", "MarkupPlanId", "dbo.MarkupPlans");
            DropIndex("dbo.BusinessEntities", new[] { "MarkupPlanId" });
            DropTable("dbo.MarkupPlans");
            DropTable("dbo.BusinessEntities");
        }
    }
}
