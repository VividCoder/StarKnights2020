using System;
using System.Collections.Generic;
using System.IO;
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

        public override void Write(BinaryWriter w)
        {
            base.Write(w);

            w.Write((int)Type);
            w.Write(Name);
            w.Write(Size);


        }

        public override void Read(BinaryReader r)
        {
            base.Read(r);
            Type = (WorldType)r.ReadInt32();
            Name = r.ReadString();
            Size = r.ReadSingle();

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
