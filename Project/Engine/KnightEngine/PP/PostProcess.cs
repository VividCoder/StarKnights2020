using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.App;
using Vivid.Draw;
using Vivid.FrameBuffer;
using Vivid.Texture;

namespace KnightEngine.PP
{
    public class PostProcess
    {
        public FrameBufferColor FB;
        public PostProcess()
        {

            FB = new FrameBufferColor(AppInfo.W, AppInfo.H);

        }
        public virtual Texture2D Process(Texture2D bb)
        {


            return null;
        }
    } 
}
