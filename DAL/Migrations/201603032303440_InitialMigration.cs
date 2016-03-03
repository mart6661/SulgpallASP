namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calenders",
                c => new
                    {
                        CalenderId = c.Int(nullable: false, identity: true),
                        CompetitionId = c.Int(nullable: false),
                        MatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CalenderId)
                .ForeignKey("dbo.Competitions", t => t.CompetitionId, cascadeDelete: true)
                .ForeignKey("dbo.Matches", t => t.MatchId, cascadeDelete: true)
                .Index(t => t.CompetitionId)
                .Index(t => t.MatchId);
            
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        CompetitionId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        Info = c.String(maxLength: 128),
                        Organizer = c.String(maxLength: 128),
                        DateTime = c.DateTime(nullable: false),
                        Spots = c.Int(nullable: false),
                        Referee = c.String(maxLength: 128),
                        PlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompetitionId)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        BirthDateTime = c.DateTime(nullable: false),
                        Email = c.String(),
                        Commentar = c.String(),
                        PlayerTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.PlayerTypes", t => t.PlayerTypeId, cascadeDelete: true)
                .Index(t => t.PlayerTypeId);
            
            CreateTable(
                "dbo.Commentars",
                c => new
                    {
                        CommentarId = c.Int(nullable: false, identity: true),
                        BoardCommentar = c.String(),
                        PlayerId = c.Int(nullable: false),
                        MessageboardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentarId)
                .ForeignKey("dbo.Messageboards", t => t.MessageboardId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.MessageboardId);
            
            CreateTable(
                "dbo.Messageboards",
                c => new
                    {
                        MessageboardId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        PlayerId = c.Int(nullable: false),
                        MatchId = c.Int(nullable: false),
                        CompetetionId = c.Int(nullable: false),
                        Competition_CompetitionId = c.Int(),
                    })
                .PrimaryKey(t => t.MessageboardId)
                .ForeignKey("dbo.Competitions", t => t.Competition_CompetitionId)
                .ForeignKey("dbo.Matches", t => t.MatchId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.MatchId)
                .Index(t => t.Competition_CompetitionId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Players = c.Int(nullable: false),
                        Password = c.String(),
                        Description = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        ResultId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.Results", t => t.ResultId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.ResultId);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        MatchResults = c.String(),
                    })
                .PrimaryKey(t => t.ResultId);
            
            CreateTable(
                "dbo.Leaderboards",
                c => new
                    {
                        LeaderboardId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeaderboardId)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.PlayerTypes",
                c => new
                    {
                        PlayerTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Commentar = c.String(),
                    })
                .PrimaryKey(t => t.PlayerTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "PlayerTypeId", "dbo.PlayerTypes");
            DropForeignKey("dbo.Leaderboards", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Competitions", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Commentars", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Messageboards", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Matches", "ResultId", "dbo.Results");
            DropForeignKey("dbo.Matches", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Messageboards", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.Calenders", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.Messageboards", "Competition_CompetitionId", "dbo.Competitions");
            DropForeignKey("dbo.Commentars", "MessageboardId", "dbo.Messageboards");
            DropForeignKey("dbo.Calenders", "CompetitionId", "dbo.Competitions");
            DropIndex("dbo.Leaderboards", new[] { "PlayerId" });
            DropIndex("dbo.Matches", new[] { "ResultId" });
            DropIndex("dbo.Matches", new[] { "PlayerId" });
            DropIndex("dbo.Messageboards", new[] { "Competition_CompetitionId" });
            DropIndex("dbo.Messageboards", new[] { "MatchId" });
            DropIndex("dbo.Messageboards", new[] { "PlayerId" });
            DropIndex("dbo.Commentars", new[] { "MessageboardId" });
            DropIndex("dbo.Commentars", new[] { "PlayerId" });
            DropIndex("dbo.Players", new[] { "PlayerTypeId" });
            DropIndex("dbo.Competitions", new[] { "PlayerId" });
            DropIndex("dbo.Calenders", new[] { "MatchId" });
            DropIndex("dbo.Calenders", new[] { "CompetitionId" });
            DropTable("dbo.PlayerTypes");
            DropTable("dbo.Leaderboards");
            DropTable("dbo.Results");
            DropTable("dbo.Matches");
            DropTable("dbo.Messageboards");
            DropTable("dbo.Commentars");
            DropTable("dbo.Players");
            DropTable("dbo.Competitions");
            DropTable("dbo.Calenders");
        }
    }
}
