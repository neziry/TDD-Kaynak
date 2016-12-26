namespace TDDExample2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Average", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Average", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
