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
using Vivid.VFX;

namespace Knights.States
{
    public class StarSequence : VividState
    {
        public SceneGraph2D Graph;
        public Tex2D NB;
        public List<Tex2D> Stars = new List<Tex2D>();
        
        public GraphSprite NewStar()
        {

            return new GraphSprite(Stars[0], NB);

        }
        
        public override void InitState()
        {
            base.InitState();
            Graph = new SceneGraph2D();
            Stars.Add(new Tex2D("Game/Stars/star1.png", true));
            NB = new Tex2D("Game/Misc/BlankNorm1.png", false);
            //   var logo1 = new Vivid.Tex.Tex2D("game/logo/intro/logo1.png", true);
            //    Graph.Add(new GraphSprite(logo1,new Tex2D("game/misc/blanknorm1.png",false)));
            //  Graph.Add(NewStar());

            i1 = new Tex2D("Game/Stars/star1.png");
            p1 = new Vivid.VFX.SoftParticle(i1);

            Vivid.VFX.VisualFX.Init();
            ps1 = new Vivid.VFX.VFXParticleSystem();
            Vivid.VFX.VisualFX.Add(ps1);
            Vivid.VFX.VisualFX.Graph = Graph;
            ps1.AddBase(p1);

        



        }

        Vivid.Tex.Tex2D i1;
        Vivid.VFX.SoftParticle p1;
        Vivid.VFX.VFXParticleSystem ps1;

        List<GraphSprite> Sprs = new List<GraphSprite>();

        public override void UpdateState()
        {
            base.UpdateState();
            Graph.Update();

            ps1.Spawn(2, 0, 0, 1.0f, 0, 0, 0);
            Vivid.VFX.VisualFX.Update();
            

            //var p1 = new Vivid.VFX.SoftParticle(i1);
     
            Graph.Rot = Graph.Rot + 1;

            //Graph.Z = Graph.Z - 0.01f;

        }

        public override void DrawState()
        {
            base.DrawState();
            Graph.Draw(false);
            Vivid.VFX.VisualFX.Render();
        
        }


    }
}
