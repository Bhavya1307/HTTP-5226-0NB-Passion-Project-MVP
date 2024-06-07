namespace Fitness_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exercise : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        ExerciseId = c.Int(nullable: false, identity: true),
                        ExerciseName = c.String(),
                        Reps = c.Int(nullable: false),
                        sets = c.Int(nullable: false),
                        BodyPart = c.String(),
                    })
                .PrimaryKey(t => t.ExerciseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Exercises");
        }
    }
}
