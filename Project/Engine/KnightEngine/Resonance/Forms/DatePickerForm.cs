using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.Resonance;
using Vivid.Resonance.Forms;

namespace KnightEngine.Resonance.Forms
{

    public delegate void DatePicked(int day, int month);

    public class DatePickerForm : UIForm
    {
        public DatePicked Picked = null;
        PanelForm Pan;
        LabelForm MonthLab;
        LabelForm DayLab;
        ButtonForm PrevMonth;
        ButtonForm NextMonth;
        public int CurrentDay = 1;
        public int CurrentMonth = 1;
        List<string> Months = new List<string>();
        List<ButtonForm> Days = new List<ButtonForm>();
        ButtonForm prevDay = null;
        public DatePickerForm()
        {

            Months.Add("January");
            Months.Add("Feburary");
            Months.Add("March");
            Months.Add("April");
            Months.Add("May");
            Months.Add("June");
            Months.Add("July");
            Months.Add("August");
            Months.Add("September");
            Months.Add("October");
            Months.Add("November");
            Months.Add("December");

            Pan = new PanelForm();
            Add(Pan);

            for(int i = 1; i < 32; i++)
            {
                
                var bf = new ButtonForm();
                bf.IntTag = i;
                Pan.Add(bf);
                bf.Text = i.ToString();
                Days.Add(bf);
                bf.Click = (b) =>
                {

                    CurrentDay = bf.IntTag;
                    bf.Highlight = true;
                    if(prevDay != null && prevDay != bf)
                    {
                        prevDay.Highlight = false;
                    }
                    else
                    {
                     
                    }
                    prevDay = bf;

                    AfterSet.Invoke();
                    Picked?.Invoke(CurrentDay, CurrentMonth);
                };


            }

            MonthLab = new LabelForm();
            PrevMonth = new ButtonForm();
            NextMonth = new ButtonForm();

            MonthLab.Text = Months[CurrentMonth];

            Pan.Add(MonthLab);
            Pan.Add(PrevMonth);
            Pan.Add(NextMonth);

            //MonthLab.Set(0,0,0,0,)


            PrevMonth.Click = (b) =>
            {

                CurrentMonth--;
                if (CurrentMonth < 1) CurrentMonth = 12;
                AfterSet.Invoke();
                Picked?.Invoke(CurrentDay, CurrentMonth);
            };

            NextMonth.Click = (b) =>
            {

                CurrentMonth++;
                if (CurrentMonth > 12) CurrentMonth = 1;
                AfterSet.Invoke();
                Picked?.Invoke(CurrentDay, CurrentMonth);
            };

            AfterSet = () =>
            {

                Pan.Set(0, 0, W, H);
                MonthLab.Set(40, 2, W - 80, 25, CurrentDay+":"+Months[CurrentMonth-1]);
                PrevMonth.Set(2, 2, 36, 25, "<");
                NextMonth.Set(W - 38, 2, 36, 25, ">");
                int dx, dy;
                dx = 2;
                dy = 30;

                foreach(var db in Days)
                {
                    db.Set(dx, dy, 30, 30, db.Text);
                    dx = dx + 32;
                    if (dx > W - 30)
                    {
                        dx = 2;
                        dy = dy + 32;
                    }
                }

            };

        }

    }
}
