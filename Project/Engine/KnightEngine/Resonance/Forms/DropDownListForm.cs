using System.Collections.Generic;
using Vivid.Texture;

namespace Vivid.Resonance.Forms
{
    public class DropDownListForm : UIForm
    {

        public string CurrentItem = "";
        public Texture2D CurrentImage = null;
        public List<string> Items = new List<string>();
        public List<Texture2D> ItemImage = new List<Texture2D>();
        public bool Open = false;
        public SelectItem SelectedItem = null;

        public DropDownListForm()
        {

            Draw = () =>
            {

                DrawFormSolid(new OpenTK.Vector4(1, 1, 1, 1));
                if (CurrentImage != null)
                {
                    DrawForm(CurrentImage, 2, 2, 32, H - 4);
                    DrawText(CurrentItem, 7 + 36,3);
                }
                else
                {
                    DrawText(CurrentItem, 7, 3);
                }


            };

            MouseDown = (b) =>
            {
                if (Open)
                {
                    Open = false;
                    Forms.Clear();
                }
                else
                {
                    int y = 0;
                    Open = true;
                    foreach (var item in Items)
                    {
                        var ib = new ButtonForm().Set(0, H + y, W, 25, item) as ButtonForm;
                        y = y + 25;
                        Add(ib);
                        int ii = 0;
                        ib.Click = (bt) =>
                        {
                            CurrentItem = item;
                            foreach (var i in Items)
                            {
                                if (i == item)
                                {
                                    CurrentImage = ItemImage[ii];
                                }
                                ii++;
                            }
                            //CurrentImage = 


                            Open = false;
                            Forms.Clear();
                            SelectedItem?.Invoke(item);
                        };
                    }
                }
            };

        }

        public void AddItem(string item, Texture2D img=null)
        {
            if (Items.Count == 0)
            {
                CurrentItem = item;
                CurrentImage = img;
            }
                Items.Add(item);
            ItemImage.Add(img);
        }

    }
    public delegate void SelectItem(string item);
}
