using Knights.States.Edit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.App;
using Vivid.Resonance.Forms;
using Vivid.State;
using Vivid.Texture;

namespace Knights.States
{
    public class SKEditor : VividState
    {

        public override void InitState()
        {
            base.InitState();

            var bg = new ImageForm().Set(0, 0, AppInfo.W, AppInfo.H, "").SetImage(new Texture2D("game/bg/workbg1.jpg", LoadMethod.Single, false));
            
            SUI = new Vivid.Resonance.UI();

            SUI.Root.Add(bg);

            var back = new ButtonForm().Set(20, AppInfo.H - 50, 80, 30,"Back");

            var universeEditor = new ButtonForm().Set(20, 80, 120, 30, "Edit Universe") as ButtonForm;

            back.Click = (b) =>
            {

                VividApp.PopState();

            };

            universeEditor.Click = (b) =>
            {

                VividApp.PushState(new EditUniverse());

            };

            bg.Add(back);
            bg.Add(universeEditor);


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
