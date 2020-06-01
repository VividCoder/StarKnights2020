using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knights.Uni
{
    public class Universe
    {

        public string Name
        {
            get;
            set;
        }

        public List<Galaxy> Galaxies = new List<Galaxy>();


        public void AddGalaxy(Galaxy galaxy)
        {
            Galaxies.Add(galaxy);
        }

    }
}
