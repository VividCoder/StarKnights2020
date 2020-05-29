﻿using OpenTK;
using System;
using Vivid.Draw;
using Vivid.Texture;

namespace Vivid.Resonance.Forms
{
    public class ButtonForm : UIForm
    {
        private bool Pressed = false, Over = false;
        private Vector4 NormCol = new Vector4(0.7f,0.7f, 0.7f, 1f);
        private Vector4 OverCol = new Vector4(1f, 1f, 1f, 1f);
        private Vector4 PressCol = new Vector4(0.2f, 1.6f, 1.6f, 1);
        public static Vivid.Audio.VSoundSource BleepSrc;
        public static Vivid.Audio.VSoundSource BingSrc;
        public Vivid.Audio.VSoundSource LocalBleep = null;
        public static Texture2D ButTex = null;
        public static Texture2D HighTex = null;
        public bool Highlight = false;
        public static int lastBing = 0;
        public ButtonForm()
        {
            Selectable = true;
            if (BleepSrc == null)
            {
                //BleepSrc = new Vivid.Audio.Songs.
                BleepSrc = Vivid.Audio.Songs.LoadSound("game/audio/ui/UI_1_UpDown.wav");
                BingSrc = Vivid.Audio.Songs.LoadSound("game/audio/ui/UI_2_Select.wav");
            }
            else
            {

            }

            LocalBleep = BleepSrc;
            if (Font == null)
            {
                Font = new Font2.OrchidFont("data/font/font1.ttf", 12);
            }

            if (ButTex == null)
            {
                ButTex = new Texture2D("data/nxUI/button/button4.png", LoadMethod.Single, true);
                HighTex = new Texture2D("data/nxUI/button/button2.png", LoadMethod.Single, true);
            }
            SetImage(ButTex);
            Col = NormCol;

            void DrawFunc()
            {
                Pen2D.BlendMod = PenBlend.Alpha;

                //   DrawFormSolid(new Vector4(0, 0, 0, 1));
                if (Highlight)
                {
                    DrawForm(HighTex, -2, -2, W + 4, H + 4, false);
                }
                DrawForm(CoreTex,new Vector4(Col.X * UI.CurUI.FadeAlpha,Col.Y * UI.CurUI.FadeAlpha,Col.Z * UI.CurUI.FadeAlpha,UI.CurUI.FadeAlpha) ,1, 1, W - 2, H - 2);
                //if (Text == "") return;
               
                //DrawText(Text, (W / 2 - Font.Width(Text) / 2)+4, (H / 2 - Font.Height())+4, new Vector4(0, 0, 0, 1));
                DrawText(Text, W / 2 - Font.Width(Text) / 2, H / 2 - 11, new Vector4(0, 1*UI.CurUI.FadeAlpha, 1*UI.CurUI.FadeAlpha, 1*UI.CurUI.FadeAlpha));
            }

            void MouseEnterFunc()
            {
                if (Pressed == false)
                {
                    Col = OverCol;
                }

                int nt = Environment.TickCount;
                if (nt > lastBing + 200)
                {
                    Vivid.Audio.Songs.PlaySource(BingSrc);
                    lastBing = nt;
                }
                    Over = true;
            }

            void MouseLeaveFunc()
            {
                if (Pressed == false)
                {
                    Col = NormCol;
                }
                Over = false;
            }

            void MouseMoveFunc(int x, int y, int dx, int dy)
            {
                if (Pressed)
                {
                    // Drag?.Invoke(dx, dy);
                }
            }

            void MouseDownFunc(int b)
            {
                Col = PressCol;
                Vivid.Audio.Songs.PlaySource(LocalBleep);
                Pressed = true;
            }

            void MouseUpFunc(int b)
            {
                if (Over)
                {
                    Col = OverCol;
                }
                else
                {
                    Col = NormCol;
                }
                Pressed = false;
                Console.WriteLine("CLicked!");
                if (Click != null)
                {
                    Console.WriteLine("Has click");
                }
                Click?.Invoke(b);
            }

            Draw = DrawFunc;
            MouseEnter = MouseEnterFunc;
            MouseLeave = MouseLeaveFunc;
            MouseMove = MouseMoveFunc;
            MouseDown = MouseDownFunc;
            MouseUp = MouseUpFunc;
        }
    }
}