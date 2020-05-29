using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knights.Races.Race
{
    public class RaceHuman : RaceBase
    {

        public RaceHuman()
        {
            Name = "Human";
            LoadAssets();

            AddInfo("Humanity. Human. Kings and soldiers. Prince's and paupers");
            AddInfo("");
            AddInfo("The human race, that all begun in a haze of water.");
            AddInfo("From the dinosuars to the peak of their evolution, humans");
            AddInfo("");
            AddInfo("Always ones for technological over spirtual advancement");
            AddInfo("They are considered a worthy alley, and a formidable foe.");
        }

    }
}
