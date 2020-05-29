using OpenTK.Graphics.ES20;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.Resonance;

namespace KnightEngine.Resonance.Forms
{
    public class TextInfoForm : UIForm
    {

        public List<string> Lines = new List<string>();

        public TextInfoForm()
        {

            void DrawFunc()
            {
                DrawFormSolid(Col);

                int dx = 5;
                int dy = 10;
                foreach(var l in Lines)
                {

                    DrawText(l, dx, dy);
                    dy = dy + 18;
                }
            }

            Draw = DrawFunc;

        }

    }
}
