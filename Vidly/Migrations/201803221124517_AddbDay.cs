namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddbDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "bDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "bDay");
        }
    }
}
