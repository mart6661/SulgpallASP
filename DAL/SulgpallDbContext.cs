using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Migrations;
using Domain;


namespace DAL
{
    public class SulgpallDbContext : DbContext
    {
        public SulgpallDbContext() : base ("DbConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SulgpallDbContext, MigrationConfiguration>());
        }

        public DbSet<Calender> Calenders { get; set; } 
        public DbSet<Commentar> Commentars { get; set; }

        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Leaderboard> Leaderboards { get; set; }
        public DbSet<Match> Matches { get; set; }
        
        public DbSet<Messageboard> Messageboards { get; set; }
        public DbSet<Player> Players { get; set; }
        
        public DbSet<PlayerType> PlayerTypes { get; set; }
        
        public DbSet<Result> Results { get; set; }     

    }
}
