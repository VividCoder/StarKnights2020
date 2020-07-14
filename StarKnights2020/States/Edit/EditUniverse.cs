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
using System.Runtime.InteropServices;
using Knights.Uni;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

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
            var viewUniverse = new ButtonForm().Set(20, 90, 220, 30, "View Universe");
            var saveUniverse = new ButtonForm().Set(20, 130, 220, 30, "Save Universe");

            bg.Add(genUniverse);
            bg.Add(viewUniverse);
            bg.Add(saveUniverse);

            Universe uni1 = new Universe();


            saveUniverse.Click = (b) =>
            {

                uni1.Save("game/uni/universe.dat");

            };

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

     

            void GenUniThread()
            {
                int gc = (int)galaxyCount.Value;
                int pmin = (int)planetMinCount.Value;
                int pmax = (int)planetMaxCount.Value;
                Random rnd = new Random(Environment.TickCount);

                int max = (gc + (int)asteroidBeltCount.Value) - 1;

                int pp = 0;

                for (int i = 0; i < gc; i++)
                {
                    Console.WriteLine("G:" + i);
                    int pc = rnd.Next(pmin, pmax);

                    float prog = (float)i / (float)gc;

                    var galaxy = GenerateGalaxy(pc);

                    prog = (float)pp / (float)max;
                    genProg.Progress = prog;
                    uni1.AddGalaxy(galaxy);
                    pp++;
                }

                for (int i = 0; i < (int)asteroidBeltCount.Value; i++)
                {

                    float prog = (float)i / asteroidBeltCount.Value;

                    prog = (float)pp / (float)max;
                    genProg.Progress = prog;
                    pp++;

                }

                

            }
            Thread gvt;
            genVerse.Click = (b) =>
            {

                gvt = new Thread(new ThreadStart(GenUniThread));

                gvt.Start();

            //    SUI.Top = null;

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
        public Random rnd = new Random(Environment.TickCount);
        public Galaxy GenerateGalaxy(int pc)
        {

            

            string[] first = new string[255];
            string[] sec = new string[255];

            string name = "";

            first[0] = "Alpha";
            first[1] = "Beta";
            first[2] = "Centuri";
            first[3] = "Delta";
            first[4] = "Europa";
            first[5] = "Foxi";
            first[6] = "Gian";
            first[7] = "Horizon";
            first[8] = "Int";
            first[9] = "Jux";
            first[10] = "Klax";
            first[11] = "Myi";
            first[12] = "Maroar";
            first[13] = "Nion";
            first[14] = "Bishops";
            first[15] = "Galaxy";

            sec[0] = "Way";
            sec[1] = "Constellation";
            sec[2] = "Stars";
            sec[3] = "Lost highway";
            sec[4] = "Maze";
            sec[5] = "Of Light";
            sec[6] = "Zone";
            sec[7] = "Ultra";
            sec[8] = "Nova";
            sec[9] = "Temptus";
            sec[10] = "Gate";
            sec[11] = "Gateway";
            sec[12] = "Shadow";

            int fc = 14;
            int sc = 12;

            int fn = rnd.Next(0, fc - 1);
            int sn = rnd.Next(0, sc - 1);
            int combt = rnd.Next(0, 4);

            if (combt > 2)
            {
                name = first[fn] + " Of " + sec[sn];
            }else
            if (combt < 1)
            {
                name = first[fn] + "'s " + sec[sn];
            }
            else
            {
                name = first[fn] + " " + sec[sn];
            }


            if (rnd.Next(0, 20) > 17)
            {

                name = name + "s";

            }

            //else
           // {
             //   name = first[fn] +" "
            //}

            var galaxy = new Galaxy(name);

           // Console.WriteLine("Galaxy:" + name);

            for(int i = 0; i < pc; i++)
            {
                var planet = GeneratePlanet();
                galaxy.AddBody(planet);
            }

            return galaxy;


        }

        public World GeneratePlanet()
        {

            string[] first = new string[255];
            string[] sec = new string[255];

            first[0] = "Yoctar";
            first[1] = "Aguy";
            first[2] = "Utu";
            first[3] = "Eter";
            first[4] = "Europa";
            first[5] = "Graucury";
            first[6] = "Nove";
            first[7] = "Utopia";
            first[8] = "Van";
            first[9] = "Has";

            sec[0] = "Heights";
            sec[1] = "Of Light";
            sec[2] = "Paradise";
            sec[3] = "Utopia";
            sec[4] = "Metro";
            sec[5] = "Nova";
            sec[6] = "Highways";

            int fc = 10;
            int sc = 7;


            int fn = rnd.Next(0, fc - 1);
            int sn = rnd.Next(0, sc - 1);

            string name = first[fn] + " " + sec[sn];

           // Console.WriteLine("Planet:" + name);

            float size = 5 + (float)rnd.NextDouble() * 95;


            var planet = new World(name);

            planet.Size = size;


            int pt = rnd.Next(0, 8);

            planet.Type = (WorldType)pt;

            float orbitLength = 15 + (float)rnd.NextDouble() * 80;

            planet.OrbitLength = orbitLength;

            planet.OrbitPos = rnd.Next(0, 359);

           // planet.GenerateMap();

            return planet;


        }

    }
}
