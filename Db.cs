using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Korepetycje2
{
    public class FireDBContext : DbContext
    {
        public DbSet<Firefighter> Firefighters { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<FireTruck> FireTrucks { get; set; }
        public DbSet<FireTruckAction> FireTruckActions { get; set; }
        public DbSet<FirefighterAction> FirefighterActions { get; set; }

        public FireDBContext() : base()
        {
            Database.Migrate();
        }
        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=192.168.110.131;Database=korepetycje;User Id=sa;Password=lubiePlacki1414;");
    }

    public class Firefighter
    {
        [Key]
        public int FirefighterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }



    public class Action
    {
        [Key]
        public int ActionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool NeedSpectialEquipment { get; set; }
    }

    public class FireTruck
    {
        [Key]
        public int FireTruckId { get; set; }
        public String OperationalNumber { get; set; }

        public bool SpectialEquipment { get; set; }
    }

    public class FirefighterAction
    {
        [Key]
        public int ActionId { get; set; }
        public Action Action { get; set; }
        public int FireTruckId { get; set; }
        public FireTruck FireTruck { get; set; }
    }
    public class FireTruckAction
    {
        [Key]
        public int FireTruckActionId { get; set; }
        public int FireTruckId { get; set; }
        public FireTruck FireTruck { get; set; }
        public int ActionId { get; set; }
        public Action Action { get; set; }

        public DateTime AssignmentDate { get; set; }
    }
}