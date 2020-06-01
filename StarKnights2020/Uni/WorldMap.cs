using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knights.Uni
{
    public class WorldMap
    {

        public HeightMap Terrain;

        public WorldMap(int size,int seed)
        {

            

            Terrain = new HeightMap(size);

        }

    }
}
