using System;
namespace hrhdashboard.Models
{
    public class Level
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Count { get; set; }

        public Level()
        {
            Id = 0;
            Name = "";
            Count = 0;
        }

        public Level(int idnt)
        {
            Id = idnt;
            Name = "";
            Count = 0;
        }

        public Level(int idnt, string name)
        {
            Id = idnt;
            Name = name;
            Count = 0;
        }
    }
}
