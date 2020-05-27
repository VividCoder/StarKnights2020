using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.App;
using Vivid.Scene;
using Vivid.State;
using Vivid.Tex;
using Vivid.Texture;

namespace Knights.States
{
    public class StarSequence : VividState
    {
        public SceneGraph2D Graph;
        public override void InitState()
        {
            base.InitState();
            Graph = new SceneGraph2D();
            var logo1 = new Vivid.Tex.Tex2D("game/logo/intro/logo1.png", true);
            Graph.Add(new GraphSprite(logo1,new Tex2D("game/misc/blanknorm1.png",false)));
        }

        public override void UpdateState()
        {
            base.UpdateState();
            Graph.Update();
            Graph.Rot = Graph.Rot + 1;
            Graph.Z = Graph.Z - 0.01f;
        }

        public override void DrawState()
        {
            base.DrawState();
            Graph.Draw(false);
        
        }


    }
}
