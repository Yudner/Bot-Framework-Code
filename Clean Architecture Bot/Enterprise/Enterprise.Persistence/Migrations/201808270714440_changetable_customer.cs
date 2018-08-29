namespace Enterprise.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetable_customer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Email_", c => c.String());
            DropColumn("dbo.Customers", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Email", c => c.String());
            DropColumn("dbo.Customers", "Email_");
        }
    }
}
