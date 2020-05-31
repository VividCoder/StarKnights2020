using Knights.Game;
using OpenTK.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.App;
using Vivid.Audio;
using Vivid.Material;
using Vivid.Resonance.Forms;
using Vivid.Scene;
using Vivid.Scene.Node;
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
         //   SUI.Root.Add(logo1);

            var new_game = new ButtonForm().Set(AppInfo.W / 2 - 150, 500, 300, 30, "New Game") as ButtonForm;
          //  new_game.LocalBleep = Vivid.Audio.Songs.LoadSound("game/audio/ui/UI_6_Gamestart.wav");

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

                Vivid.Audio.Songs.StopSong();
                VividApp.PushState(new SKNewGame());

            };


            if (Global.EditMode)
            {
                var editGame = new ButtonForm().Set(10, AppInfo.H - 50, 120, 30, "Editor");

                SUI.Root.Add(editGame);

                editGame.Click = (b) =>
                {

                    Songs.StopSong();
                    VividApp.PushState(new SKEditor());

                };

                var editLab = new LabelForm().Set(AppInfo.W / 2 + 200, 170, 130, 30, "Editor Mode");
                SUI.Root.Add(editLab);
            }

            G3D = new SceneGraph3D();

            var l1 = new Light3D();
            l1.Range = 230;
            var l2 = new Light3D();
            l1.SetPos(new OpenTK.Vector3(0.7f, 0, 10));
            l1.Diff = new OpenTK.Vector3(0, 0, 4);
            l2.Range = 300;
            l2.SetPos(new OpenTK.Vector3(-0.5f, 0, 10));
            l2.Diff = new OpenTK.Vector3(4, 0.2f, 0.2f);

            var l3 = new Light3D();
            l3.Range = 370;
            l3.Diff = new OpenTK.Vector3(0.2f, 3.7f, 0.2f);
            l3.SetPos(new OpenTK.Vector3(0.2f, -0.35f, 7));

            l3.Spec = new OpenTK.Vector3(1, 0,0);
            l2.Spec = new OpenTK.Vector3(0,1, 0);
            l1.Spec = new OpenTK.Vector3(0, 0, 1);

           G3D.Add(l1);




            G3D.Add(l2);


            G3D.Add(l3);

            var cam = new Cam3D();

            cam.SetPos(new OpenTK.Vector3(0, -1, 10));

            G3D.Add(cam);

            E1 = Vivid.Import.Import.ImportNode("game/3d/starlogo/alogo1.obj") as Entity3D;
            E2 = Vivid.Import.Import.ImportNode("game/3d/back/back2.obj") as Entity3D;

            var tm1 = new Material3D();
            tm1.ColorMap = new Texture2D("game/tex/metal4Col.png", LoadMethod.Single, false);
            tm1.SpecularMap = new Texture2D("game/tex/metal4spec.png", LoadMethod.Single, false);
            tm1.NormalMap = new Texture2D("game/tex/metal4norm.png", LoadMethod.Single, false);
            var tm2 = new Material3D();
            tm2.ColorMap = new Texture2D("game/tex/metal1Col.png", LoadMethod.Single, false);
            tm2.NormalMap = new Texture2D("game/tex/metal3Norm.png", LoadMethod.Single, false);
            tm2.SpecularMap = new Texture2D("game/tex/metal2spec.png", LoadMethod.Single, false);


           E1.SetMat(tm2);
            E2.SetMat(tm1);

            G3D.Add(E1);
            G3D.Add(E2);


            E1.Rot(new OpenTK.Vector3(90, 0, -90), Space.Local);
            E1.SetMultiPass();
            E2.SetMultiPass();
            E2.SetPos(new OpenTK.Vector3(0, 0, -10));
            E2.Rot(new OpenTK.Vector3(0, 90, 0), Space.Local);
            E2.SetPos(new OpenTK.Vector3(0, 0, -80));

        }
        Vivid.Scene.Entity3D E1 = null;
        Vivid.Scene.SceneGraph3D G3D;
        Vivid.Scene.Entity3D E2 = null;
        public override void ResumeState()
        {
            Vivid.Audio.Songs.PlaySong("game/music/title/title1.mp3");
            //base.ResumeState();
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
            E1.Turn(new OpenTK.Vector3(1, 0, 0), Space.Local);
            SUI.Update();
            G3D.Update();
        }

        public override void DrawState()
        {
            base.DrawState();
            //  Graph.Draw(false);
            //   Vivid.VFX.VisualFX.Render();
            G3D.RenderShadows();
            G3D.Render();

            SUI.Render();
        }


    }
}
