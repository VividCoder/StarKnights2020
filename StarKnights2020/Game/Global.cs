using Knights.Game.Players;
using Knights.Races;
using Knights.Races.Race;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knights.Game
{
    public class Global
    {

        public static Player LocalHuman = null;

        public static List<RaceBase> Races = new List<RaceBase>();

        public static void AddRace(RaceBase race)
        {

            Races.Add(race);

        }

        public static RaceBase FindRace(string name)
        {
            foreach(var race in Races)
            {
                if(race.Name.ToLower().Contains(name.ToLower()))
                {
                    return race;
                }
            }
            return null;
        }
    
        public static void InitGame()
        {

            Races.Clear();
            LocalHuman = null;

            AddRace(new RaceHuman());
            AddRace(new RaceE());
            AddRace(new RaceAndroida());

            LocalHuman = new HumanPlayer("John", 30);

        }

    }
}
