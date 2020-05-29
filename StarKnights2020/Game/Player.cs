using Knights.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knights.Game
{
    public class Player
    {
    
        public PlayerType Type
        {
            get;
            set;
        }

        public LifeStatus Status
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public DateAndTime DOB
        {
            get;
            set;
        }

        public Player()
        {
            
        }

        public int Dollars
        {
            get;
            set;
        }

        public virtual void Update()
        {

        }
    }

    public enum PlayerType
    {
        Human,CPU,Network
    }
    public enum LifeStatus
    {
        Alive,Dead,Stasis
    }

}
