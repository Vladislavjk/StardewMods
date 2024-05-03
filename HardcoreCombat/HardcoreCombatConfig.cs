using System.Collections.Generic;

namespace HardcoreCombat
{
    public class HardcoreCombatConfig
    {
        public string difficulty = "Normal";
        public bool slimedDebuff = false;
        public bool darknessDebuff = false;
        public bool weaknessDebuff = false;
        public bool monsterMuskDebuff = false;
        public bool nauseatedDebuff = false;
        public bool tipsyDebuff = false;
        public bool burntDebuff = false;
        public bool spookedDebuff = false;
        public bool jinxedDebuff = false;
        public void getCombatDifficultiesRanges(out Dictionary<int, string> ranges)
        {
            ranges = new Dictionary<int, string>();

            ranges[0] = difficulty;
        }
    }
}
