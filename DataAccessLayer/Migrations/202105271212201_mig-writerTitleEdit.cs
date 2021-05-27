namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migwriterTitleEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterTitle", c => c.String(maxLength: 50));
            DropColumn("dbo.Writers", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "Title", c => c.String(maxLength: 50));
            DropColumn("dbo.Writers", "WriterTitle");
        }
    }
}
