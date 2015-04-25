namespace DSKviz.Dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06FixedResultDetail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ResultDetails", "IsCorect", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ResultDetails", "IsCorect", c => c.String());
        }
    }
}
