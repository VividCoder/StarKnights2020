using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.App;
using Vivid.Audio;
using Vivid.Draw;
using Vivid.Resonance.Forms;
using Vivid.State;
using Vivid.Texture;

namespace Knights.States
{
    public class SKTitles : VividState
    {

        public List<Texture2D> Logos = new List<Texture2D>();
        public Texture2D BG1 = null;
        int logo = 0;
        int logos = 0;
        float la = 0.0f;
        float sa, ta;
        float ba = 0.0f;
        public override void InitState()
        {
            base.InitState();
            Console.WriteLine("Creating titles");
            Songs.PlaySong("game/music/logo/intrologo2.wav");

            Logos.Add(new Texture2D("game/logo/intro/logo1.png",LoadMethod.Single,true));
            Logos.Add(new Texture2D("game/logo/intro/logo2.png", LoadMethod.Single, true));
            Logos.Add(new Texture2D("game/logo/intro/logo3.png", LoadMethod.Single, true));
            Logos.Add(new Texture2D("game/logo/intro/logo4.png", LoadMethod.Single, true));
            BG1 = new Texture2D("game/logo/intro/bg1.jpg", LoadMethod.Single, false);
            SUI = new Vivid.Resonance.UI();
            sa = ta = 0;


            var start_lab = new LabelForm().Set(25, AppInfo.H - 80, 350, 30, "Press Any Button To Start");
            SUI.Root = start_lab;

 //           f
        }

        public override void UpdateState()
        {
            base.UpdateState();
            Texture2D.UpdateLoading();
            if (ba < 1.0f)
            {
                ba = ba + 0.01f;
            }
            SUI.Update();
            switch (logos)
            {
                case 0:
                    if(la<1.0f)
                    {
                        la = la + 0.01f;
                    }
                    else
                    {
                        sa = sa + 0.1f;
                        if (sa > 12.0f)
                        {
                            sa = 0;
                            logos = 1;
                        }
                        //logos = 1;
                    }
                    break;
                case 1:

                    if (la > 0)
                    {
                        la = la - 0.01f;
                    }
                    else
                    {

                        sa = sa + 0.1f;
                        if (sa > 8.0f)
                        {
                            logos = 0;
                            logo = logo + 1;
                            if (logo == 4)
                            {
                                VividApp.PushState(new StarSequence());
                            }
                            la = 0;
                            sa = 0.0f;
                        }

                    }

                    break;
            }
        }
        public override void DrawState()
        {
            base.DrawState();
            IntelliDraw.BeginDraw();
            IntelliDraw.DrawImg(0, 80, AppInfo.W, AppInfo.H-160, BG1, new OpenTK.Vector4(ba, ba, ba, ba));
            IntelliDraw.DrawImg(AppInfo.W/2-300,AppInfo.H/2 -150, 600, 300, Logos[logo], new OpenTK.Vector4(la, la, la, la));
            IntelliDraw.EndDraw();
            SUI.Render();
        }

    }
}
