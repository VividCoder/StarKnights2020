using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.Map;

namespace Knights.Uni
{
    public class World : StarBody
    {

        public WorldType Type
        {
            get;
            set;
        }

        public WorldMap Map
        {
            get;set;
        }

        public World(string name)
        {

            Name = name;
            Size = 10;
            Type = WorldType.Empty;
            //Map = new WorldMap(
              //  )
        }

        public void GenerateMap()
        {

            Map = new WorldMap((int)Size*8, Environment.TickCount);

        }


    }

    public enum WorldType
    {
        Desert,Greenland,Rural,Utopia,Modern,EarthLike,Moon,GasGiant,Empty
    }

}
