namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up() // Update yaparsak buradaki işlemler gerçekleşir
        {
            AddColumn("dbo.Contents", "WriterID", c => c.Int());
            CreateIndex("dbo.Contents", "WriterID");
            AddForeignKey("dbo.Contents", "WriterID", "dbo.Writers", "WriterID");
        }
        
        public override void Down() // update yapılmazsa buradaki işlemler gerçekleşir
        {
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropIndex("dbo.Contents", new[] { "WriterID" });
            DropColumn("dbo.Contents", "WriterID");
        }
    }
}
