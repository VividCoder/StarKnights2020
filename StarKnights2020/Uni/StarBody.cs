using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knights.Uni
{
    public class StarBody
    {

        public Vector3 Pos
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public float Size
        {
            get;
            set;
        }

        public float OrbitLength
        {
            get;
            set;
        }

        public float OrbitPos
        {
            get;
            set;
        }

        public virtual void Write(BinaryWriter w)
        {

        }
        public virtual void Read(BinaryReader r)
        {

        }
    }
}
