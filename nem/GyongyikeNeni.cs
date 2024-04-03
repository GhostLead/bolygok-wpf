using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nem
{
    internal class GyongyikeNeni
    {
        int x, y, z, e;

        public GyongyikeNeni(string sor)
        {
            string[] tomb = sor.Split(";");

            this.x = int.Parse(tomb[0]);
            this.y = int.Parse(tomb[1]);
            this.z = int.Parse(tomb[2]);
            this.e = int.Parse(tomb[3]);
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Z { get => z; set => z = value; }
        public int E { get => e; set => e = value; }
    }
}
