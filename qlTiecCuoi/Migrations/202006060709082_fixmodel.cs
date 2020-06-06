namespace qlTiecCuoi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DIchVuDatTiecs", "DIchVu_IDDichVu", "dbo.DIchVus");
            DropForeignKey("dbo.DIchVuDatTiecs", "DatTiec_IDDatTiec", "dbo.DatTiecs");
            DropForeignKey("dbo.MonAnDatTiecs", "MonAn_IDMonAn", "dbo.MonAns");
            DropForeignKey("dbo.MonAnDatTiecs", "DatTiec_IDDatTiec", "dbo.DatTiecs");
            DropIndex("dbo.DIchVuDatTiecs", new[] { "DIchVu_IDDichVu" });
            DropIndex("dbo.DIchVuDatTiecs", new[] { "DatTiec_IDDatTiec" });
            DropIndex("dbo.MonAnDatTiecs", new[] { "MonAn_IDMonAn" });
            DropIndex("dbo.MonAnDatTiecs", new[] { "DatTiec_IDDatTiec" });
            DropTable("dbo.DIchVuDatTiecs");
            DropTable("dbo.MonAnDatTiecs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MonAnDatTiecs",
                c => new
                    {
                        MonAn_IDMonAn = c.Int(nullable: false),
                        DatTiec_IDDatTiec = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MonAn_IDMonAn, t.DatTiec_IDDatTiec });
            
            CreateTable(
                "dbo.DIchVuDatTiecs",
                c => new
                    {
                        DIchVu_IDDichVu = c.Int(nullable: false),
                        DatTiec_IDDatTiec = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DIchVu_IDDichVu, t.DatTiec_IDDatTiec });
            
            CreateIndex("dbo.MonAnDatTiecs", "DatTiec_IDDatTiec");
            CreateIndex("dbo.MonAnDatTiecs", "MonAn_IDMonAn");
            CreateIndex("dbo.DIchVuDatTiecs", "DatTiec_IDDatTiec");
            CreateIndex("dbo.DIchVuDatTiecs", "DIchVu_IDDichVu");
            AddForeignKey("dbo.MonAnDatTiecs", "DatTiec_IDDatTiec", "dbo.DatTiecs", "IDDatTiec", cascadeDelete: true);
            AddForeignKey("dbo.MonAnDatTiecs", "MonAn_IDMonAn", "dbo.MonAns", "IDMonAn", cascadeDelete: true);
            AddForeignKey("dbo.DIchVuDatTiecs", "DatTiec_IDDatTiec", "dbo.DatTiecs", "IDDatTiec", cascadeDelete: true);
            AddForeignKey("dbo.DIchVuDatTiecs", "DIchVu_IDDichVu", "dbo.DIchVus", "IDDichVu", cascadeDelete: true);
        }
    }
}
