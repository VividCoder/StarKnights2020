using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.State;

namespace Knights.States
{
    public class SKTitles : VividState
    {

        public override void InitState()
        {
            base.InitState();
            Console.WriteLine("Creating titles");
        }

        public override void DrawState()
        {
            base.DrawState();
        }

    }
}
