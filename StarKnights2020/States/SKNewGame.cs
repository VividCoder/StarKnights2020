using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.App;
using Vivid.Resonance.Forms;
using Vivid.Texture;

namespace Knights.States
{
    public class SKNewGame : Vivid.State.VividState
    {

        public override void InitState()
        {
            base.InitState();
            SUI = new Vivid.Resonance.UI();

            var bg = new ImageForm().Set(0, 0, AppInfo.W, AppInfo.H).SetImage(new Vivid.Texture.Texture2D("game/bg/spaceport3.jpg", Vivid.Texture.LoadMethod.Single, false));
            var newGame = new ImageForm().Set(AppInfo.W/2-210, 10, 420, 160).SetImage(new Texture2D("game/dat/newGame/newGame1.png", LoadMethod.Single, true));
            var pinfow = new WindowForm().Set(20, 100, 400, 500, "Create Player") as WindowForm;
            var pnamel = new LabelForm().Set(5, 20, 250, 25, "Name");
            var pname_tb = new TextBoxForm().Set(55, 20, 250, 25, "John") as TextBoxForm;
            pinfow.Body.Add(pnamel);
            pinfow.Body.Add(pname_tb);
            bg.Add(newGame);
            bg.Add(pinfow);


            var back = new ButtonForm().Set(25, AppInfo.H - 80, 85, 25, "Back");

            bg.Add(back);

            back.Click = (b) =>
            {

                VividApp.PopState();

            };
            
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
