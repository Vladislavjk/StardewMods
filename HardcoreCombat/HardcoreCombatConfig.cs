using System.Collections.Generic;

namespace HardcoreCombat
{
    public class HardcoreCombatConfig
    {
        public string difficulty = "Normal";
        public void getCombatDifficultiesRanges(out Dictionary<int, string> ranges)
        {
            ranges = new Dictionary<int, string>();

            ranges[0] = difficulty;
        }
    }
}
