using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.Resonance.Forms;

namespace KnightEngine.Resonance.Forms
{

    public delegate void ValueChanged(float newValue);
    public class NumericForm : Vivid.Resonance.UIForm
    {

        public ButtonForm Up, Down;
        public float Value;
        public TextBoxForm ValueB;
        public ValueChanged Changed = null;
        public float IncAmount = 1;

        public void SetValue(float v)
        {

            Value = v;
            ValueB.Text = v.ToString();

        }

        public NumericForm()
        {

            Value = 0;

            Up = new ButtonForm().Set(0, 0, 0, 0, "/\\") as ButtonForm;
            Down = new ButtonForm().Set(0, 0, 0, 0, "\\/") as ButtonForm;
            ValueB = new TextBoxForm();
            ValueB.Text = "0";
            ValueB.Enter = (txt) =>  
            {

                Value = float.Parse(ValueB.Text);
                Changed?.Invoke(Value);

            };

            Up.Click = (b) =>
            {

                Value += IncAmount;
                ValueB.Text = Value.ToString();
                Changed?.Invoke(Value);

            };

            Down.Click = (b) =>
            {

                Value -= IncAmount;
                ValueB.Text = Value.ToString();
                Changed?.Invoke(Value);

            };

            Add(Up, Down, ValueB);

            AfterSet = () =>
            {

                Up.Set(0, 0, 32, H,"/\\");
                Down.Set(W - 32, 0, 32, H,"\\/");
                ValueB.Set(32, 0, W - 64, H,"0");

            };

        }

    }
}
