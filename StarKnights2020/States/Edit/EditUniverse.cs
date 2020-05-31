using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.Resonance;
using Vivid.Resonance.Forms;
using Vivid.App;
using Vivid.Texture;
using KnightEngine.Resonance.Forms;

namespace Knights.States.Edit
{
    public class EditUniverse : Vivid.State.VividState
    {

        public override void InitState()
        {
            base.InitState();
            SUI = new Vivid.Resonance.UI();

            var bg = new ImageForm().Set(0, 0, AppInfo.W, AppInfo.H, "").SetImage(new Texture2D("game/bg/workbg1.jpg", LoadMethod.Single, false));

            SUI = new Vivid.Resonance.UI();

            SUI.Root.Add(bg);

            var genUniverse = new ButtonForm().Set(20, 50, 220, 30, "Generate Random Universe");

            bg.Add(genUniverse);

            var back = new ButtonForm().Set(20, AppInfo.H - 50, 80, 30, "Back");

            back.Click = (b) =>
            {

                VividApp.PopState();

            };


            var genVerseWin = new WindowForm().Set(AppInfo.W / 2 - 300, AppInfo.H / 2 - 200, 600, 400, "Generate Universe") as WindowForm;

            var galaxyCount = new NumericForm().Set(135, 5, 140, 30, "") as NumericForm;

            galaxyCount.IncAmount = 10;

            galaxyCount.SetValue(50);

            genVerseWin.Body.Add(galaxyCount);

            var gcLab = new LabelForm().Set(15, 5, 90, 30, "Galaxy Count");

            genVerseWin.Body.Add(gcLab);

            var planetMinCount = new NumericForm().Set(135, 50, 120, 30, "") as NumericForm;

            var planetMaxCount = new NumericForm().Set(280, 50, 120, 30, "") as NumericForm;

            genVerseWin.Body.Add(planetMinCount);
            genVerseWin.Body.Add(planetMaxCount);

            planetMinCount.SetValue(0);
            planetMaxCount.SetValue(10);

            var pcLab = new LabelForm().Set(15, 50, 90, 30, "Planet Count");

            genVerseWin.Body.Add(pcLab);

            var asteroidBeltCount = new NumericForm().Set(135, 90, 120, 30, "") as NumericForm;

            genVerseWin.Body.Add(asteroidBeltCount);

            asteroidBeltCount.IncAmount = 15;
            asteroidBeltCount.SetValue(50);

            var abLab = new LabelForm().Set(15, 90, 90, 30, "Asteroid Belts");

            genVerseWin.Body.Add(abLab);

            var genVerse = new ButtonForm().Set(15, 330, 100, 30, "Generate");

          

            genVerseWin.Body.Add(genVerse);

            var genProg = new ProgressBarForm().Set(130, 330, 450, 30) as ProgressBarForm;
            genProg.Progress = 0;

            genVerseWin.Body.Add(genProg);

            genUniverse.Click = (b) =>
            {

                SUI.Top = genVerseWin;




            };


            genVerse.Click = (b) =>
            {

                int gc = (int)galaxyCount.Value;
                int pmin = (int)planetMinCount.Value;
                int pmax = (int)planetMaxCount.Value;
                Random rnd = new Random(Environment.TickCount);

                int max = (gc + (int)asteroidBeltCount.Value)-1;

                int pp = 0;

                for (int i = 0; i < gc; i++)
                {

                    int pc = rnd.Next(pmin, pmax);

                    float prog = (float)i / (float)gc;

                    prog = (float)pp / (float)max; 
                    genProg.Progress = prog;
                    pp++;
                }

                for(int i = 0; i < (int)asteroidBeltCount.Value; i++)
                {

                    float prog = (float)i / asteroidBeltCount.Value;

                    prog = (float)pp / (float)max;
                    genProg.Progress = prog;
                    pp++;

                }

                SUI.Top = null;

            };

            bg.Add(back);

        }

        public override void UpdateState()
        {
            base.UpdateState();
            SUI.Update();
            Texture2D.UpdateLoading();
        
        }

        public override void DrawState()
        {
            base.DrawState();
            SUI.Render();

        }

    }
}
