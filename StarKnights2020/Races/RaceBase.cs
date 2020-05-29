using Knights.Game;
using OpenTK.Graphics.ES11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.Texture;

namespace Knights.Races
{
    public class RaceBase
    {

        public string Name
        {
            get;
            set;
        }

        public Texture2D Portrait
        {
            get;
            set;
        }

        public List<string> Info = new List<string>();

        public List<Player> Players = new List<Player>();

        public void AddInfo(string s)
        {
            Info.Add(s);
        }

        public virtual void LoadAssets()
        {

            Portrait = new Texture2D("game/race/" + Name + "/portrait.png", LoadMethod.Single, true);


        }

    }
}
