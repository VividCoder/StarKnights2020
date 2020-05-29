using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knights.Game.Players
{
    public class HumanPlayer : Player
    {

        public HumanPlayer(string name,int age)
        {

            Name = name;
            Age = age;
            Type = PlayerType.Human;
            Status = LifeStatus.Alive;
            Dollars = 1000000;

        }

    }
}
