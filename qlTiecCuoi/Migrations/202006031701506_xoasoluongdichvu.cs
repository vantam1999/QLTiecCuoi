namespace qlTiecCuoi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xoasoluongdichvu : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DIchVus", "SoLuong");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DIchVus", "SoLuong", c => c.Int(nullable: false));
        }
    }
}
