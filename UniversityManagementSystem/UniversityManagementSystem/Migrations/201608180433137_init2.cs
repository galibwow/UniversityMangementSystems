namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Teacher", "DesignationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teacher", "DesignationId");
            AddForeignKey("dbo.Teacher", "DesignationId", "dbo.Designation", "Id", cascadeDelete: true);
            DropColumn("dbo.Teacher", "Designation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teacher", "Designation", c => c.String());
            DropForeignKey("dbo.Teacher", "DesignationId", "dbo.Designation");
            DropIndex("dbo.Teacher", new[] { "DesignationId" });
            DropColumn("dbo.Teacher", "DesignationId");
            DropTable("dbo.Designation");
        }
    }
}
