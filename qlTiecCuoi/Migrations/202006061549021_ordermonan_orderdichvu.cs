namespace qlTiecCuoi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordermonan_orderdichvu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDichVus",
                c => new
                    {
                        IDOrderDichVu = c.Int(nullable: false, identity: true),
                        IDDichVu = c.Int(nullable: false),
                        IDUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDOrderDichVu)
                .ForeignKey("dbo.DIchVus", t => t.IDDichVu, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IDUser, cascadeDelete: true)
                .Index(t => t.IDDichVu)
                .Index(t => t.IDUser);
            
            CreateTable(
                "dbo.OrderMonAns",
                c => new
                    {
                        IDOrderMonAn = c.Int(nullable: false, identity: true),
                        IDUSer = c.Int(nullable: false),
                        IDMonAn = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDOrderMonAn)
                .ForeignKey("dbo.MonAns", t => t.IDMonAn, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IDUSer, cascadeDelete: true)
                .Index(t => t.IDUSer)
                .Index(t => t.IDMonAn);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderMonAns", "IDUSer", "dbo.Users");
            DropForeignKey("dbo.OrderMonAns", "IDMonAn", "dbo.MonAns");
            DropForeignKey("dbo.OrderDichVus", "IDUser", "dbo.Users");
            DropForeignKey("dbo.OrderDichVus", "IDDichVu", "dbo.DIchVus");
            DropIndex("dbo.OrderMonAns", new[] { "IDMonAn" });
            DropIndex("dbo.OrderMonAns", new[] { "IDUSer" });
            DropIndex("dbo.OrderDichVus", new[] { "IDUser" });
            DropIndex("dbo.OrderDichVus", new[] { "IDDichVu" });
            DropTable("dbo.OrderMonAns");
            DropTable("dbo.OrderDichVus");
        }
    }
}
