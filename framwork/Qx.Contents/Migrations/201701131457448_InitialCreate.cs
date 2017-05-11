namespace Qx.Contents.Bysj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ColumnDesigns",
                c => new
                    {
                        column_design_id = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        ShowCount = c.Int(nullable: false),
                        UnitID = c.String(nullable: false, maxLength: 20, unicode: false),
                        UpdateTypeID = c.String(maxLength: 50, unicode: false),
                        HtmlTemplate = c.String(unicode: false, storeType: "text"),
                        HtmlTemplateParams = c.String(maxLength: 500, unicode: false),
                        LibraryID = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.column_design_id);
            
            CreateTable(
                "dbo.ConlumnType",
                c => new
                    {
                        ColumnTypeID = c.String(nullable: false, maxLength: 50, unicode: false),
                        ColumnTypeName = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ColumnTypeID);
            
            CreateTable(
                "dbo.ContentColumnDesign",
                c => new
                    {
                        CCD_ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        CTD_ID = c.String(maxLength: 50, unicode: false),
                        DT_ID = c.String(maxLength: 20, unicode: false),
                        PCT_ID = c.String(maxLength: 50, unicode: false),
                        ColumnName = c.String(maxLength: 50, unicode: false),
                        Seq = c.String(maxLength: 50, unicode: false),
                        IsPk = c.String(maxLength: 50, unicode: false),
                        DefValue = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CCD_ID)
                .ForeignKey("dbo.ContentTableDesign", t => t.CTD_ID, cascadeDelete: true)
                .ForeignKey("dbo.DataType", t => t.DT_ID, cascadeDelete: true)
                .ForeignKey("dbo.PageControlType", t => t.PCT_ID, cascadeDelete: true)
                .Index(t => t.CTD_ID)
                .Index(t => t.DT_ID)
                .Index(t => t.PCT_ID);
            
            CreateTable(
                "dbo.ContentColumnValue",
                c => new
                    {
                        CCV_ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        CCD_ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        ColumnValue = c.String(maxLength: 150, unicode: false),
                        RelationKeyValue = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CCV_ID)
                .ForeignKey("dbo.ContentColumnDesign", t => t.CCD_ID, cascadeDelete: true)
                .Index(t => t.CCD_ID);
            
            CreateTable(
                "dbo.ContentTableDesign",
                c => new
                    {
                        CTD_ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        CT_ID = c.String(maxLength: 50, unicode: false),
                        TableName = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CTD_ID)
                .ForeignKey("dbo.ContentType", t => t.CT_ID, cascadeDelete: true)
                .Index(t => t.CT_ID);
            
            CreateTable(
                "dbo.ContentTableQuery",
                c => new
                    {
                        CTQ_ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        CTD_ID = c.String(maxLength: 50, unicode: false),
                        SqlQuery = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CTQ_ID)
                .ForeignKey("dbo.ContentTableDesign", t => t.CTD_ID, cascadeDelete: true)
                .Index(t => t.CTD_ID);
            
            CreateTable(
                "dbo.ContentType",
                c => new
                    {
                        CT_ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        TypeName = c.String(maxLength: 50, unicode: false),
                        FatherID = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CT_ID);
            
            CreateTable(
                "dbo.DataType",
                c => new
                    {
                        DT_ID = c.String(nullable: false, maxLength: 20, unicode: false),
                        TypeName = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.DT_ID);
            
            CreateTable(
                "dbo.PageControlType",
                c => new
                    {
                        PCT_ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        PCT_Name = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.PCT_ID);
            
            CreateTable(
                "dbo.Librarys",
                c => new
                    {
                        LibraryID = c.String(nullable: false, maxLength: 50),
                        FatherID = c.String(nullable: false, maxLength: 50),
                        TypeID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                        Description = c.String(maxLength: 50),
                        FileUrl = c.String(nullable: false, maxLength: 500),
                        LastUpdateTime = c.DateTime(nullable: false),
                        ReferrenceCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LibraryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContentColumnDesign", "PCT_ID", "dbo.PageControlType");
            DropForeignKey("dbo.ContentColumnDesign", "DT_ID", "dbo.DataType");
            DropForeignKey("dbo.ContentTableDesign", "CT_ID", "dbo.ContentType");
            DropForeignKey("dbo.ContentTableQuery", "CTD_ID", "dbo.ContentTableDesign");
            DropForeignKey("dbo.ContentColumnDesign", "CTD_ID", "dbo.ContentTableDesign");
            DropForeignKey("dbo.ContentColumnValue", "CCD_ID", "dbo.ContentColumnDesign");
            DropIndex("dbo.ContentTableQuery", new[] { "CTD_ID" });
            DropIndex("dbo.ContentTableDesign", new[] { "CT_ID" });
            DropIndex("dbo.ContentColumnValue", new[] { "CCD_ID" });
            DropIndex("dbo.ContentColumnDesign", new[] { "PCT_ID" });
            DropIndex("dbo.ContentColumnDesign", new[] { "DT_ID" });
            DropIndex("dbo.ContentColumnDesign", new[] { "CTD_ID" });
            DropTable("dbo.Librarys");
            DropTable("dbo.PageControlType");
            DropTable("dbo.DataType");
            DropTable("dbo.ContentType");
            DropTable("dbo.ContentTableQuery");
            DropTable("dbo.ContentTableDesign");
            DropTable("dbo.ContentColumnValue");
            DropTable("dbo.ContentColumnDesign");
            DropTable("dbo.ConlumnType");
            DropTable("dbo.ColumnDesigns");
        }
    }
}
