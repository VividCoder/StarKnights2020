using Knights.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.App;

namespace Knights
{
    public class StarKnights : VividApp
    {

        public StarKnights() : base("StarKnights 2020", 1700, 800, false)
        {
            InitState = new SKMainMenu();
        }

        public override void InitApp()
        {
            base.InitApp();
        }


    }
}
