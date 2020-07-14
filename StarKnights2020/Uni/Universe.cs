using System;
using System.Collections.Generic;
using System.IO;
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


        public void Load(string path)
        {

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);

            int gc = r.ReadInt32();

            for(int i = 0; i < gc; i++)
            {

                var ng = new Galaxy("g");

                ng.Read(r);

                Galaxies.Add(ng);

            }

            r.Close();
            fs.Close();

        }

        public void Save(string path)
        {

            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            BinaryWriter w = new BinaryWriter(fs);

            w.Write(Galaxies.Count);

            foreach(var ga in Galaxies)
            {
                ga.Write(w);
            }

            w.Flush();
            fs.Flush();
            w = null;
            fs = null;



        }

    }
}
