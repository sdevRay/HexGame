using HexGame.Entities;
using System.Collections.Generic;

namespace HexGame.Models
{
    public class Scenario
    {
        public string Title = "Scenario Title";
        public int Columns = 0;
        public int Rows = 0;
        public string Description = "Scenario Description";
        public List<Hex> Hexes = new List<Hex>();
    }
}
