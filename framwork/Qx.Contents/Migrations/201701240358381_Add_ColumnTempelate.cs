namespace Qx.Contents.Bysj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ColumnTempelate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ColumnTempelates",
                c => new
                    {
                        ColumnTempelateID = c.Guid(nullable: false),
                        ColumnTempelateName = c.String(maxLength: 500),
                        ColumnTempelateHTML = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.ColumnTempelateID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ColumnTempelates");
        }
    }
}
