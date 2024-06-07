namespace Fitness_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkOuts",
                c => new
                    {
                        WorkOutId = c.Int(nullable: false, identity: true),
                        WorkOutName = c.String(),
                    })
                .PrimaryKey(t => t.WorkOutId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorkOuts");
        }
    }
}
