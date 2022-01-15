using System.Collections.Generic;

namespace HexGame.Entities
{
    public class Scenario
    {
        public string Title = "Scenario Title";
        public int Columns = 0;
        public int Rows = 0;
        public string Description = "Scenario Description";
        public List<Hex> Hexes;
    }
}
