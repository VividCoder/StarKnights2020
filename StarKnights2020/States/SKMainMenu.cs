using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.App;
using Vivid.Resonance.Forms;
using Vivid.Scene;
using Vivid.State;
using Vivid.Tex;
using Vivid.Texture;
using Vivid.VFX;

namespace Knights.States
{
    public class SKMainMenu : VividState
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

            i1 = new Tex2D("Game/Stars/star1.png",true);
            p1 = new Vivid.VFX.SoftParticle(i1);

            Vivid.VFX.VisualFX.Init();
            ps1 = new Vivid.VFX.VFXParticleSystem();
            Vivid.VFX.VisualFX.Add(ps1);
           // Vivid.VFX.VisualFX.Add(new )

            Vivid.VFX.VisualFX.Graph = Graph;
            //ps1.AddBase(p1);
            ps1.AddBase(new Vivid.VFX.SoftParticle(new Tex2D("Game/Stars/star2.png", true)));
            Vivid.Audio.Songs.PlaySong("game/music/title/title1.mp3");


            var BG1 = new Tex2D("game/logo/intro/bg1.jpg",false);

            var g1 = new GraphSprite(BG1, BG1, 1800, 1400);

            Graph.Add(g1);
            SUI = new Vivid.Resonance.UI();

            var logo1 = new ImageForm().Set(AppInfo.W / 2 - 300, 20, 600, 256, "").SetImage(new Texture2D("game/logo/intro/logo4.png", LoadMethod.Single, true));
            SUI.Root.Add(logo1);

            var new_game = new ButtonForm().Set(AppInfo.W / 2 - 150, 500, 300, 30, "New Game");
            var load_game = new ButtonForm().Set(AppInfo.W / 2 - 150, 540, 300, 30, "Load Game");
            var options = new ButtonForm().Set(AppInfo.W / 2 - 150, 580, 300, 30, "Options");
            var exit = new ButtonForm().Set(AppInfo.W / 2 - 150, 620, 300, 30, "Exit Game");
            SUI.Root.Add(new_game);
            SUI.Root.Add(load_game);
            SUI.Root.Add(options);
            SUI.Root.Add(exit);

            exit.Click = (b) =>
            {

                Environment.Exit(1);

            };

            new_game.Click = (b) =>
            {

                VividApp.PushState(new SKNewGame());

            };

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

            //  Graph.Rot = Graph.Rot + 1;

            //Graph.Z = Graph.Z - 0.01f;
            Texture2D.UpdateLoading();
            SUI.Update();

        }

        public override void DrawState()
        {
            base.DrawState();
            Graph.Draw(false);
            Vivid.VFX.VisualFX.Render();
            SUI.Render();
        }


    }
}
