namespace Fitness_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workoutplan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkOutPlans",
                c => new
                    {
                        WorkOutPlanID = c.Int(nullable: false, identity: true),
                        ExerciseName = c.String(),
                        Reps = c.Int(nullable: false),
                        sets = c.Int(nullable: false),
                        BodyPart = c.String(),
                        Notes = c.String(),
                        ExerciseId = c.Int(nullable: false),
                        WorkOutId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkOutPlanID)
                .ForeignKey("dbo.Exercises", t => t.ExerciseId, cascadeDelete: true)
                .ForeignKey("dbo.WorkOuts", t => t.WorkOutId, cascadeDelete: true)
                .Index(t => t.ExerciseId)
                .Index(t => t.WorkOutId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOutPlans", "WorkOutId", "dbo.WorkOuts");
            DropForeignKey("dbo.WorkOutPlans", "ExerciseId", "dbo.Exercises");
            DropIndex("dbo.WorkOutPlans", new[] { "WorkOutId" });
            DropIndex("dbo.WorkOutPlans", new[] { "ExerciseId" });
            DropTable("dbo.WorkOutPlans");
        }
    }
}
