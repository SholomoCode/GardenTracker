﻿namespace Tracker.Models
{
    public class Seed
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DatePlanted { get; set; }

        public string HardinessZone { get; set; }

        public ICollection<Bed> Beds { get; set; }

        public string UserId { get; set; }

        public Seed(string name, DateTime datePlanted, string hardinessZone, string userId)
        {
            Name = name;
            DatePlanted = datePlanted;
            Beds = new List<Bed>();
            HardinessZone = hardinessZone;
            UserId = userId;
        }
        public Seed() 
        { 
            Beds = new List<Bed>();
        }
    }
}
