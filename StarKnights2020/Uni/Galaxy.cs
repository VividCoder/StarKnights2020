using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knights.Uni
{
    public class Galaxy
    {

        public List<StarBody> Bodies = new List<StarBody>();

        public string Name
        {
            get;
            set;
        }

        public Galaxy(string name)
        {

            Name = name;

        }

        public void AddBody(StarBody body)
        {

            Bodies.Add(body);

        }

    }
}
