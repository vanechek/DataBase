namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigurationDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        ComingDate = c.DateTime(nullable: false),
                        StanciyaOtpravlenya = c.String(),
                        StanciyaNsnacheniya = c.String(),
                        ProductId = c.Int(),
                        SendId = c.Int(),
                        SupplyScheduleId = c.Int(),
                        Gu12Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gu12", t => t.Gu12Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Sends", t => t.SendId)
                .ForeignKey("dbo.SupplySchedules", t => t.SupplyScheduleId)
                .Index(t => t.ProductId)
                .Index(t => t.SendId)
                .Index(t => t.SupplyScheduleId)
                .Index(t => t.Gu12Id);
            
            CreateTable(
                "dbo.Gu12",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StanciyaOtpravlenie = c.String(),
                        StanciyaNasnacheniya = c.String(),
                        DataNachaloPerevoski = c.DateTime(nullable: false),
                        PlaniruemayaDataOkonchaniya = c.DateTime(nullable: false),
                        ProductId = c.Int(),
                        SendId = c.Int(),
                        SupplyScheduleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Sends", t => t.SendId)
                .ForeignKey("dbo.SupplySchedules", t => t.SupplyScheduleId)
                .Index(t => t.ProductId)
                .Index(t => t.SendId)
                .Index(t => t.SupplyScheduleId);
            
            CreateTable(
                "dbo.Maths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConsignmentId = c.Int(),
                        Gu12Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consignments", t => t.ConsignmentId)
                .ForeignKey("dbo.Gu12", t => t.Gu12Id)
                .Index(t => t.ConsignmentId)
                .Index(t => t.Gu12Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameProduct = c.String(),
                        WeightProduct = c.Double(nullable: false),
                        DangerProduct = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataNachaloOtpravki = c.DateTime(nullable: false),
                        ProductId = c.Int(),
                        TypeProduct = c.String(),
                        WeightProduct = c.Double(nullable: false),
                        CountVagonov = c.Int(nullable: false),
                        StanciyaNasnacheniya = c.String(),
                        StanciyaOtrpavlenie = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.SupplySchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplyDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        WeightProduct = c.Double(nullable: false),
                        CountVagonov = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consignments", "SupplyScheduleId", "dbo.SupplySchedules");
            DropForeignKey("dbo.Consignments", "SendId", "dbo.Sends");
            DropForeignKey("dbo.Consignments", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Consignments", "Gu12Id", "dbo.Gu12");
            DropForeignKey("dbo.Gu12", "SupplyScheduleId", "dbo.SupplySchedules");
            DropForeignKey("dbo.Sends", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Gu12", "SendId", "dbo.Sends");
            DropForeignKey("dbo.Gu12", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Maths", "Gu12Id", "dbo.Gu12");
            DropForeignKey("dbo.Maths", "ConsignmentId", "dbo.Consignments");
            DropIndex("dbo.Sends", new[] { "ProductId" });
            DropIndex("dbo.Maths", new[] { "Gu12Id" });
            DropIndex("dbo.Maths", new[] { "ConsignmentId" });
            DropIndex("dbo.Gu12", new[] { "SupplyScheduleId" });
            DropIndex("dbo.Gu12", new[] { "SendId" });
            DropIndex("dbo.Gu12", new[] { "ProductId" });
            DropIndex("dbo.Consignments", new[] { "Gu12Id" });
            DropIndex("dbo.Consignments", new[] { "SupplyScheduleId" });
            DropIndex("dbo.Consignments", new[] { "SendId" });
            DropIndex("dbo.Consignments", new[] { "ProductId" });
            DropTable("dbo.Users");
            DropTable("dbo.SupplySchedules");
            DropTable("dbo.Sends");
            DropTable("dbo.Products");
            DropTable("dbo.Maths");
            DropTable("dbo.Gu12");
            DropTable("dbo.Consignments");
        }
    }
}
