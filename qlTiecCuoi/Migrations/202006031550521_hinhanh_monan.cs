namespace qlTiecCuoi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hinhanh_monan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MonAns", "HinhAnh", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MonAns", "HinhAnh");
        }
    }
}
