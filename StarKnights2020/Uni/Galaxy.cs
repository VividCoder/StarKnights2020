using OpenTK.Graphics.ES20;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knights.Uni
{
    public class Galaxy
    {

        public List<StarBody> Bodies = new List<StarBody>();

        public string Name
        {
            get;
            set;
        }

        public Galaxy(string name)
        {

            Name = name;

        }
        public void Read(BinaryReader r)
        {

            Name = r.ReadString();
            int bc = r.ReadInt32();

            for(int i = 0; i < bc; i++)
            {

                int bt = r.ReadInt32();
                switch (bt)
                {
                    case 1:
                        var ns = new Sun();
                        ns.Read(r);
                        Bodies.Add(ns);
                        break;
                    case 2:
                        var nw = new World("p");
                        nw.Read(r);
                        Bodies.Add(nw);
                        break;
                }
                //B///odies.Add()


            }

        }
        public void Write(BinaryWriter w)
        {

            w.Write(Name);
            w.Write(Bodies.Count);
            foreach(var b in Bodies)
            {
                if(b is Sun)
                {
                    w.Write(1);
                }
                if(b is World)
                {
                    w.Write(2);
                }
                b.Write(w);
            }

        }

        public void AddBody(StarBody body)
        {

            Bodies.Add(body);

        }

    }
}
