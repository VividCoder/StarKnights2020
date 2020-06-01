using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Knights.Uni
{
    public class HeightMap
    {

        public List<MapPoint> Points = new List<MapPoint>();
        public static Random rnd = new Random();
        public HeightMap(int size)
        {

          

            int hpc = 256;

            Vector3[] hp = new Vector3[256];

            for(int i = 0; i < hpc; i++)
            {

                float x, y, z;

                x = ((float)rnd.NextDouble() * size)-size/2;
                z = ((float)rnd.NextDouble() * size)-size/2;
                y = (float)rnd.NextDouble() * 256;


                hp[i] = new Vector3(x, y, z);


            }

            for(int mz = 0; mz < size; mz++)
            {
                for(int mx = 0; mx < size; mx++)
                {

                    var p = new MapPoint();

                    float height = 5;

                    var pos = new Vector3();
                    pos.X = mx - size / 2;
                    pos.Z = mz - size / 2;
                    pos.Y = height;

                    p.Pos = pos;

                    Points.Add(p);
                    

                }
            }

            int vv = 5;
        }


    }

    public class MapPoint
    {

        public Vector3 Pos = new Vector3();

    }

}
