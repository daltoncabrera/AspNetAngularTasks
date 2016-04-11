namespace AspNetTestProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Status", c => c.Int());
            DropColumn("dbo.Tasks", "CreatorId");
            DropColumn("dbo.Tasks", "CreatedDate");
            DropColumn("dbo.Tasks", "DoingId");
            DropColumn("dbo.Tasks", "DoingDate");
            DropColumn("dbo.Tasks", "DoneId");
            DropColumn("dbo.Tasks", "DoneDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "DoneDate", c => c.DateTime());
            AddColumn("dbo.Tasks", "DoneId", c => c.Int());
            AddColumn("dbo.Tasks", "DoingDate", c => c.DateTime());
            AddColumn("dbo.Tasks", "DoingId", c => c.Int());
            AddColumn("dbo.Tasks", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Tasks", "CreatorId", c => c.Int());
            DropColumn("dbo.Tasks", "Status");
        }
    }
}
