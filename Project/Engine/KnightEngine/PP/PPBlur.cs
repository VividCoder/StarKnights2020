using OpenTK.Graphics.ES10;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.Effect;
using Vivid.FX;
using Vivid.Texture;

namespace KnightEngine.PP
{

    public class BlurFX : VEffect
    {
        public BlurFX() : base("","data/shader/fxblurvs.glsl","data/shader/fxblurfs.glsl")
        {

        }

        public override void SetPars()
        {
            //base.SetPars();
            SetTex("tDiffuse", 0);
            SetMat("proj", OpenTK.Matrix4.CreateOrthographicOffCenter(0, Vivid.App.AppInfo.RW, Vivid.App.AppInfo.RH, 0, -1, 1000));
            SetFloat("blurFactor", BlurFactor);
        }
        public float BlurFactor = 1.2f;
    }

    public class PPBlur : PostProcess
    {

        public BlurFX BFX;
        public PPBlur()
        {
            BFX = new BlurFX();
        }

        public float BlurFactor = 1.0f;

        public override Texture2D Process(Texture2D bb)
        {
            //base.Process(bb);

            //OpenTK.Graphics.OpenGL4.GL.Clear(OpenTK.Graphics.OpenGL4.ClearBufferMask.DepthBufferBit);

           // BlurFactor = 1.2f;

            //BFX.Bind();

            BFX.BlurFactor = BlurFactor;

            FB.Bind();

            OpenTK.Graphics.OpenGL4.GL.Disable(OpenTK.Graphics.OpenGL4.EnableCap.Blend);

            Vivid.Draw.IntelliDraw.BeginDraw();

            Vivid.Draw.IntelliDraw.DrawImg(0, 0, FB.IW, FB.IH, bb, new OpenTK.Vector4(1, 1, 1, 1));

            Vivid.Draw.IntelliDraw.EndDraw(BFX);

            FB.Release();

            //BFX.Release();


            return FB.BB;

        }

    }
}
