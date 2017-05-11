namespace Qx.Contents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDbName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.column_design",
                c => new
                    {
                        column_design_id = c.String(nullable: false, maxLength: 50, unicode: false),
                        name = c.String(nullable: false, maxLength: 100, unicode: false),
                        show_count = c.Int(nullable: false),
                        unit_id = c.String(nullable: false, maxLength: 20, unicode: false),
                        update_type_id = c.String(maxLength: 50, unicode: false),
                        html_template = c.String(unicode: false, storeType: "text"),
                        html_template_params = c.String(maxLength: 500, unicode: false),
                        library_id = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.column_design_id);
            
            CreateTable(
                "dbo.column_tempelate",
                c => new
                    {
                        column_tempelate_id = c.Guid(nullable: false),
                        column_tempelate_name = c.String(maxLength: 500),
                        column_tempelate_html = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.column_tempelate_id);
            
            CreateTable(
                "dbo.ConlumnType",
                c => new
                    {
                        column_type_id = c.String(nullable: false, maxLength: 50, unicode: false),
                        column_type_name = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.column_type_id);
            
            CreateTable(
                "dbo.ContentColumnDesign",
                c => new
                    {
                        ccd_id = c.String(nullable: false, maxLength: 50, unicode: false),
                        ctd_id = c.String(maxLength: 50, unicode: false),
                        dt_id = c.String(maxLength: 20, unicode: false),
                        pct_id = c.String(maxLength: 50, unicode: false),
                        column_name = c.String(maxLength: 50, unicode: false),
                        seq = c.String(maxLength: 50, unicode: false),
                        is_pk = c.String(maxLength: 50, unicode: false),
                        def_value = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ccd_id)
                .ForeignKey("dbo.ContentTableDesign", t => t.ctd_id, cascadeDelete: true)
                .ForeignKey("dbo.DataType", t => t.dt_id, cascadeDelete: true)
                .ForeignKey("dbo.PageControlType", t => t.pct_id, cascadeDelete: true)
                .Index(t => t.ctd_id)
                .Index(t => t.dt_id)
                .Index(t => t.pct_id);
            
            CreateTable(
                "dbo.ContentTableDesign",
                c => new
                    {
                        ctd_id = c.String(nullable: false, maxLength: 50, unicode: false),
                        ct_id = c.String(maxLength: 50, unicode: false),
                        table_name = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ctd_id)
                .ForeignKey("dbo.ContentType", t => t.ct_id, cascadeDelete: true)
                .Index(t => t.ct_id);
            
            CreateTable(
                "dbo.ContentTableQuery",
                c => new
                    {
                        ctq_id = c.String(nullable: false, maxLength: 50, unicode: false),
                        ctd_id = c.String(maxLength: 50, unicode: false),
                        sql_query = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ctq_id)
                .ForeignKey("dbo.ContentTableDesign", t => t.ctd_id, cascadeDelete: true)
                .Index(t => t.ctd_id);
            
            CreateTable(
                "dbo.ContentType",
                c => new
                    {
                        ct_id = c.String(nullable: false, maxLength: 50, unicode: false),
                        type_name = c.String(maxLength: 50, unicode: false),
                        father_id = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ct_id);
            
            CreateTable(
                "dbo.DataType",
                c => new
                    {
                        dt_id = c.String(nullable: false, maxLength: 20, unicode: false),
                        type_name = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.dt_id);
            
            CreateTable(
                "dbo.ContentColumnValue",
                c => new
                    {
                        ccv_id = c.String(nullable: false, maxLength: 50, unicode: false),
                        ccd_id = c.String(nullable: false, maxLength: 50, unicode: false),
                        column_value = c.String(maxLength: 150, unicode: false),
                        relation_key_value = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ccv_id)
                .ForeignKey("dbo.ContentColumnDesign", t => t.ccd_id, cascadeDelete: true)
                .Index(t => t.ccd_id);
            
            CreateTable(
                "dbo.PageControlType",
                c => new
                    {
                        pct_id = c.String(nullable: false, maxLength: 50, unicode: false),
                        pct_name = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.pct_id);
            
            CreateTable(
                "dbo.librarys",
                c => new
                    {
                        library_id = c.String(nullable: false, maxLength: 50),
                        father_id = c.String(nullable: false, maxLength: 50),
                        type_id = c.Int(nullable: false),
                        name = c.String(nullable: false, maxLength: 20),
                        description = c.String(maxLength: 50),
                        fileurl = c.String(nullable: false, maxLength: 500),
                        last_update_time = c.DateTime(nullable: false),
                        referrence_count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.library_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContentColumnDesign", "pct_id", "dbo.PageControlType");
            DropForeignKey("dbo.ContentColumnValue", "ccd_id", "dbo.ContentColumnDesign");
            DropForeignKey("dbo.ContentColumnDesign", "dt_id", "dbo.DataType");
            DropForeignKey("dbo.ContentTableDesign", "ct_id", "dbo.ContentType");
            DropForeignKey("dbo.ContentTableQuery", "ctd_id", "dbo.ContentTableDesign");
            DropForeignKey("dbo.ContentColumnDesign", "ctd_id", "dbo.ContentTableDesign");
            DropIndex("dbo.ContentColumnValue", new[] { "ccd_id" });
            DropIndex("dbo.ContentTableQuery", new[] { "ctd_id" });
            DropIndex("dbo.ContentTableDesign", new[] { "ct_id" });
            DropIndex("dbo.ContentColumnDesign", new[] { "pct_id" });
            DropIndex("dbo.ContentColumnDesign", new[] { "dt_id" });
            DropIndex("dbo.ContentColumnDesign", new[] { "ctd_id" });
            DropTable("dbo.librarys");
            DropTable("dbo.PageControlType");
            DropTable("dbo.ContentColumnValue");
            DropTable("dbo.DataType");
            DropTable("dbo.ContentType");
            DropTable("dbo.ContentTableQuery");
            DropTable("dbo.ContentTableDesign");
            DropTable("dbo.ContentColumnDesign");
            DropTable("dbo.ConlumnType");
            DropTable("dbo.column_tempelate");
            DropTable("dbo.column_design");
        }
    }
}
