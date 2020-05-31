using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.Resonance;
using Vivid.Texture;
using OpenTK;
namespace KnightEngine.Resonance.Forms
{
    public class ProgressBarForm : UIForm
    {
        public static Texture2D Bar;
        public float Progress = 0.0f;
        public ProgressBarForm()
        {
            if (Bar == null)
            {
                CoreTex = new Texture2D("data/nxUI/button/button7.png", LoadMethod.Single, true);
                Bar = CoreTex;
            }
            void DrawFunc()
            {

                var pc = Col;
                Col = new Vector4(0.1f, 0.1f, 0.1f, 0.95f);
                DrawForm(CoreTex, -1, -1, W + 2, H + 2);
                Col = pc;
                DrawForm(CoreTex, new Vector4(Col.X * UI.CurUI.FadeAlpha, Col.Y * UI.CurUI.FadeAlpha, Col.Z * UI.CurUI.FadeAlpha, UI.CurUI.FadeAlpha), 1, 1, (int)((float)W*Progress) - 2, H - 2);
                //if (Text == "") return;

            }

            Draw = DrawFunc;

        }



    }
}
