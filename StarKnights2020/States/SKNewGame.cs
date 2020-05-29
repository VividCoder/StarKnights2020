using KnightEngine.Resonance.Forms;
using Knights.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Vivid.App;
using Vivid.Resonance.Forms;
using Vivid.Scene;
using Vivid.Texture;

namespace Knights.States
{
    public class SKNewGame : Vivid.State.VividState
    {

        public override void InitState()
        {
            base.InitState();
            SUI = new Vivid.Resonance.UI();

            Global.InitGame();

            var bg = new ImageForm().Set(0, 0, AppInfo.W, AppInfo.H).SetImage(new Vivid.Texture.Texture2D("game/bg/spaceport3.jpg", Vivid.Texture.LoadMethod.Single, false));
            var newGame = new ImageForm().Set(AppInfo.W/2-210, 10, 420, 160).SetImage(new Texture2D("game/dat/newGame/newGame1.png", LoadMethod.Single, true));
            var pinfow = new WindowForm().Set(20, 100, 400, 500, "Create Player") as WindowForm;
            var pnamel = new LabelForm().Set(5, 20, 250, 25, "Name");
            var pname_tb = new TextBoxForm().Set(55, 20, 250, 25, "John") as TextBoxForm;

            var raceInfoWin = new WindowForm().Set(440, 100, 520, 500, "Race Information") as WindowForm;
            var raceInfoBody = new TextInfoForm().Set(10, 30, 470, 450) as TextInfoForm;

            raceInfoWin.Add(raceInfoBody);

            void SetRaceInfo(Knights.Races.RaceBase race)
            {

                int line = 0;
                raceInfoBody.Lines.Clear();
                foreach(var info in race.Info)
                {
                    raceInfoBody.Lines.Add(info);
                    line++;
                }

            }

            var agelab = new LabelForm().Set(5, 50,55, 25, "Age") as LabelForm;

            var ageNum = new NumericForm().Set(55, 50, 140, 30) as NumericForm;

            var bdform = new DatePickerForm().Set(5, 95, 230, 200) as DatePickerForm;

            var racelab = new LabelForm().Set(5, 95, 80, 30, "Race");

            var raceSel = new DropDownListForm().Set(95, 95, 200, 30) as DropDownListForm;

            var raceImgLab = new LabelForm().Set(5, 130, 80, 30, "Portait");

            var raceImg = new ImageForm().Set(95, 130, 128, 128) as ImageForm;

            raceImg.SetImage(Global.Races[0].Portrait);
            SetRaceInfo(Global.Races[0]);

            raceSel.SelectedItem = (item) =>
            {

                //Console.WriteLine("SRace:" + item);
                var srace = Global.FindRace(item);
                raceImg.SetImage(srace.Portrait);
                SetRaceInfo(srace);

            };


            foreach(var r in Global.Races)
            {
                raceSel.AddItem(r.Name, r.Portrait);
            }

            ageNum.SetValue(30);


            var startCashLab = new LabelForm().Set(5, 265, 80, 30, "Starting Credits:");

            var startCashNum = new NumericForm().Set(135, 265, 190, 30, "1000000") as NumericForm;

            startCashNum.SetValue(1000000);
            startCashNum.IncAmount = 10000;

            startCashNum.Changed = (val) =>
            {

                if(val<500000)
                {
                    startCashNum.SetValue(500000);
                }
                if(val>2000000)
                {
                    startCashNum.SetValue(2000000);
                }

            };


            Vivid.Audio.Songs.PlaySong("game/music/newgame/newgame1.mp3");

            pinfow.Body.Add(pnamel);
            pinfow.Body.Add(pname_tb);
            pinfow.Body.Add(ageNum);
            pinfow.Body.Add(agelab);
            pinfow.Body.Add(raceImgLab, raceImg);
            pinfow.Body.Add(racelab, raceSel);
            pinfow.Body.Add(startCashLab, startCashNum);


           
           // pinfow.Body.Add(bdform);

            bg.Add(newGame);
            bg.Add(pinfow);
            bg.Add(raceInfoWin);


            var startWin = new WindowForm().Set(975, 100, 450, 495, "Starting Conditions");

            var newCarLab = new LabelForm().Set(5, 30, 90, 30, "Game Mode");

            var newCar = new DropDownListForm().Set(120, 30, 240, 30, "") as DropDownListForm;


            newCar.AddItem("New Carrear", new Texture2D("game/caricon/newCar.png", LoadMethod.Single, true));
            newCar.AddItem("Random Start", new Texture2D("game/caricon/randomIcon.jpg", LoadMethod.Single, true));

            var forLab = new LabelForm().Set(5, 70, 120, 20, "For Race");

            var forRace = new DropDownListForm().Set(120, 70, 180, 30) as DropDownListForm;

            foreach(var r in Global.Races)
            {
                forRace.AddItem(r.Name, r.Portrait);
            }

            bg.Add(startWin);

            var startPosLab = new LabelForm().Set(5, 110, 90, 30, "Locale");

            var startPos = new DropDownListForm().Set(120, 110, 180, 30) as DropDownListForm;

            startPos.AddItem("Homeworld", new Texture2D("game/loc/home1.png", LoadMethod.Single, true));
            startPos.AddItem("Other planet", new Texture2D("game/loc/other1.png", LoadMethod.Single, true));
            startPos.AddItem("Random", new Texture2D("game/caricon/randomIcon.jpg", LoadMethod.Single, true));


            startWin.Add(startPosLab,startPos,forRace,forLab,newCarLab,newCar);



            bdform.Picked = (day, month) =>
            {

                Console.WriteLine("Day:" + day + " Month:" + month);

            };

            var back = new ButtonForm().Set(25, AppInfo.H - 80, 85, 25, "Back");

            bg.Add(back);

            back.Click = (b) =>
            {

                Vivid.Audio.Songs.StopSong();
                VividApp.PopState();

            };

            var beginGame = new ButtonForm().Set(20, 420, 400, 30, "Begin Game");
            startWin.Add(beginGame);
            
            SUI.Root.Add(bg);

        }

        public override void UpdateState()
        {
            base.UpdateState();
            Texture2D.UpdateLoading();
            SUI.Update();
        }

        public override void DrawState()
        {
            base.DrawState();
            SUI.Render();

        }

    }
}
