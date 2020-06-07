namespace qlTiecCuoi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class danhsachsanh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SanhTiecs", "SanhTiec_IDSanh", c => c.Int());
            CreateIndex("dbo.SanhTiecs", "SanhTiec_IDSanh");
            AddForeignKey("dbo.SanhTiecs", "SanhTiec_IDSanh", "dbo.SanhTiecs", "IDSanh");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanhTiecs", "SanhTiec_IDSanh", "dbo.SanhTiecs");
            DropIndex("dbo.SanhTiecs", new[] { "SanhTiec_IDSanh" });
            DropColumn("dbo.SanhTiecs", "SanhTiec_IDSanh");
        }
    }
}
