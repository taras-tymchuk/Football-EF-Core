using System.Collections.Generic;

namespace DAL.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }

        public List<Player> Players { get; set; }
    }
}
